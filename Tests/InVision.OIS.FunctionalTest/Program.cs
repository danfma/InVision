using System;

namespace InVision.OIS.FunctionalTest
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			TestWrapper();

			TestComponent();
			TestButton();
		}

		private static void TestWrapper()
		{
			var cwrapper = new ComponentWrapper(ComponentType.Button);

			Console.WriteLine("{0} Type: {1}", cwrapper.GetType().Name, cwrapper.ComponentType);
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