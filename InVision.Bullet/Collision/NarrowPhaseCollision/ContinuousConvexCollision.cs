﻿/*
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

using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
    public class ContinuousConvexCollision : IConvexCast
    {
        public ContinuousConvexCollision(ConvexShape shapeA, ConvexShape shapeB, ISimplexSolverInterface simplexSolver, IConvexPenetrationDepthSolver penetrationDepthSolver)
        {
            m_convexA = shapeA;
            m_convexB = shapeB;
            m_simplexSolver = simplexSolver;
            m_penetrationDepthSolver = penetrationDepthSolver;

        }

        public virtual bool CalcTimeOfImpact(ref Matrix fromA, ref Matrix toA, ref Matrix fromB, ref Matrix toB, CastResult result)
        {
	        m_simplexSolver.Reset();

	        /// compute linear and angular velocity for this interval, to interpolate
            Vector3 linVelA = Vector3.Zero, angVelA = Vector3.Zero, linVelB = Vector3.Zero, angVelB = Vector3.Zero;
	        TransformUtil.CalculateVelocity(ref fromA,ref toA,1f,ref linVelA,ref angVelA);
	        TransformUtil.CalculateVelocity(ref fromB,ref toB,1f,ref linVelB,ref angVelB);

	        float boundingRadiusA = m_convexA.GetAngularMotionDisc();
	        float boundingRadiusB = m_convexB.GetAngularMotionDisc();

	        float maxAngularProjectedVelocity = angVelA.Length() * boundingRadiusA + angVelB.Length() * boundingRadiusB;
	        Vector3 relLinVel = (linVelB-linVelA);
    
	        float relLinVelocLength = relLinVel.Length();

            if (MathUtil.FuzzyZero(relLinVelocLength + maxAngularProjectedVelocity))
            {
		        return false;
            }


    	    float radius = 0.001f;

	        float lambda = 0f;
	        Vector3 v = new Vector3(1,0,0);

	        int maxIter = MAX_ITERATIONS;

	        Vector3 n = Vector3.Zero;
    
	        bool hasResult = false;
	        Vector3 c;

	        float lastLambda = lambda;
	        //btScalar epsilon = btScalar(0.001);

        	int numIter = 0;
	        //first solution, using GJK


	        Matrix identityTrans = Matrix.Identity;

	        SphereShape	raySphere = new SphereShape(0f);
	        raySphere.Margin = 0f;


            //	result.drawCoordSystem(sphereTr);

	        PointCollector	pointCollector1 = new PointCollector();

	        {
		        GjkPairDetector gjk = new GjkPairDetector(m_convexA,m_convexB,m_simplexSolver,m_penetrationDepthSolver);		
		        ClosestPointInput input = new ClosestPointInput();
	
		        //we don't use margins during CCD
	        //	gjk.setIgnoreMargin(true);

		        input.m_transformA = fromA;
		        input.m_transformB = fromB;
		        gjk.GetClosestPoints(input,pointCollector1,null,false);

		        hasResult = pointCollector1.m_hasResult;
		        c = pointCollector1.m_pointInWorld;
	        }

	        if (hasResult)
	        {
		        float dist = pointCollector1.m_distance;
		        n = pointCollector1.m_normalOnBInWorld;

		        float projectedLinearVelocity = Vector3.Dot(relLinVel,n);
        		
		        //not close enough
		        while (dist > radius)
		        {
                    if (result.m_debugDrawer != null)
                    {
                        Vector3 colour = new Vector3(1, 1, 1);
                        result.m_debugDrawer.DrawSphere(ref c, 0.2f, ref colour);
                    } 
                    numIter++;
			        if (numIter > maxIter)
			        {
				        return false; //todo: report a failure
			        }
			        float dLambda = 0f;

			        projectedLinearVelocity = Vector3.Dot(relLinVel,n);

			        //calculate safe moving fraction from distance / (linear+rotational velocity)
        			
			        //btScalar clippedDist  = GEN_min(angularConservativeRadius,dist);
			        //btScalar clippedDist  = dist;
        			
			        //don't report time of impact for motion away from the contact normal (or causes minor penetration)
			        if ((projectedLinearVelocity+ maxAngularProjectedVelocity)<=MathUtil.SIMD_EPSILON)
                    {
				        return false;
        			}
			        dLambda = dist / (projectedLinearVelocity+ maxAngularProjectedVelocity);
        			
			        lambda = lambda + dLambda;

			        if (lambda > 1f || lambda < 0f)
                    {
				        return false;
                    }


			        //todo: next check with relative epsilon
			        if (lambda <= lastLambda)
			        {
				        return false;
				        //n.setValue(0,0,0);
			        }
			        
                    lastLambda = lambda;

			        //interpolate to next lambda
                    Matrix interpolatedTransA = Matrix.Identity, interpolatedTransB = Matrix.Identity, relativeTrans = Matrix.Identity;

			        TransformUtil.IntegrateTransform(ref fromA,ref linVelA,ref angVelA,lambda,ref interpolatedTransA);
			        TransformUtil.IntegrateTransform(ref fromB,ref linVelB,ref angVelB,lambda,ref interpolatedTransB);
                    //relativeTrans = interpolatedTransB.inverseTimes(interpolatedTransA);
                    relativeTrans = MathUtil.InverseTimes(ref interpolatedTransB, ref interpolatedTransA);
                    if (result.m_debugDrawer != null)
                    {
                        result.m_debugDrawer.DrawSphere(interpolatedTransA.Translation, 0.2f, new Vector3(1, 0, 0));
                    }
			        result.DebugDraw( lambda );

			        PointCollector	pointCollector = new PointCollector();
			        GjkPairDetector gjk = new GjkPairDetector(m_convexA,m_convexB,m_simplexSolver,m_penetrationDepthSolver);
			        ClosestPointInput input = new ClosestPointInput();
			        input.m_transformA = interpolatedTransA;
			        input.m_transformB = interpolatedTransB;
			        gjk.GetClosestPoints(input,pointCollector,null,false);
			        if (pointCollector.m_hasResult)
			        {
				        if (pointCollector.m_distance < 0f)
				        {
					        //degenerate ?!
					        result.m_fraction = lastLambda;
					        n = pointCollector.m_normalOnBInWorld;
					        result.m_normal=n;//.setValue(1,1,1);// = n;
					        result.m_hitPoint = pointCollector.m_pointInWorld;
					        return true;
				        }
				        c = pointCollector.m_pointInWorld;		
				        n = pointCollector.m_normalOnBInWorld;
				        dist = pointCollector.m_distance;
			        } else
			        {
				        //??
				        return false;
			        }

		        }

                if ((projectedLinearVelocity + maxAngularProjectedVelocity) <= result.m_allowedPenetration)//SIMD_EPSILON)
                {
                    return false;
                }
        	
		        result.m_fraction = lambda;
		        result.m_normal = n;
		        result.m_hitPoint = c;
		        return true;
	        }

	        return false;

        /*
        //todo:
	        //if movement away from normal, discard result
	        btVector3 move = transBLocalTo.getOrigin() - transBLocalFrom.getOrigin();
	        if (result.m_fraction < btScalar(1.))
	        {
		        if (move.dot(result.m_normal) <= btScalar(0.))
		        {
		        }
	        }
        */


        }

        private ISimplexSolverInterface m_simplexSolver;
	    private IConvexPenetrationDepthSolver m_penetrationDepthSolver;
        private ConvexShape m_convexA;
        private ConvexShape m_convexB;
        private static int MAX_ITERATIONS = 64;
    }
}
