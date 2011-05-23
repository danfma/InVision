using System;
using InVision.OIS.Devices;
using NUnit.Framework;

namespace OIS.Tests
{
    [TestFixture]
    public class ComponentTest
    {
        /// <summary>
        /// Tests the instantiation.
        /// </summary>
        [Test]
        public void TestInstantiation()
        {
            using (var component = new Component())
            {
                Assert.That(component, Is.Not.Null);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var component = new Component())
            {
                Assert.That(component, Is.Not.Null);
            }
        }
    }
}