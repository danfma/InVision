using System;
using System.Diagnostics;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class BroadphaseBenchmark
	{
		public static int UnsignedRand()
		{
			return UnsignedRand(BulletGlobals.RAND_MAX-1);
		}
        
		public static int UnsignedRand(int range)
		{ 
			return(BulletGlobals.gRandom.Next(range+1)); 
		}

		public static float UnitRand()
		{ 
			return(UnsignedRand(16384)/16384f); 
		}
		public static void	OutputTime(String name,Stopwatch sw,uint count)
		{
			ulong us=(ulong)sw.ElapsedMilliseconds;
			ulong ms=(us+500)/1000;
			float sec=us/(1000f*1000f);
			if(count>0)
			{
				System.Console.WriteLine("{0} : {1} us ({2} ms), {3}/s\r\n",name,us,ms,count/sec);
			}
			else
			{
				System.Console.WriteLine("{0} : {1} us ({2} ms)\r\n",name,us,ms);
			}
		}
	}
}