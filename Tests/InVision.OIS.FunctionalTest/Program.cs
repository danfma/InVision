using System;

namespace InVision.OIS.FunctionalTest
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			TestComponent();
			TestButton();
		}

		/// <summary>
		/// Tests the button.
		/// </summary>
		private static void TestButton()
		{
			var button = new ButtonComponent(true);

			Console.WriteLine("ComponentType: {0}", button.ComponentType);
			Console.WriteLine("Pushed: {0}", button.Pushed);

			button = new ButtonComponent(false);

			Console.WriteLine("ComponentType: {0}", button.ComponentType);
			Console.WriteLine("Pushed: {0}", button.Pushed);

			Console.ReadLine();
		}

		/// <summary>
		/// Tests the component.
		/// </summary>
		private static void TestComponent()
		{
			var component = new ButtonComponent(true);
			Console.WriteLine("ComponentType: {0}", component.ComponentType);

			component.Dispose();
		}
	}
}