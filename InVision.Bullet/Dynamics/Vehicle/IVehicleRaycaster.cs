using System;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Vehicle
{
	public interface IVehicleRaycaster
	{
		Object CastRay(ref Vector3 from,ref Vector3 to, ref VehicleRaycasterResult result);
	}
}