using InVision.OIS.Components;
using NUnit.Framework;

namespace InVision.OIS.Tests
{
	[TestFixture]
	public class AxisComponentTest
	{
		[Test]
		public void Creation()
		{
			using (var axis = new AxisComponent())
			{
				Assert.That(axis.Absolute, Is.EqualTo(0));
				Assert.That(axis.Relative, Is.EqualTo(0));
				Assert.That(axis.AbsoluteOnly, Is.EqualTo(false));
			}
		}
	}
}