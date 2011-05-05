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

using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public abstract class TriangleRaycastCallback : ITriangleCallback
    {
        public TriangleRaycastCallback(ref Vector3 from, ref Vector3 to, EFlags flags)
        {
            m_from = from;
            m_to = to;
            m_flags = flags;
            m_hitFraction = 1f;
        }

        public virtual void ProcessTriangle(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
        {
            Vector3[] raw = triangle.GetRawArray();

            Vector3 v10;
            Vector3 v20;
            
            Vector3.Subtract(ref raw[1],ref raw[0],out v10);
            Vector3.Subtract(ref raw[2],ref raw[0],out v20);

            Vector3 triangleNormal;
            Vector3.Cross(ref v10,ref v20,out triangleNormal);

            float dist;
            Vector3.Dot(ref raw[0],ref triangleNormal,out dist);
            float dist_a;
            Vector3.Dot(ref triangleNormal,ref m_from,out dist_a);
            dist_a -= dist;
            float dist_b;
            Vector3.Dot(ref triangleNormal,ref m_to,out dist_b);
            dist_b -= dist;

            if (dist_a * dist_b >= 0f)
            {
                return; // same sign
            }
            //@BP Mod - Backface filtering
            if (((m_flags & EFlags.kF_FilterBackfaces) != 0) && (dist_a > 0f))
            {
                // Backface, skip check
                return;
            }

            float proj_length = dist_a - dist_b;
            float distance = (dist_a) / (proj_length);
            // Now we have the intersection point on the plane, we'll see if it's inside the triangle
            // Add an epsilon as a tolerance for the raycast,
            // in case the ray hits exacly on the edge of the triangle.
            // It must be scaled for the triangle size.

            if (distance < m_hitFraction)
            {
                float edge_tolerance = triangleNormal.LengthSquared();
                edge_tolerance *= -0.0001f;
                Vector3 point; 
                point = MathUtil.Interpolate3(ref m_from, ref m_to, distance);
                {
                    Vector3 v0p;
                    Vector3.Subtract(ref raw[0],ref point,out v0p);
                    Vector3 v1p;
                    Vector3.Subtract(ref raw[1],ref point,out v1p);

                    Vector3 cp0;
                    Vector3.Cross(ref v0p,ref v1p,out cp0);

                    float dot;
                    Vector3.Dot(ref cp0, ref triangleNormal, out dot);
                    if (dot >= edge_tolerance)
                    {
                        Vector3 v2p;
                        Vector3.Subtract(ref raw[2],ref point,out v2p);
                        Vector3 cp1; //= Vector3.Cross(v1p,v2p);
                        Vector3.Cross(ref v1p, ref v2p, out cp1);

                        float dot2;
                        Vector3.Dot(ref cp1, ref triangleNormal, out dot2);

                        if (dot2 >= edge_tolerance)
                        {
                            Vector3 cp2;
                            Vector3.Cross(ref v2p, ref v0p, out cp2);
                            float dot3;
                            Vector3.Dot(ref cp2, ref triangleNormal, out dot3);

                            if (dot3 >= edge_tolerance)
                            {
                                //@BP Mod
                                // Triangle normal isn't normalized
                                triangleNormal.Normalize();

                                //@BP Mod - Allow for unflipped normal when raycasting against backfaces
                                if (((m_flags & EFlags.kF_KeepUnflippedNormal) != 0) || (dist_a <= 0.0f))
                                {
                                    Vector3 negNormal = -triangleNormal;
                                    m_hitFraction = ReportHit(ref negNormal, distance, partId, triangleIndex);
                                }
                                else
                                {
                                    m_hitFraction = ReportHit(ref triangleNormal, distance, partId, triangleIndex);
                                }
                            }
                        }
                    }
                }
            }
        }

	    public abstract float ReportHit(ref Vector3 hitNormalLocal, float hitFraction, int partId, int triangleIndex );

        public virtual void Cleanup()
        {
        }

        public Vector3 m_from;
        public Vector3 m_to;
        public EFlags m_flags;
        public float m_hitFraction;

    }
}
