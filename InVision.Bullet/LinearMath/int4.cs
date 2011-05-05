namespace InVision.Bullet.LinearMath
{
	public class int4
	{
		public int x,y,z,w;
		public int4(){}
		public int4(int _x,int _y, int _z,int _w){x=_x;y=_y;z=_z;w=_w;}
		public int At(int index)
		{
			if(index == 0) return x;
			if(index == 1) return y;
			if(index == 2) return z;
			if(index == 3) return w;
			return -1;
		}

		public void At(int index,int value)
		{
			if(index == 0)
			{
				x = value;
			}
			else if(index == 1)
			{
				y = value;
			}
			else if(index == 2)
			{
				z = value ;
			}
			else if(index == 3)
			{
				w = value;
			}
		}
	}
}