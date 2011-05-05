/*
 * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
 *
 * Bullet Continuous Collision Detection and Physics Library
 * Copyright (c) 2003-2008 Erwin Coumans  http://www.bulletphysics.com/
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose, 
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

//#define USE_BRUTEFORCE_RAYBROADPHASE

using System.Diagnostics;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.Debuging;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
    public class CollisionWorld
    {

	//this constructor doesn't own the dispatcher and paircache/broadphase
	    public CollisionWorld(IDispatcher dispatcher,IBroadphaseInterface broadphasePairCache, ICollisionConfiguration collisionConfiguration)
        {
            m_dispatcher1 = dispatcher;
            m_broadphasePairCache = broadphasePairCache;
            m_collisionObjects = new ObjectArray<CollisionObject>();
            m_dispatchInfo = new DispatcherInfo();
            m_forceUpdateAllAabbs = true;
        }

        public virtual void Cleanup()
        {
            foreach(CollisionObject collisionObject in m_collisionObjects)
	        {
		        BroadphaseProxy bp = collisionObject.GetBroadphaseHandle();
		        if (bp != null)
		        {
			        //
			        // only clear the cached algorithms
			        //
                    if (GetBroadphase().GetOverlappingPairCache() != null)
                    {
                        GetBroadphase().GetOverlappingPairCache().CleanProxyFromPairs(bp, m_dispatcher1);
                    }
                    GetBroadphase().DestroyProxy(bp,m_dispatcher1);
			        collisionObject.SetBroadphaseHandle(null);
		        }
	        }
        }

	    public void	SetBroadphase(IBroadphaseInterface pairCache)
	    {
		    m_broadphasePairCache = pairCache;
	    }

	    public IBroadphaseInterface	GetBroadphase()
	    {
		    return m_broadphasePairCache;
	    }

	    public IOverlappingPairCache	GetPairCache()
	    {
		    return m_broadphasePairCache.GetOverlappingPairCache();
	    }

	    public IDispatcher GetDispatcher()
	    {
		    return m_dispatcher1;
	    }

        public void	UpdateSingleAabb(CollisionObject colObj)
        {
	        Vector3 minAabb = new Vector3();
            Vector3 maxAabb = new Vector3();
            Matrix wt = colObj.GetWorldTransform();
	        colObj.GetCollisionShape().GetAabb(ref wt, ref minAabb,ref maxAabb);
	        //need to increase the aabb for contact thresholds
            Vector3 contactThreshold = new Vector3(BulletGlobals.gContactBreakingThreshold, BulletGlobals.gContactBreakingThreshold, BulletGlobals.gContactBreakingThreshold);
	        minAabb -= contactThreshold;
	        maxAabb += contactThreshold;



            if (BulletGlobals.g_streamWriter != null && debugCollisionWorld)
            {
                MathUtil.PrintVector3(BulletGlobals.g_streamWriter, "updateSingleAabbMin", minAabb);
                MathUtil.PrintVector3(BulletGlobals.g_streamWriter, "updateSingleAabbMax", maxAabb);
            }


	        IBroadphaseInterface bp = (IBroadphaseInterface)m_broadphasePairCache;

	        //moving objects should be moderately sized, probably something wrong if not
	        if ( colObj.IsStaticObject() || ((maxAabb-minAabb).LengthSquared() < 1e12f))
	        {
		        bp.SetAabb(colObj.GetBroadphaseHandle(),ref minAabb,ref maxAabb, m_dispatcher1);
	        } 
            else
	        {
		        //something went wrong, investigate
		        //this assert is unwanted in 3D modelers (danger of loosing work)
		        colObj.SetActivationState(ActivationState.DISABLE_SIMULATION);

                //static bool reportMe = true;
                bool reportMe = true;
		        if (reportMe && m_debugDrawer != null)
		        {
			        reportMe = false;
			        m_debugDrawer.ReportErrorWarning("Overflow in AABB, object removed from simulation");
			        m_debugDrawer.ReportErrorWarning("If you can reproduce this, please email bugs@continuousphysics.com\n");
			        m_debugDrawer.ReportErrorWarning("Please include above information, your Platform, version of OS.\n");
			        m_debugDrawer.ReportErrorWarning("Thanks.\n");
		        }
	        }
        }

	    public virtual void	UpdateAabbs()
        {
            //BT_PROFILE("updateAabbs");

	        Matrix predictedTrans = new Matrix();
	        for (int i=0;i<m_collisionObjects.Count;i++)
	        {
		        CollisionObject colObj = m_collisionObjects[i];

		        //only update aabb of active objects
		        if (m_forceUpdateAllAabbs || colObj.IsActive())
		        {
			        UpdateSingleAabb(colObj);
		        }
	        }
        }

	
	    public virtual void	SetDebugDrawer(IDebugDraw debugDrawer)
	    {
            m_debugDrawer = debugDrawer;
            BulletGlobals.gDebugDraw = debugDrawer;
	    }

	    public virtual IDebugDraw GetDebugDrawer()
	    {
		    return m_debugDrawer;
	    }

	    public virtual void	DebugDrawWorld()
        {

        }

        public virtual void DebugDrawObject(ref Matrix worldTransform, CollisionShape shape, ref Vector3 color)
        {
        }


	    public int	GetNumCollisionObjects()
	    {
		    return m_collisionObjects.Count;
	    }

	    /// rayTest performs a raycast on all objects in the btCollisionWorld, and calls the resultCallback
	    /// This allows for several queries: first hit, all hits, any hit, dependent on the value returned by the callback.
	    public virtual void	RayTest(ref Vector3 rayFromWorld, ref Vector3 rayToWorld, RayResultCallback resultCallback)
        {
            //BT_PROFILE("rayTest");
	        /// use the broadphase to accelerate the search for objects, based on their aabb
	        /// and for each object with ray-aabb overlap, perform an exact ray test
	        SingleRayCallback rayCB = new SingleRayCallback(ref rayFromWorld,ref rayToWorld,this,resultCallback);

            #if !USE_BRUTEFORCE_RAYBROADPHASE
            m_broadphasePairCache.RayTest(ref rayFromWorld,ref rayToWorld,rayCB);
            rayCB.Cleanup();

            #else
	        for (int i=0;i<GetNumCollisionObjects();i++)
	        {
		        rayCB.Process(m_collisionObjects[i].GetBroadphaseHandle());
	        }	
            #endif //USE_BRUTEFORCE_RAYBROADPHASE

        }


	    ///contactTest performs a discrete collision test between colObj against all objects in the btCollisionWorld, and calls the resultCallback.
	    ///it reports one or more contact points for every overlapping object (including the one with deepest penetration)
	    public void	ContactTest(CollisionObject colObj, ContactResultCallback resultCallback)
        {
        }

	    ///contactTest performs a discrete collision test between two collision objects and calls the resultCallback if overlap if detected.
	    ///it reports one or more contact points (including the one with deepest penetration)
        public void ContactPairTest(CollisionObject colObjA, CollisionObject colObjB, ContactResultCallback resultCallback)
        {
        }


	    // convexTest performs a swept convex cast on all objects in the btCollisionWorld, and calls the resultCallback
	    // This allows for several queries: first hit, all hits, any hit, dependent on the value return by the callback.
        public virtual void ConvexSweepTest(ConvexShape castShape, Matrix convexFromWorld, Matrix convexToWorld, ConvexResultCallback resultCallback, float allowedCcdPenetration)
        {
            ConvexSweepTest(castShape, ref convexFromWorld, ref convexToWorld, resultCallback, allowedCcdPenetration);
        }

        public virtual void ConvexSweepTest (ConvexShape castShape, ref Matrix convexFromWorld, ref Matrix convexToWorld, ConvexResultCallback resultCallback,  float allowedCcdPenetration)
        {
            //BT_PROFILE("convexSweepTest");
	        /// use the broadphase to accelerate the search for objects, based on their aabb
	        /// and for each object with ray-aabb overlap, perform an exact ray test
	        /// unfortunately the implementation for rayTest and convexSweepTest duplicated, albeit practically identical

	        Matrix convexFromTrans = new Matrix();
            Matrix convexToTrans = new Matrix();
	        convexFromTrans = convexFromWorld;
	        convexToTrans = convexToWorld;
            Vector3 castShapeAabbMin = new Vector3(); 
            Vector3 castShapeAabbMax = new Vector3();
	        /* Compute AABB that encompasses angular movement */
	        {
		        Vector3 linVel = new Vector3();
                Vector3 angVel = new Vector3();
		        TransformUtil.CalculateVelocity (ref convexFromTrans, ref convexToTrans, 1.0f, ref linVel, ref angVel);
		        Vector3 zeroLinVel = new Vector3();
                Matrix R = MathUtil.BasisMatrix(ref convexFromTrans);
		        castShape.CalculateTemporalAabb (ref R, ref zeroLinVel, ref angVel, 1.0f, ref castShapeAabbMin, ref castShapeAabbMax);
	        }

        #if !USE_BRUTEFORCE_RAYBROADPHASE
	        SingleSweepCallback	convexCB = new SingleSweepCallback(castShape,ref convexFromWorld,ref convexToWorld,this,resultCallback,allowedCcdPenetration);
            Vector3 tempFrom = convexFromTrans.Translation;
            Vector3 tempTo = convexToTrans.Translation;
	        m_broadphasePairCache.RayTest(ref tempFrom,ref tempTo,convexCB,ref castShapeAabbMin,ref castShapeAabbMax);
            convexCB.Cleanup();
        #else
	        /// go over all objects, and if the ray intersects their aabb + cast shape aabb,
	        // do a ray-shape query using convexCaster (CCD)
	        int i;
	        for (i=0;i<m_collisionObjects.Count;i++)
	        {
		        CollisionObject	collisionObject= m_collisionObjects[i];
		        //only perform raycast if filterMask matches
		        if(resultCallback.NeedsCollision(collisionObject.GetBroadphaseHandle())) 
                {
			        //RigidcollisionObject* collisionObject = ctrl.GetRigidcollisionObject();
			        Vector3 collisionObjectAabbMin = new Vector3();
                    Vector3 collisionObjectAabbMax = new Vector3();
			        collisionObject.GetCollisionShape().GetAabb(collisionObject.GetWorldTransform(),ref collisionObjectAabbMin,ref collisionObjectAabbMax);
			        AabbUtil2.AabbExpand(ref collisionObjectAabbMin, ref collisionObjectAabbMax, ref castShapeAabbMin, ref castShapeAabbMax);
			        float hitLambda = 1f; //could use resultCallback.m_closestHitFraction, but needs testing
			        Vector3 hitNormal = new Vector3();
                    Vector3 fromOrigin = convexFromWorld.Translation;
                    Vector3 toOrigin = convexToWorld.Translation;
                    if (AabbUtil2.RayAabb(ref fromOrigin, ref toOrigin, ref collisionObjectAabbMin, ref collisionObjectAabbMax, ref hitLambda, ref hitNormal))
			        {
                        Matrix trans = collisionObject.GetWorldTransform();
				        ObjectQuerySingle(castShape, ref convexFromTrans,ref convexToTrans,
					        collisionObject,
						        collisionObject.GetCollisionShape(),
						        ref trans,
						        resultCallback,
						        allowedCcdPenetration);
			        }
		        }
	        }
        #endif //USE_BRUTEFORCE_RAYBROADPHASE
        }

        public virtual void AddCollisionObject(CollisionObject collisionObject)
        {
            AddCollisionObject(collisionObject, CollisionFilterGroups.DefaultFilter, CollisionFilterGroups.AllFilter);
        }

        public virtual void AddCollisionObject(CollisionObject collisionObject, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask)
        {
    	    //check that the object isn't already added
            //btAssert( m_collisionObjects.findLinearSearch(collisionObject)  == m_collisionObjects.size());

            Debug.Assert(collisionObject != null);
		    m_collisionObjects.Add(collisionObject);

		    //calculate new AABB
		    Matrix trans = collisionObject.GetWorldTransform();
            Vector3 minAabb = new Vector3();
            Vector3 maxAabb= new Vector3();

		    collisionObject.GetCollisionShape().GetAabb(ref trans,ref minAabb,ref maxAabb);

		    BroadphaseNativeTypes type = collisionObject.GetCollisionShape().ShapeType;
		    collisionObject.SetBroadphaseHandle( GetBroadphase().CreateProxy(
			    ref minAabb,
			    ref maxAabb,
			    type,
			    collisionObject,
			    collisionFilterGroup,
			    collisionFilterMask,
			    m_dispatcher1,0
			    ))	;
        }

        public ObjectArray<CollisionObject> GetCollisionObjectArray()
	    {
		    return m_collisionObjects;
	    }

        //public virtual void	performDiscreteCollisionDetection();

	    public DispatcherInfo GetDispatchInfo()
	    {
		    return m_dispatchInfo;
	    }

        public virtual void	PerformDiscreteCollisionDetection()
        {
            //BT_PROFILE("performDiscreteCollisionDetection");

	        DispatcherInfo dispatchInfo = GetDispatchInfo();

	        UpdateAabbs();

	        {
                //BT_PROFILE("calculateOverlappingPairs");
		        m_broadphasePairCache.CalculateOverlappingPairs(m_dispatcher1);
	        }


	        IDispatcher dispatcher = GetDispatcher();
	        {
                //BT_PROFILE("dispatchAllCollisionPairs");
		        if (dispatcher != null)
                {
			        dispatcher.DispatchAllCollisionPairs(m_broadphasePairCache.GetOverlappingPairCache(),dispatchInfo,m_dispatcher1);
                }
	        }
        }


        public virtual void RemoveCollisionObject(CollisionObject collisionObject)
        {
	        //bool removeFromBroadphase = false;
	        {
		        BroadphaseProxy bp = collisionObject.GetBroadphaseHandle();
		        if (bp != null)
		        {
			        //
			        // only clear the cached algorithms
			        //
			        GetBroadphase().GetOverlappingPairCache().CleanProxyFromPairs(bp,m_dispatcher1);
			        GetBroadphase().DestroyProxy(bp,m_dispatcher1);
			        collisionObject.SetBroadphaseHandle(null);
		        }
	        }
	        //swapremove
	        m_collisionObjects.Remove(collisionObject);
        }

       	public bool	GetForceUpdateAllAabbs()
	    {
		    return m_forceUpdateAllAabbs;
	    }

	    public void SetForceUpdateAllAabbs( bool forceUpdateAllAabbs)
	    {
		    m_forceUpdateAllAabbs = forceUpdateAllAabbs;
	    }


    public virtual void	RayTestSingle(ref Matrix rayFromTrans,ref Matrix rayToTrans,
					  CollisionObject collisionObject,
					  CollisionShape collisionShape,
					  ref Matrix colObjWorldTransform,
					  RayResultCallback resultCallback)
    {
	    SphereShape pointShape = new SphereShape(0.0f);
	    pointShape.Margin = 0f;
	    ConvexShape castShape = pointShape;

	    if (collisionShape.IsConvex())
	    {
    //		BT_PROFILE("rayTestConvex");
		    CastResult castResult = new CastResult();
		    castResult.m_fraction = resultCallback.m_closestHitFraction;

		    ConvexShape convexShape = (ConvexShape)collisionShape;
            VoronoiSimplexSolver simplexSolver = new VoronoiSimplexSolver();
    //#define USE_SUBSIMPLEX_CONVEX_CAST 1
    //#ifdef USE_SUBSIMPLEX_CONVEX_CAST
            
            // FIXME - MAN - convexcat here seems to make big difference to forklift.
            SubSimplexConvexCast convexCaster = new SubSimplexConvexCast(castShape, convexShape, simplexSolver);

            //GjkConvexCast convexCaster = new GjkConvexCast(castShape, convexShape, simplexSolver);


    //#else
		    //btGjkConvexCast	convexCaster(castShape,convexShape,&simplexSolver);
		    //btContinuousConvexCollision convexCaster(castShape,convexShape,&simplexSolver,0);
    //#endif //#USE_SUBSIMPLEX_CONVEX_CAST

		    if (convexCaster.CalcTimeOfImpact(ref rayFromTrans,ref rayToTrans,ref colObjWorldTransform,ref colObjWorldTransform,castResult))
		    {
			    //add hit
			    if (castResult.m_normal.LengthSquared() > 0.0001f)
			    {
				    if (castResult.m_fraction < resultCallback.m_closestHitFraction)
				    {

                        //if (resultCallback.m_closestHitFraction != 1f)
                        //{
                        //    int ibreak = 0;
                        //    convexCaster.calcTimeOfImpact(ref rayFromTrans, ref rayToTrans, ref colObjWorldTransform, ref colObjWorldTransform, castResult);
                        //}

    //#ifdef USE_SUBSIMPLEX_CONVEX_CAST
					    //rotate normal into worldspace
					    castResult.m_normal = Vector3.TransformNormal(castResult.m_normal,rayFromTrans);
    //#endif //USE_SUBSIMPLEX_CONVEX_CAST

					    castResult.m_normal.Normalize();
					    LocalRayResult localRayResult = new LocalRayResult(
							    collisionObject,
							    null,
							    ref castResult.m_normal,
							    castResult.m_fraction
						    );

					    bool normalInWorldSpace = true;
					    resultCallback.AddSingleResult(localRayResult, normalInWorldSpace);

				    }
			    }
		    }
            castResult.Cleanup();
	    } 
        else 
        {
		    if (collisionShape.IsConcave())
		    {
    //			BT_PROFILE("rayTestConcave");
		    	if (collisionShape.ShapeType==BroadphaseNativeTypes.TRIANGLE_MESH_SHAPE_PROXYTYPE && collisionShape is BvhTriangleMeshShape)
	    		{
				    ///optimized version for btBvhTriangleMeshShape
					BvhTriangleMeshShape triangleMesh = (BvhTriangleMeshShape)collisionShape;
				    Matrix worldTocollisionObject = Matrix.Invert(colObjWorldTransform);
				    Vector3 rayFromLocal = Vector3.Transform(rayFromTrans.Translation,worldTocollisionObject);
				    Vector3 rayToLocal = Vector3.Transform(rayToTrans.Translation,worldTocollisionObject);

                    Matrix transform = Matrix.Identity;
				    BridgeTriangleRaycastCallback rcb = new BridgeTriangleRaycastCallback(ref rayFromLocal,ref rayToLocal, resultCallback,collisionObject,triangleMesh,ref transform);
				    rcb.m_hitFraction = resultCallback.m_closestHitFraction;
				    triangleMesh.PerformRaycast(rcb,ref rayFromLocal,ref rayToLocal);
                    rcb.Cleanup();
			    } 
                else
			    {
				    //generic (slower) case
				    ConcaveShape concaveShape = (ConcaveShape)collisionShape;

				    Matrix worldTocollisionObject = Matrix.Invert(colObjWorldTransform);

				    Vector3 rayFromLocal = Vector3.Transform(rayFromTrans.Translation,worldTocollisionObject);
				    Vector3 rayToLocal = Vector3.Transform(rayToTrans.Translation,worldTocollisionObject);

				    //ConvexCast::CastResult
                    Matrix transform = Matrix.Identity;
                    BridgeTriangleConcaveRaycastCallback rcb = new BridgeTriangleConcaveRaycastCallback(ref rayFromLocal, ref rayToLocal, resultCallback, collisionObject, concaveShape,ref transform);
				    rcb.m_hitFraction = resultCallback.m_closestHitFraction;

				    Vector3 rayAabbMinLocal = rayFromLocal;
				    MathUtil.VectorMin(ref rayToLocal,ref rayAabbMinLocal);
				    Vector3 rayAabbMaxLocal = rayFromLocal;
                    MathUtil.VectorMax(ref rayToLocal,ref rayAabbMaxLocal);

				    concaveShape.ProcessAllTriangles(rcb,ref rayAabbMinLocal,ref rayAabbMaxLocal);
                    rcb.Cleanup();
			    }
		    } 
            else 
            {
                // BT_PROFILE("rayTestCompound");
			    ///@todo: use AABB tree or other BVH acceleration structure, see btDbvt
			    if (collisionShape.IsCompound())
			    {
				    CompoundShape compoundShape = (CompoundShape)(collisionShape);
				    int i=0;
				    for (i=0;i<compoundShape.GetNumChildShapes();i++)
				    {
					    Matrix childTrans = compoundShape.GetChildTransform(i);
					    CollisionShape childCollisionShape = compoundShape.GetChildShape(i);
					    Matrix childWorldTrans = MathUtil.BulletMatrixMultiply(colObjWorldTransform,childTrans) ;
					    // replace collision shape so that callback can determine the triangle
					    CollisionShape saveCollisionShape = collisionObject.GetCollisionShape();
					    collisionObject.InternalSetTemporaryCollisionShape((CollisionShape)childCollisionShape);

                        LocalInfoAdder2 my_cb = new LocalInfoAdder2(i, resultCallback);
					    my_cb.m_closestHitFraction = resultCallback.m_closestHitFraction;
					
					    RayTestSingle(ref rayFromTrans,ref rayToTrans,
						    collisionObject,
						    childCollisionShape,
						    ref childWorldTrans,
						    my_cb);
					    // restore
					    collisionObject.InternalSetTemporaryCollisionShape(saveCollisionShape);
                        my_cb.cleanup();
				    }
			    }
		    }
	    }
    }

    /// objectQuerySingle performs a collision detection query and calls the resultCallback. It is used internally by rayTest.
    public static void	ObjectQuerySingle(ConvexShape castShape,ref Matrix convexFromTrans,ref Matrix convexToTrans,
					  CollisionObject collisionObject,CollisionShape collisionShape,
					  ref Matrix colObjWorldTransform,
					  ConvexResultCallback resultCallback, float allowedPenetration)
    {
	    if (collisionShape.IsConvex())
	    {
		    //BT_PROFILE("convexSweepConvex");
		    CastResult castResult = new CastResult();
		    castResult.m_allowedPenetration = allowedPenetration;
		    castResult.m_fraction = resultCallback.m_closestHitFraction;//float(1.);//??

		    ConvexShape convexShape = (ConvexShape) collisionShape;
		    VoronoiSimplexSolver simplexSolver = new VoronoiSimplexSolver();
		    GjkEpaPenetrationDepthSolver gjkEpaPenetrationSolver = new GjkEpaPenetrationDepthSolver();
    		
		    ContinuousConvexCollision convexCaster1 = new ContinuousConvexCollision(castShape,convexShape,simplexSolver, gjkEpaPenetrationSolver);
		    //btGjkConvexCast convexCaster2(castShape,convexShape,&simplexSolver);
		    //btSubsimplexConvexCast convexCaster3(castShape,convexShape,&simplexSolver);

		    IConvexCast castPtr = convexCaster1;
		
		    if (castPtr.CalcTimeOfImpact(ref convexFromTrans,ref convexToTrans,ref colObjWorldTransform,ref colObjWorldTransform,castResult))
		    {
			    //add hit
			    if (castResult.m_normal.LengthSquared() > 0.0001f)
			    {
				    if (castResult.m_fraction < resultCallback.m_closestHitFraction)
				    {
					    castResult.m_normal.Normalize();
					    LocalConvexResult localConvexResult = new LocalConvexResult
								    (
									    collisionObject,
									    null,
									    ref castResult.m_normal,
									    ref castResult.m_hitPoint,
									    castResult.m_fraction
								    );

					    bool normalInWorldSpace = true;
					    resultCallback.AddSingleResult(localConvexResult, normalInWorldSpace);

				    }
			    }
		    }
	    } 
        else 
        {
		    if (collisionShape.IsConcave())
		    {
			    if (collisionShape.ShapeType==BroadphaseNativeTypes.TRIANGLE_MESH_SHAPE_PROXYTYPE)
			    {
				    //BT_PROFILE("convexSweepbtBvhTriangleMesh");
				    BvhTriangleMeshShape triangleMesh = (BvhTriangleMeshShape)collisionShape;
				    Matrix worldTocollisionObject = Matrix.Invert(colObjWorldTransform);
				    Vector3 convexFromLocal = Vector3.Transform(convexFromTrans.Translation,worldTocollisionObject);
				    Vector3  convexToLocal = Vector3.Transform(convexToTrans.Translation,worldTocollisionObject);
				    // rotation of box in local mesh space = MeshRotation^-1 * ConvexToRotation

				    Matrix rotationXform = MathUtil.BasisMatrix(ref worldTocollisionObject) *  MathUtil.BasisMatrix(ref convexToTrans);

				    BridgeTriangleConvexcastCallback tccb = new BridgeTriangleConvexcastCallback(castShape, ref convexFromTrans,ref convexToTrans,resultCallback,collisionObject,triangleMesh, ref colObjWorldTransform);
				    tccb.m_hitFraction = resultCallback.m_closestHitFraction;
				    Vector3 boxMinLocal = new Vector3();
                    Vector3 boxMaxLocal = new Vector3();
				    castShape.GetAabb(ref rotationXform, ref boxMinLocal, ref boxMaxLocal);
				    triangleMesh.PerformConvexCast(tccb,ref convexFromLocal,ref convexToLocal,ref boxMinLocal, ref boxMaxLocal);
			    } 
                else
			    {
				    //BT_PROFILE("convexSweepConcave");
				    ConcaveShape concaveShape = (ConcaveShape)collisionShape;
				    Matrix worldTocollisionObject = Matrix.Invert(colObjWorldTransform);
				    Vector3 convexFromLocal = Vector3.Transform(convexFromTrans.Translation,worldTocollisionObject);
				    Vector3 convexToLocal = Vector3.Transform(convexToTrans.Translation,worldTocollisionObject);
				    // rotation of box in local mesh space = MeshRotation^-1 * ConvexToRotation
                    Matrix rotationXform = MathUtil.BasisMatrix(ref worldTocollisionObject) * MathUtil.BasisMatrix(ref convexToTrans);

                    BridgeTriangleConvexcastCallback2 tccb = new BridgeTriangleConvexcastCallback2(castShape, ref convexFromTrans, ref convexToTrans, resultCallback, collisionObject, concaveShape, ref colObjWorldTransform);
				    tccb.m_hitFraction = resultCallback.m_closestHitFraction;
				    Vector3 boxMinLocal = new Vector3();
                    Vector3 boxMaxLocal = new Vector3();
				    castShape.GetAabb(ref rotationXform, ref boxMinLocal, ref boxMaxLocal);

				    Vector3  rayAabbMinLocal = convexFromLocal;
                    MathUtil.VectorMin(ref convexToLocal,ref rayAabbMinLocal);
                    //rayAabbMinLocal.setMin(convexToLocal);
				    Vector3  rayAabbMaxLocal = convexFromLocal;
                    //rayAabbMaxLocal.setMax(convexToLocal);
                    MathUtil.VectorMax(ref convexToLocal,ref rayAabbMaxLocal);

				    rayAabbMinLocal += boxMinLocal;
				    rayAabbMaxLocal += boxMaxLocal;
				    concaveShape.ProcessAllTriangles(tccb,ref rayAabbMinLocal,ref rayAabbMaxLocal);
			    }
            } 
            else 
            {
			    ///@todo : use AABB tree or other BVH acceleration structure!
			    if (collisionShape.IsCompound())
			    {
                    //BT_PROFILE("convexSweepCompound");
                    CompoundShape compoundShape = (CompoundShape)collisionShape;
				    for (int i=0;i<compoundShape.GetNumChildShapes();i++)
				    {
					    Matrix childTrans = compoundShape.GetChildTransform(i);
					    CollisionShape childCollisionShape = compoundShape.GetChildShape(i);
					    Matrix childWorldTrans = MathUtil.BulletMatrixMultiply(colObjWorldTransform,childTrans);
					    // replace collision shape so that callback can determine the triangle
					    CollisionShape saveCollisionShape = collisionObject.GetCollisionShape();
					    collisionObject.InternalSetTemporaryCollisionShape((CollisionShape)childCollisionShape);

                        LocalInfoAdder my_cb = new LocalInfoAdder(i, resultCallback);
					    my_cb.m_closestHitFraction = resultCallback.m_closestHitFraction;


					    ObjectQuerySingle(castShape, ref convexFromTrans,ref convexToTrans,
						    collisionObject,
						    childCollisionShape,
						    ref childWorldTrans,
						    my_cb, allowedPenetration);
					    // restore
					    collisionObject.InternalSetTemporaryCollisionShape(saveCollisionShape);
				    }
			    }
		    }
	    }
    }
    protected ObjectArray<CollisionObject> m_collisionObjects;
	protected IDispatcher	m_dispatcher1;
    protected DispatcherInfo m_dispatchInfo;

	protected IBroadphaseInterface m_broadphasePairCache;
	protected IDebugDraw m_debugDrawer;
        
    ///m_forceUpdateAllAabbs can be set to false as an optimization to only update active object AABBs
    ///it is true by default, because it is error-prone (setting the position of static objects wouldn't update their AABB)
    protected bool m_forceUpdateAllAabbs;

    public static bool debugCollisionWorld = true;


    protected IProfileManager m_profileManager;
    }


	//ConvexCast::CastResult


	//ConvexCast::CastResult


	//ConvexCast::CastResult
}