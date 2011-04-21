using System;

namespace InVision.OIS.FunctionalTest
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			TestWrapper();

			//TestComponent();
			//TestButton();
		}

		private class MyVector3 : Vector3Proxy
		{
			public MyVector3(float x, float y, float z)
				: base(x, y, z)
			{
			}

			protected MyVector3(IntPtr pSelf, bool ownsHandle)
				: base(pSelf, ownsHandle)
			{
			}

			protected MyVector3(bool ownsHandle)
				: base(ownsHandle)
			{
			}

			/// <summary>
			/// Clears this instance.
			/// </summary>
			public override void Clear()
			{
				Console.WriteLine("It worked!!");

				base.Clear();
			}
		}

		private static void TestWrapper()
		{
			// vtable not overrided
			using (var vector = new Vector3Proxy(1, 2, 3))
			{
				Console.WriteLine(vector);
				vector.Clear();
				Console.WriteLine(vector);
			}

			// vtable overrided
			using (var vector = new MyVector3(1, 2, 3))
			{
				Console.WriteLine(vector);
				vector.Clear();
				Console.WriteLine(vector);
			}
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