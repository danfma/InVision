using System;
using NUnit.Framework;

namespace InVision.OIS.Tests
{
	[TestFixture]
	public class Vector3Test
	{
		[Test]
		public void Creation()
		{
			const float x = float.MinValue;
			const float y = 2.75f;
			const float z = float.MaxValue;

			using (var vector = new Vector3Component(x, y, z))
			{
				Assert.That(vector.ComponentType, Is.EqualTo(ComponentType.Vector3));
				Assert.That(vector.X, Is.EqualTo(x));
				Assert.That(vector.Y, Is.EqualTo(y));
				Assert.That(vector.Z, Is.EqualTo(z));
			}
		}
	}
}