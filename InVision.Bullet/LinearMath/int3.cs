namespace InVision.Bullet.LinearMath
{
	public class int3  
	{
		public int x,y,z;
		public int3()
		{
		}
		public int3(int _x,int _y, int _z)
		{
			x=_x;
			y=_y;
			z=_z;
		}

		public override bool Equals(object obj)
		{
			int3 b =(int3)obj;
			if(x != b.x || y != b.y || z != b.z)
			{
				return false;
			}
			return true;
		}

		public int At(int index)
		{
			if(index == 0) return x;
			if(index == 1) return y;
			if(index == 2) return z;
			return -1;
		}

		public void At(int index,int value)
		{
			if (index == 0) x = value;
			else if (index == 1) y = value;
			else if (index == 2) z = value;
		}

    
	}
}