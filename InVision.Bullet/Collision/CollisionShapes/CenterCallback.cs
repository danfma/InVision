using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class CenterCallback: IInternalTriangleIndexCallback
	{
		public CenterCallback()
		{
			first = true;
			reference = new Vector3();
			sum = new Vector3();
			volume = 0f;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			if (first)
			{
				reference = triangle[0];
				first = false;
			}
			else
			{
				Vector3 a = triangle[0] - reference;
				Vector3 b = triangle[1] - reference;
				Vector3 c = triangle[2] - reference;
				float vol = System.Math.Abs(MathUtil.Vector3Triple(ref a,ref b,ref c));
				sum += (.25f * vol) * ((triangle[0] + triangle[1] + triangle[2] + reference));
				volume += vol;
			}
		}
      
		public Vector3 GetCenter()
		{
			return (volume > 0) ? sum / volume : reference;
		}

		public float GetVolume()
		{
			return volume * (1f / 6f);
		}

		public void Cleanup()
		{

		}


		bool first;
		Vector3 reference;
		Vector3 sum;
		float volume;

	}
}