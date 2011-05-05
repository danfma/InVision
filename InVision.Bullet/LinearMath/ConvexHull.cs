/*
 * 
 * * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
 
Stan Melax Convex Hull Computation
Copyright (c) 2003-2006 Stan Melax http://www.melax.com/

This software is provided 'as-is', without any express or implied warranty.
In no event will the authors be held liable for any damages arising from the use of this software.
Permission is granted to anyone to use this software for any purpose, 
including commercial applications, and to alter it and redistribute it freely, 
subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.
*/

using System.Diagnostics;

namespace InVision.Bullet.LinearMath
{

    //#include <string.h>

//#include "btConvexHull.h"
//#include "LinearMath/List.h"
//#include "LinearMath/btMinMax.h"
//#include "LinearMath/Vector3.h"

    public class ConvexHull
    {
    }



//template <class T>
//void Swap(T &a,T &b)
//{
//    T tmp = a;
//    a=b;
//    b=tmp;
//}


//----------------------------------

//------- Plane ----------


//public static Plane PlaneFlip(Plane &plane){return Plane(-plane.normal,-plane.dist);}
//inline int operator==( Plane &a, Plane &b ) { return (a.normal==b.normal && a.dist==b.dist); }
//inline int coplanar( Plane &a, Plane &b ) { return (a==b || a==PlaneFlip(b)); }


//--------- Utility Functions ------

//Vector3  PlaneLineIntersection(Plane plane, Vector3 p0, Vector3 p1);
//Vector3  PlaneProject(Plane plane, Vector3 point);

//Vector3  ThreePlaneIntersection(Plane p0,Plane p1, Plane p2);

//float   DistanceBetweenLines(ref Vector3 ustart, ref Vector3 udir, ref Vector3 vstart, ref Vector3 vdir, Vector3 *upoint=NULL, Vector3 *vpoint=NULL);
//Vector3  TriNormal(ref Vector3 v0, ref Vector3 v1, ref Vector3 v2);
//Vector3  NormalOf(Vector3 *vert, int n);


	//typedef ConvexH::HalfEdge HalfEdge;


//int operator ==(int3 &a,int3 &b);
//int operator ==(int3 &a,int3 &b) 
//{
//    for(int i=0;i<3;i++) 
//    {
//        if(a[i]!=b[i]) return 0;
//    }
//    return 1;
//}


//int above(Vector3* vertices,int3& t, ref Vector3 p, float epsilon);
}