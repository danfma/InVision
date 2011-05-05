using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class EPA
	{
		/* Fields		*/ 
		public eStatus	m_status;
		public sSimplex	m_result;
		public Vector3	m_normal;
		public float m_depth;
		public sSV[] m_sv_store = new sSV[GjkEpaSolver2.EPA_MAX_VERTICES];
		public sFace[] m_fc_store = new sFace[GjkEpaSolver2.EPA_MAX_FACES];
		public uint m_nextsv;
		public IList<sFace> m_hull = new List<sFace>();
		public IList<sFace> m_stock = new List<sFace>();
		/* Methods		*/ 
		public EPA()
		{
			Initialize();	
		}


		public void Initialize()
		{
			m_status = eStatus.Failed;
			m_normal = Vector3.Zero;
			m_depth = 0;
			m_nextsv = 0;
			m_result = new sSimplex();

			for (int i = 0; i < m_sv_store.Length; ++i)
			{
				m_sv_store[i] = new sSV();
			}

			for (int i = 0; i < m_fc_store.Length; ++i)
			{
				m_fc_store[i] = new sFace();
			}

			for (int i = 0; i < GjkEpaSolver2.EPA_MAX_FACES; ++i)
			{
				Append(m_stock, m_fc_store[GjkEpaSolver2.EPA_MAX_FACES - i - 1]);
			}
		}


		public static void Bind(sFace fa,uint ea,sFace fb,uint eb)
		{
			fa.e[ea]=(uint)eb;fa.f[ea]=fb;
			fb.e[eb]=(uint)ea;fb.f[eb]=fa;
		}
		public static void Append(IList<sFace> list,sFace face)
		{
			//face.l[0]	=	null;
			//face.l[1]	=	list[0];
			//if(list.Count > 0)
			//{
			//    list[0].l[0]=face;
			//}
			//list.root	=	face;
			//++list.count;
			list.Add(face);
		}
		public static void Remove(IList<sFace> list,sFace face)
		{
			//if(face->l[1]) face->l[1]->l[0]=face->l[0];
			//if(face->l[0]) face->l[0]->l[1]=face->l[1];
			//if(face==list.root) list.root=face->l[1];
			//--list.count;
			list.Remove(face);
		}

		private void SwapSv(sSV[] array, int a, int b)
		{
			sSV temp = array[a];
			array[a] = array[b];
			array[b] = temp;
		}

		private void SwapFloat(float[] array, int a, int b)
		{
			float temp = array[a];
			array[a] = array[b];
			array[b] = temp;
		}

		public eStatus Evaluate(GJK gjk,ref Vector3 guess)
		{
			sSimplex simplex=gjk.m_simplex;
			if((simplex.rank>1)&&gjk.EncloseOrigin())
			{
				/* Clean up				*/ 
				while(m_hull.Count > 0)
				{
					sFace	f = m_hull[0];
					Remove(m_hull,f);
					Append(m_stock,f);
				}

				m_status = eStatus.Valid;
				m_nextsv = 0;
				/* Orient simplex		*/ 
				if(GJK.Det(	simplex.c[0].w-simplex.c[3].w,
				           	simplex.c[1].w-simplex.c[3].w,
				           	simplex.c[2].w-simplex.c[3].w)<0)
				{
					SwapSv(simplex.c,0,1);
					SwapFloat(simplex.p,0,1);
				}
				/* Build initial hull	*/ 
				sFace[]	tetra ={NewFace(simplex.c[0],simplex.c[1],simplex.c[2],true),
				       	        NewFace(simplex.c[1],simplex.c[0],simplex.c[3],true),
				       	        NewFace(simplex.c[2],simplex.c[1],simplex.c[3],true),
				       	        NewFace(simplex.c[0],simplex.c[2],simplex.c[3],true)};
				if(m_hull.Count==4)
				{
					sFace best=FindBest();
					sFace outer = best;
					uint pass=0;
					uint iterations=0;
					Bind(tetra[0],0,tetra[1],0);
					Bind(tetra[0],1,tetra[2],0);
					Bind(tetra[0],2,tetra[3],0);
					Bind(tetra[1],1,tetra[3],2);
					Bind(tetra[1],2,tetra[2],1);
					Bind(tetra[2],2,tetra[3],1);
					m_status=eStatus.Valid;
					for (; iterations < GjkEpaSolver2.EPA_MAX_ITERATIONS; ++iterations)
					{
						if (m_nextsv < GjkEpaSolver2.EPA_MAX_VERTICES)
						{
							sHorizon horizon = new sHorizon() ;
							sSV	w = m_sv_store[m_nextsv++];
							bool valid = true;					
							best.pass =	(uint)(++pass);
							gjk.GetSupport(ref best.n,ref w);
							float wdist=Vector3.Dot(best.n,w.w)-best.d;
							if (wdist > GjkEpaSolver2.EPA_ACCURACY)
							{
								for(int j=0;(j<3)&&valid;++j)
								{
									valid&=Expand(	pass,w,
									              	best.f[j],best.e[j],
									              	horizon);
								}
								if(valid&&(horizon.nf>=3))
								{
									Bind(horizon.cf,1,horizon.ff,2);
									Remove(m_hull,best);
									Append(m_stock,best);
									best=FindBest();
									if (best.p >= outer.p)
									{
										outer = best;
									}
								} 
								else 
								{ 
									m_status=eStatus.InvalidHull;
									break; 
								}
							} 
							else 
							{ 
								m_status=eStatus.AccuraryReached;
								break; 
							}
						} 
						else 
						{ 
							m_status=eStatus.OutOfVertices;
							break; 
						}
					}
					Vector3	projection=outer.n*outer.d;
					m_normal	=	outer.n;
					m_depth		=	outer.d;
					m_result.rank	=	3;
					m_result.c[0]	=	outer.c[0];
					m_result.c[1]	=	outer.c[1];
					m_result.c[2]	=	outer.c[2];
					m_result.p[0]	=	Vector3.Cross(	outer.c[1].w-projection,
					             	 	              	outer.c[2].w-projection).Length();
					m_result.p[1] = Vector3.Cross(outer.c[2].w - projection,
					                              outer.c[0].w-projection).Length();
					m_result.p[2] = Vector3.Cross(outer.c[0].w - projection,
					                              outer.c[1].w-projection).Length();
					float sum=m_result.p[0]+m_result.p[1]+m_result.p[2];
					m_result.p[0]	/=	sum;
					m_result.p[1]	/=	sum;
					m_result.p[2]	/=	sum;
					return(m_status);
				}
			}
			/* Fallback		*/ 
			m_status	=	eStatus.FallBack;
			m_normal	=	-guess;
			float nl=m_normal.LengthSquared();
			if(nl>0)
			{
				m_normal.Normalize();
			}
			else
			{
				m_normal = new Vector3(1,0,0);
			}

			m_depth	=	0;
			m_result.rank=1;
			m_result.c[0]=simplex.c[0];
			m_result.p[0]=1;	
			return(m_status);
		}

		public sFace NewFace(sSV a,sSV b,sSV c,bool forced)
		{
			if(m_stock.Count > 0)
			{
				sFace face=m_stock[0];
				Remove(m_stock,face);
				Append(m_hull,face);
				face.pass	=	0;
				face.c[0]	=	a;
				face.c[1]	=	b;
				face.c[2]	=	c;
				face.n		=	Vector3.Cross(b.w-a.w,c.w-a.w);
				float l=face.n.Length();
				bool v = l > GjkEpaSolver2.EPA_ACCURACY;
				face.p = System.Math.Min(System.Math.Min(
					Vector3.Dot(a.w,Vector3.Cross(face.n,a.w-b.w)),
					Vector3.Dot(b.w,Vector3.Cross(face.n,b.w-c.w))),
				                         Vector3.Dot(c.w,Vector3.Cross(face.n,c.w-a.w)))	/
				         (v?l:1);
				face.p = face.p >= -GjkEpaSolver2.EPA_INSIDE_EPS ? 0 : face.p;
				if(v)
				{
					face.d = Vector3.Dot(a.w,face.n)/l;
					face.n /= l;
					if (forced || (face.d >= -GjkEpaSolver2.EPA_PLANE_EPS))
					{
						return(face);
					} 
					else 
					{
						m_status=eStatus.NonConvex;
					}
				} 
				else 
				{
					m_status=eStatus.Degenerated;
				}
				Remove(m_hull,face);
				Append(m_stock,face);
				return null;
			}
			m_status=m_stock.Count > 0?eStatus.OutOfVertices:eStatus.OutOfFaces;
			return null;
		}

		public sFace FindBest()
		{
			sFace minf = m_hull[0];
			float mind=minf.d*minf.d;
			float maxp=minf.p;

			//for(sFace f=minf.l[1];f != null;f=f.l[1])
			for (int i = 0; i < m_hull.Count;++i )
			{
				sFace f = m_hull[i];
				float sqd = f.d * f.d;
				if ((f.p >= maxp) && (sqd < mind))
				{
					minf = f;
					mind = sqd;
					maxp = f.p;
				}
			}
			return minf;
		}

		public bool	Expand(uint pass,sSV w,sFace f,uint e,sHorizon horizon)
		{
			uint[]	i1m3 = {1,2,0};
			uint[]  i2m3 = {2,0,1};
			if(f.pass!=pass)
			{
				uint e1 = i1m3[e];
				if ((Vector3.Dot(f.n, w.w) - f.d) < -GjkEpaSolver2.EPA_PLANE_EPS)
				{
					sFace nf = NewFace(f.c[e1],f.c[e],w,false);
					if(nf != null)
					{
						Bind(nf,0,f,e);
						if(horizon.cf != null)
						{
							Bind(horizon.cf,1,nf,2);
						}
						else 
						{
							horizon.ff=nf;
						}
						horizon.cf=nf;
						++horizon.nf;
						return(true);
					}
				}
				else
				{
					uint e2=i2m3[e];
					f.pass = (uint)pass;
					if(	Expand(pass,w,f.f[e1],f.e[e1],horizon)&&
					   	Expand(pass,w,f.f[e2],f.e[e2],horizon))
					{
						Remove(m_hull,f);
						Append(m_stock,f);
						return(true);
					}
				}
			}
			return(false);
		}
	}
}