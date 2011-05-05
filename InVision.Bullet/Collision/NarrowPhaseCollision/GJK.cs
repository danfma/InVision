using System;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class GJK
	{
		public GJK()
		{
			Initialise();
		}
        
		public void Initialise()
		{
			m_ray = Vector3.Zero;
			m_nfree		=	0;
			m_status	=	GJKStatus.Failed;
			m_current	=	0;
			m_distance	=	0f;
			for (int i = 0; i < m_simplices.Length; ++i)
			{
				m_simplices[i] = new sSimplex();
			}

			for (int i = 0; i < m_store.Length; ++i)
			{
				m_store[i] = new sSV();
			}
			// Free is a list of pointers/references so doesn't need objects.
			//for (int i = 0; i < m_free.Length; ++i)
			//{
			//    m_free[i] = new sSV();
			//}
		}

		public GJKStatus Evaluate(GjkEpaSolver2MinkowskiDiff shapearg, ref Vector3 guess)
		{
			uint iterations=0;
			float sqdist=0f;
			float alpha=0f;
			Vector3[] lastw = new Vector3[4];
			uint clastw=0;
			/* Initialize solver		*/ 
			m_free[0] =	m_store[0];
			m_free[1] =	m_store[1];
			m_free[2] =	m_store[2];
			m_free[3] =	m_store[3];
			m_nfree	= 4;
			m_current =	0;
			m_status = GJKStatus.Valid;
			m_shape	= shapearg;
			m_distance = 0f;
			/* Initialize simplex		*/ 
			m_simplices[0].rank	= 0;
			m_ray =	guess;
			float sqrl=	m_ray.LengthSquared();
			Vector3 temp = sqrl>0?-m_ray:new Vector3(1,0,0);
			AppendVertice(m_simplices[0],ref temp);
			m_simplices[0].p[0]	= 1;
			m_ray =	m_simplices[0].c[0].w;	
			sqdist =	sqrl;
			lastw[0]=lastw[1]=lastw[2]=lastw[3]	=	m_ray;
			/* Loop						*/ 
			do	
			{
				uint next = 1-m_current;
				sSimplex cs = m_simplices[m_current];
				sSimplex ns = m_simplices[next];
				/* Check zero							*/ 
				float rl=m_ray.Length();
				if (rl < GjkEpaSolver2.GJK_MIN_DISTANCE)
				{/* Touching or inside				*/ 
					m_status=GJKStatus.Inside;
					break;
				}
				/* Append new vertice in -'v' direction	*/ 
				Vector3 temp2 = -m_ray;
				AppendVertice(cs,ref temp2);
				Vector3	w = cs.c[cs.rank-1].w;
				bool found = false;
				for(int i=0;i<4;++i)
				{
					if ((w - lastw[i]).LengthSquared() < GjkEpaSolver2.GJK_DUPLICATED_EPS)
					{ 
						found=true;
						break; 
					}
				}
				if(found)
				{/* Return old simplex				*/ 
					RemoveVertice(m_simplices[m_current]);
					break;
				}
				else
				{/* Update lastw					*/ 
					lastw[clastw=(clastw+1)&3]=w;
				}
				/* Check for termination				*/ 
				float omega=Vector3.Dot(m_ray,w)/rl;
				alpha=System.Math.Max(omega,alpha);
				if (((rl - alpha) - (GjkEpaSolver2.GJK_ACCURARY * rl)) <= 0)
				{/* Return old simplex				*/ 
					RemoveVertice(m_simplices[m_current]);
					break;
				}		

				/* Reduce simplex						*/ 
				Vector4 weights = new Vector4();
				uint mask=0;
				switch(cs.rank)
				{
					case 2 :
						{
							sqdist=GJK.ProjectOrigin(ref cs.c[0].w,ref cs.c[1].w,ref weights,ref mask);
							break;
						}
					case 3:
						{
							sqdist = GJK.ProjectOrigin(ref cs.c[0].w, ref cs.c[1].w, ref cs.c[2].w, ref weights, ref mask);
							break;
						}
					case 4:
						{
							sqdist = GJK.ProjectOrigin(ref cs.c[0].w, ref cs.c[1].w, ref cs.c[2].w, ref cs.c[3].w, ref weights, ref mask);
							break;
						}
				}
				if(sqdist>=0)
				{/* Valid	*/ 
					ns.rank	= 0;
					m_ray =	Vector3.Zero;
					m_current =	next;
					for(uint i=0,ni=cs.rank;i<ni;++i)
					{
						if((mask&(1<<(int)i)) != 0)
						{
							ns.c[ns.rank] =	cs.c[i];
							float weight = MathUtil.VectorComponent(ref weights, (int)i);
							ns.p[ns.rank++]	= weight;
							m_ray += cs.c[i].w * weight;
						}
						else
						{
							m_free[m_nfree++] =	cs.c[i];
						}
					}
					if(mask==15)
					{
						m_status=GJKStatus.Inside;
					}
				}
				else
				{/* Return old simplex				*/ 
					RemoveVertice(m_simplices[m_current]);
					break;
				}
				m_status = ((++iterations) < GjkEpaSolver2.GJK_MAX_ITERATIONS) ? m_status : GJKStatus.Failed;
			} while(m_status==GJKStatus.Valid);

			m_simplex = m_simplices[m_current];
			
			switch(m_status)
			{
				case	GJKStatus.Valid:
					{
						m_distance=m_ray.Length();
						break;
					}
				case	GJKStatus.Inside:	
					{
						m_distance=0;
						break;
					}
			}


			if (BulletGlobals.g_streamWriter != null && GjkEpaSolver2.debugGJK)
			{
				BulletGlobals.g_streamWriter.WriteLine(String.Format("gjk eval dist[{0}]", m_distance));
			}


			return(m_status);
		}


		public bool	EncloseOrigin()
		{
			switch(m_simplex.rank)
			{
				case	1:
					{
						for(int i=0;i<3;++i)
						{
							Vector3 axis= Vector3.Zero;
							MathUtil.VectorComponent(ref axis,i,1f);
							AppendVertice(m_simplex, ref axis);
							if(EncloseOrigin())
							{
								return(true);
							}
							RemoveVertice(m_simplex);
							Vector3 temp = -axis;
							AppendVertice(m_simplex,ref temp);
							if(EncloseOrigin())	
							{
								return(true);
							}
							RemoveVertice(m_simplex);
						}
						break;
					}
				case	2:
					{
						Vector3	d=m_simplex.c[1].w-m_simplex.c[0].w;
						for(int i=0;i<3;++i)
						{
							Vector3 axis= Vector3.Zero;
							MathUtil.VectorComponent(ref axis,i,1f);
							Vector3	p= Vector3.Cross(d,axis);
							if(p.LengthSquared()>0)
							{
								AppendVertice(m_simplex, ref p);
								if(EncloseOrigin())
								{
									return(true);
								}
								RemoveVertice(m_simplex);
								Vector3 temp = -p;
								AppendVertice(m_simplex,ref temp);
								if(EncloseOrigin())
								{
									return(true);
								}
								RemoveVertice(m_simplex);
							}
						}
						break;
					}
				case 3:
					{
						Vector3	n = Vector3.Cross(m_simplex.c[1].w-m_simplex.c[0].w,
						       	                  m_simplex.c[2].w-m_simplex.c[0].w);
						if(n.LengthSquared()>0)
						{
							AppendVertice(m_simplex,ref n);
							if(EncloseOrigin())	
							{
								return(true);
							}
							RemoveVertice(m_simplex);
							Vector3 temp = -n;
							AppendVertice(m_simplex,ref temp);
							if(EncloseOrigin())
							{
								return(true);
							}
							RemoveVertice(m_simplex);
						}
						break;
					}
				case 4:
					{
						if (System.Math.Abs(GJK.Det(m_simplex.c[0].w - m_simplex.c[3].w,
						                            m_simplex.c[1].w-m_simplex.c[3].w,
						                            m_simplex.c[2].w-m_simplex.c[3].w))>0)
							return(true);
						break;
					}
				default:
					{
						break;
					}
			}
			return(false);
		}

		public void	GetSupport(ref Vector3 d,ref sSV sv)
		{
			sv.d = d/d.Length();
			sv.w = m_shape.Support(ref sv.d);
		}
		public void RemoveVertice(sSimplex simplex)
		{
			m_free[m_nfree++]=simplex.c[--simplex.rank];
		}

		public void AppendVertice(sSimplex simplex,ref Vector3 v)
		{
			simplex.p[simplex.rank]=0;
			simplex.c[simplex.rank]=m_free[--m_nfree];
			GetSupport(ref v,ref simplex.c[simplex.rank++]);
		}


		public static float Det(Vector3 a, Vector3 b, Vector3 c)
		{
			return Det(ref a, ref b, ref c);
		}

		public static float Det(ref Vector3 a,ref Vector3 b,ref Vector3 c)
		{
			return(	a.Y*b.Z*c.X+a.Z*b.X*c.Y-
			       	a.X*b.Z*c.Y-a.Y*b.X*c.Z+
			       	a.X*b.Y*c.Z-a.Z*b.Y*c.X);
		}

		public static float ProjectOrigin(ref Vector3 a,ref Vector3 b,ref Vector4 w,ref uint m)
		{
			Vector3	d=b-a;
			float l=d.LengthSquared();
			if (l > GjkEpaSolver2.GJK_SIMPLEX2_EPS)
			{
				float t = (l>0f?(-Vector3.Dot(a,d)/l):0f);
				if(t>=1)		
				{ 
					w.X=0f;
					w.Y=1f;
					m=2;
					return b.LengthSquared(); 
				}
				else if(t<=0)	
				{ 
					w.X=1f;
					w.Y=0f;
					m=1;
					return a.LengthSquared(); 
				}
				else
				{ 
					w.X=1-(w.Y=t);
					m=3;
					return (a+d*t).LengthSquared(); 
				}
			}
			return(-1);
		}


		public static float ProjectOrigin(ref Vector3 a,
		                                  ref Vector3 b,
		                                  ref Vector3 c,
		                                  ref Vector4 w,ref uint m)
		{
			uint[] imd3 = {1,2,0};
			Vector3[] vt  = {a,b,c};
			Vector3[] dl = {a-b,b-c,c-a};
			Vector3	n= Vector3.Cross(dl[0],dl[1]);
			float l=n.LengthSquared();
			if (l > GjkEpaSolver2.GJK_SIMPLEX3_EPS)
			{
				float mindist=-1f;
				Vector4 subw = new Vector4();
				uint subm = 0;
				for(int i=0;i<3;++i)
				{
					if(Vector3.Dot(vt[i],Vector3.Cross(dl[i],n))>0)
					{
						uint j = imd3[i];
						float subd = GJK.ProjectOrigin(ref vt[i],ref vt[j],ref subw,ref subm);
						if((mindist<0)||(subd<mindist))
						{
							mindist	= subd;
							m =	(uint)((((subm&1) != 0)?1<<i:0)+(((subm&2)!=0)?1<<(int)j:0));

							MathUtil.VectorComponent(ref w,(int)i, subw.X);
							MathUtil.VectorComponent(ref w,(int)j, subw.Y);
							MathUtil.VectorComponent(ref w,(int)imd3[j],0f);				
						}
					}
				}
				if(mindist<0)
				{
					float d = Vector3.Dot(a,n);	
					float s = (float)System.Math.Sqrt(l);
					Vector3	p = n * (d/l);
					mindist	=	p.LengthSquared();
					m =	7;
					w.X	= (Vector3.Cross(dl[1],b-p)).Length()/s;
					w.Y	= (Vector3.Cross(dl[2],c-p)).Length()/s;
					w.Z	= 1-(w.X+w.Y);
				}
				return(mindist);
			}
			return(-1);
		}

		public static float ProjectOrigin(ref Vector3 a,
		                                  ref Vector3 b,
		                                  ref Vector3 c,
		                                  ref Vector3 d,
		                                  ref Vector4 w,ref uint m)
		{
			uint[] imd3 ={1,2,0};
			Vector3[]	vt = {a,b,c,d};
			Vector3[]	dl= {a-d,b-d,c-d};
			float vl= Det(dl[0],dl[1],dl[2]);
            
			bool ng=(vl*Vector3.Dot(a,Vector3.Cross(b-c,a-b)))<=0;
			if (ng && (System.Math.Abs(vl) > GjkEpaSolver2.GJK_SIMPLEX4_EPS))
			{
				float mindist=-1;
				Vector4 subw = new Vector4();
				uint subm = 0;
				for(int i=0;i<3;++i)
				{
					uint j= imd3[i];
					float s=vl*Vector3.Dot(d,Vector3.Cross(dl[i],dl[j]));
					if(s>0)
					{
						float subd=GJK.ProjectOrigin(ref vt[i],ref vt[j],ref d,ref subw,ref subm);
						if((mindist<0)||(subd<mindist))
						{
							mindist		=	subd;
							m			=	(uint)((((subm&1) != 0)?1<<i:0)+
							 			 	       (((subm&2)!=0)?1<<(int)j:0)+
							 			 	       (((subm&4)!=0)?8:0));
							MathUtil.VectorComponent(ref w,i,subw.X);
							MathUtil.VectorComponent(ref w,(int)j,subw.Y);
							MathUtil.VectorComponent(ref w,(int)imd3[j],0f);
							w.W = subw.Z;
						}
					}
				}
				if(mindist<0)
				{
					mindist	=	0;
					m		=	15;
					w.X	=	Det(c,b,d)/vl;
					w.Y	=	Det(a,c,d)/vl;
					w.Z	=	Det(b,a,d)/vl;
					w.W	=	1-(w.X+w.Y+w.Z);
				}
				return(mindist);
			}
			return(-1);
		}

		public GjkEpaSolver2MinkowskiDiff m_shape;
		public Vector3 m_ray;
		public float m_distance;
		public sSimplex[] m_simplices = new sSimplex[2];
		public sSV[] m_store = new sSV[4];
		public sSV[] m_free = new sSV[4];
		public uint m_nfree;
		public uint m_current;
		public sSimplex m_simplex = new sSimplex();
		public GJKStatus m_status;
	}
}