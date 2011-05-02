using InVision.OIS.Components;
using NUnit.Framework;

namespace InVision.OIS.Tests
{
	[TestFixture]
	public class ButtonComponentTest
	{
		[Test]
		public void Creation()
		{
			var values = new[] { true, false };

			foreach (var boolValue in values)
			{
				using (var button = new ButtonComponent(boolValue))
				{
					Assert.That(button.Pushed, Is.EqualTo(boolValue));
					Assert.That(button.ComponentType, Is.EqualTo(ComponentType.Button));
				}
			}
		}
	}
}