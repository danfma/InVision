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


using System;
using System.Collections.Generic;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
    public class CapsuleShape : ConvexInternalShape
    {
        protected CapsuleShape()
        {
            m_shapeType = BroadphaseNativeTypes.CAPSULE_SHAPE_PROXYTYPE;
        }

        public CapsuleShape(float radius,float height) : this()
        {
	        m_upAxis = 1;
	        m_implicitShapeDimensions = new Vector3(radius,0.5f*height,radius);
        }
	    ///CollisionShape Interface
        public override Vector3 CalculateLocalInertia(float mass)
        {
	        Matrix ident = Matrix.Identity;
        	
	        float radius = getRadius();

	        Vector3 halfExtents = new Vector3(radius,radius,radius);
            float val = MathUtil.VectorComponent(ref halfExtents,GetUpAxis());
	        MathUtil.VectorComponent(ref halfExtents,GetUpAxis(),val +getHalfHeight());

	        float margin = CollisionMargin.CONVEX_DISTANCE_MARGIN;

	        float lx=2f*(halfExtents.X+margin);
	        float ly=2f*(halfExtents.Y+margin);
	        float lz=2f*(halfExtents.Z+margin);
	        float x2 = lx*lx;
	        float y2 = ly*ly;
	        float z2 = lz*lz;
	        float scaledmass = mass * 0.08333333f;

	        return scaledmass * (new Vector3(y2+z2,x2+z2,x2+y2));
        }

    	public override float Margin
    	{
    		set
    		{
    			//correct the m_implicitShapeDimensions for the margin
    			Vector3 oldMargin = new Vector3(Margin, Margin, Margin);
    			Vector3 implicitShapeDimensionsWithMargin = m_implicitShapeDimensions + oldMargin;

    			base.Margin = value;
    			Vector3 newMargin = new Vector3(Margin, Margin, Margin);
    			m_implicitShapeDimensions = implicitShapeDimensionsWithMargin - newMargin;
    		}
    	}

    	public override void SetLocalScaling(ref Vector3 scaling)
	    {
		    Vector3 oldMargin = new Vector3(Margin,Margin,Margin);
		    Vector3 implicitShapeDimensionsWithMargin = m_implicitShapeDimensions+oldMargin;
		    Vector3 unScaledImplicitShapeDimensionsWithMargin = implicitShapeDimensionsWithMargin / m_localScaling;

		    base.SetLocalScaling(ref scaling);

		    m_implicitShapeDimensions = (unScaledImplicitShapeDimensionsWithMargin * m_localScaling) - oldMargin;

	    }


	    /// btConvexShape Interface
        public override Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 vec0)
        {
	        Vector3 supVec = Vector3.Zero;
	        float maxDot = float.MinValue;

	        Vector3 vec = vec0;
	        float lenSqr = vec.LengthSquared();
	        if (lenSqr < 0.0001f)
	        {
		        vec = Vector3.Right;
	        } 
            else
	        {
		        float rlen = (1.0f) / (float)System.Math.Sqrt(lenSqr );
		        vec *= rlen;
              //vec.Normalize();
	        }

	        Vector3 vtx = new Vector3();
	        float newDot;
        	
	        float radius = getRadius();

	        {
		        Vector3 pos = Vector3.Zero;
		        MathUtil.VectorComponent(ref pos,GetUpAxis(),getHalfHeight());

		        vtx = pos +vec*m_localScaling*(radius) - vec * Margin;
		        newDot = Vector3.Dot(vec,vtx);
		        if (newDot > maxDot)
		        {
			        maxDot = newDot;
			        supVec = vtx;
		        }
	        }
	        {
                Vector3 pos = Vector3.Zero;
                MathUtil.VectorComponent(ref pos, GetUpAxis(), -getHalfHeight());

                vtx = pos + vec * m_localScaling * (radius) - vec * Margin;
                newDot = Vector3.Dot(vec, vtx);
                if (newDot > maxDot)
                {
                    maxDot = newDot;
                    supVec = vtx;
                }
            }

	        return supVec;
        }

        public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors, IList<Vector4> supportVerticesOut, int numVectors)
        {
	        float radius = getRadius();

	        for (int j=0;j<numVectors;j++)
	        {
		        float maxDot = float.MinValue;
		        Vector3 vec = vectors[j];

		        Vector3 vtx = new Vector3();
		        float newDot = 0f;
	            {
		            Vector3 pos = Vector3.Zero;
		            MathUtil.VectorComponent(ref pos,GetUpAxis(),getHalfHeight());

		            vtx = pos +vec*m_localScaling*(radius) - vec * Margin;
		            newDot = Vector3.Dot(vec,vtx);
		            if (newDot > maxDot)
		            {
			            maxDot = newDot;
			            supportVerticesOut[j] = new Vector4(vtx,0);
		            }
	            }
	            {
                    Vector3 pos = Vector3.Zero;
                    MathUtil.VectorComponent(ref pos, GetUpAxis(), -getHalfHeight());

                    vtx = pos + vec * m_localScaling * (radius) - vec * Margin;
                    newDot = Vector3.Dot(vec, vtx);
                    if (newDot > maxDot)
                    {
                        maxDot = newDot;
			            supportVerticesOut[j] = new Vector4(vtx,0);
                    }
                }
	        }
        }
	
	    public override void GetAabb (ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax)
	    {
	        Vector3 halfExtents = new Vector3(getRadius(),getRadius(),getRadius());
	        MathUtil.VectorComponent(ref halfExtents,m_upAxis, getRadius() + getHalfHeight());
	        halfExtents += new Vector3(Margin,Margin,Margin);
            Matrix abs_b = Matrix.Identity;
            MathUtil.AbsoluteMatrix(ref trans, ref abs_b);
            Vector3 center = trans.Translation;
            Vector3 extent = new Vector3(Vector3.Dot(abs_b.Right, halfExtents),
                                            Vector3.Dot(abs_b.Up, halfExtents),
                                            Vector3.Dot(abs_b.Backward, halfExtents));
    		
	        aabbMin = center - extent;
	        aabbMax = center + extent;

        }

    	public override string Name
    	{
    		get { return "CapsuleShape"; }
    	}

    	public int GetUpAxis()
	    {
		    return m_upAxis;
	    }

	    public float getRadius()
	    {
		    int radiusAxis = (m_upAxis+2)%3;
		    return MathUtil.VectorComponent(ref m_implicitShapeDimensions,radiusAxis);
	    }

	    public float getHalfHeight()
	    {
            return MathUtil.VectorComponent(ref m_implicitShapeDimensions,m_upAxis);
	    }
        protected int m_upAxis;

    }
}
