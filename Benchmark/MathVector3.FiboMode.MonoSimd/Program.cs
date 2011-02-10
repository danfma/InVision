using System;
using Mono.Simd;

namespace MathVector3.FiboMode.MonoSimd
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var vlist = new Vector4f[1024 * 1024 * 50];
			int times = 5;
			int timeCounter = 0;
			long ticksSum = 0;

			vlist[0] = new Vector4f(0);
			vlist[1] = new Vector4f(1);

			do
			{
				long start = DateTime.Now.Ticks;

				for (int i = 2; i < vlist.Length; i++)
				{
					vlist[i] = vlist[i - 1] + vlist[i - 2];
				}

				ticksSum += DateTime.Now.Ticks - start;
			} while (++timeCounter < times);

			Console.WriteLine("# Mono.Simd");
			Console.WriteLine("\tMedia: {0}s", new TimeSpan(ticksSum / times).TotalSeconds);
			Console.WriteLine("\tTempo total: {0}s", new TimeSpan(ticksSum).TotalSeconds);
		}
	}
}