using System;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Vehicle
{
	public struct WheelRaycastInfo
	{
		//set by raycaster
		public Vector3	m_contactNormalWS;//contactnormal
		public Vector3	m_contactPointWS;//raycast hitpoint
		public float	m_suspensionLength;
		public float m_suspensionLengthBak;

		public Vector3	m_hardPointWS;//raycast starting point
		public Vector3 m_hardPointWSBak;//raycast starting point

		public Vector3	m_wheelDirectionWS; //direction in worldspace
		public Vector3 m_wheelDirectionWSBak; //direction in worldspace

		public Vector3	m_wheelAxleWS; // axle in worldspace
		public Vector3 m_wheelAxleWSBak; // axle in worldspace

		public bool		m_isInContact;
		public Object		m_groundObject; //could be general void* ptr
	}
}