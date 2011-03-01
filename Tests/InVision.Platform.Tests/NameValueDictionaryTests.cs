using InVision.Collections;
using NUnit.Framework;

namespace InVision.Platform.Tests
{
	[TestFixture]
	public class NameValueDictionaryTests
	{
		[Test]
		public void GetNativeInstance()
		{
			var dic = new NameValueDictionary();

			Assert.That(dic.DictionaryHandle, Is.Not.Null);
		}

		[Test]
		public void FlushAndLoadData()
		{
			var dic = new NameValueDictionary();
			dic["A"] = "0";
			dic["B"] = "1";
			dic.Flush();
			dic.Clear();

			Assert.That(dic.Count, Is.EqualTo(0));

			dic.Load();

			Assert.That(dic.Count, Is.EqualTo(2));
			Assert.That(dic["A"], Is.EqualTo("0"));
			Assert.That(dic["B"], Is.EqualTo("1"));
		}
	}
}