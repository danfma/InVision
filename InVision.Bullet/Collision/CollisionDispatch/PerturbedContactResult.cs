using InVision.Bullet.Debuging;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class PerturbedContactResult : ManifoldResult
	{
		public ManifoldResult m_originalManifoldResult;
		public Matrix m_transformA;
		public Matrix m_transformB;
		public Matrix	m_unPerturbedTransform;
		public bool	m_perturbA;
		public IDebugDraw	m_debugDrawer;


		public PerturbedContactResult(ManifoldResult originalResult,ref Matrix transformA,ref Matrix transformB,ref Matrix unPerturbedTransform,bool perturbA,IDebugDraw debugDrawer)
		{
			m_originalManifoldResult = originalResult;
			m_transformA = transformA;
			m_transformB = transformB;
			m_perturbA = perturbA;
			m_unPerturbedTransform = unPerturbedTransform;
			m_debugDrawer = debugDrawer;
		}

		public override void AddContactPoint(ref Vector3 normalOnBInWorld,ref Vector3 pointInWorld,float orgDepth)
		{
			Vector3 endPt,startPt;
			float newDepth;
			Vector3 newNormal = Vector3.Up;

			if (m_perturbA)
			{
				Vector3 endPtOrg = pointInWorld + normalOnBInWorld*orgDepth;
				endPt = Vector3.Transform(endPtOrg,(MathUtil.BulletMatrixMultiply(m_unPerturbedTransform,Matrix.Invert(m_transformA))));
				newDepth = Vector3.Dot((endPt -  pointInWorld),normalOnBInWorld);
				startPt = endPt+normalOnBInWorld*newDepth;
			} else
			{
				endPt = pointInWorld + normalOnBInWorld*orgDepth;
				startPt = Vector3.Transform(pointInWorld,(MathUtil.BulletMatrixMultiply(m_unPerturbedTransform,Matrix.Invert(m_transformB))));
				newDepth = Vector3.Dot((endPt -  startPt),normalOnBInWorld);
			}

			//#define DEBUG_CONTACTS 1
#if DEBUG_CONTACTS
			m_debugDrawer.DrawLine(startPt,endPt,new Vector3(1,0,0));
			m_debugDrawer.DrawSphere(startPt, 0.5f, new Vector3(0, 1, 0));
			m_debugDrawer.DrawSphere(endPt, 0.5f, new Vector3(0, 0, 1));
#endif //DEBUG_CONTACTS

    		
			m_originalManifoldResult.AddContactPoint(ref normalOnBInWorld,ref startPt,newDepth);
		}

	}
}