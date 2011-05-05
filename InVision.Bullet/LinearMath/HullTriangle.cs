namespace InVision.Bullet.LinearMath
{
	public class HullTriangle : int3
	{
		public int3 n;
		public int id;
		public int vmax;
		public float rise;

		public HullTriangle(int a,int b,int c):base(a,b,c)
		{
			n = new int3(-1,-1,-1);
			vmax=-1;
			rise = 0.0f;
		}

		public int Neib(int a,int b)
		{
			int er=-1;
			int i;
			for(i=0;i<3;i++) 
			{
				int i1=(i+1)%3;
				int i2=(i+2)%3;
				if((At(i)==a && At(i1)==b)) return n.At(i2);
				if((At(i)==b && At(i1)==a)) return n.At(i2);
			}
			System.Diagnostics.Debug.Assert(false);
			return er;
		}

		public void Neib(int a, int b,int value)
		{
			int er = -1;
			int i;
			for (i = 0; i < 3; i++)
			{
				int i1 = (i + 1) % 3;
				int i2 = (i + 2) % 3;
				if ((At(i) == a && At(i1) == b))
				{
					n.At(i2, value);
					break;
				}
				if ((At(i) == b && At(i1) == a))
				{
					n.At(i2,value);
					break;
				}
			}
		}

	}
}