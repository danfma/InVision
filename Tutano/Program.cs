using System;

namespace Tutano
{
	public static class Program
	{
		/// <summary>
		/// Mains the specified args.
		/// </summary>
		/// <param name="args">The args.</param>
		private static void Main(string[] args)
		{
			using (var tutano = new Tutano())
			{
				tutano.Run();
			}
		}
	}
}