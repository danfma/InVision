using System;
using NUnit.Framework;

namespace InVision.OIS.Tests
{
	[TestFixture]
	public class ComponentTest
	{
		[Test]
		public void Creation()
		{
			var values = Enum.GetValues(typeof(ComponentType));

			foreach (ComponentType componentType in values)
			{
				using (var component = new Component(componentType))
				{
					Assert.That(component.ComponentType, Is.EqualTo(componentType));
				}
			}
		}
	}
}