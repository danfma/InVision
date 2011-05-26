using System;
using System.Collections.Generic;
using InVision.Framework.Components;
using InVision.Framework.Components.Actions;

namespace Tutano.Util
{
	public class MyGameComponent : GameComponent
	{
		/// <summary>
		/// Updates the by steps.
		/// </summary>
		/// <returns></returns>
		public override IEnumerable<UpdateAction> UpdateBySteps()
		{
			int i = 0;

			while (i++ < 3)
			{
				Console.WriteLine("Current time: {0}", DateTime.Now);
				yield return WaitBy(new TimeSpan(0, 0, 5));
				Console.WriteLine("After 5 seconds...");
			}

			Console.WriteLine("Time counting ended");
		}
	}
}