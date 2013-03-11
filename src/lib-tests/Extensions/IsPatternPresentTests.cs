using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Extensions;

namespace libtests.Extensions
{
	#region Test element class
	public class TestElm
	{
		public string Data { get; set; }
	}
	#endregion Test element class

	[TestFixture]
	public class IsPatternPresentTests
	{
		#region Simple, present
		[Test]
		public void Simple_Present()
		{
			var list = new List<TestElm>() {
				new TestElm() { Data = "1" },
				new TestElm() { Data = "2" },
				new TestElm() { Data = "3" },
				new TestElm() { Data = "4" },
				new TestElm() { Data = "5" }
			};

			bool expected = true;
			bool actual = list.IsPatternPresent(1, (a,b) => { return a.Data.Equals(b.Data); },
				new TestElm() { Data = "2" },
				new TestElm() { Data = "3" },
				new TestElm() { Data = "4" });

			Assert.AreEqual(expected, actual);
		}
		#endregion Simple, present

		#region Simple, not present
		[Test]
		public void Simple_NotPresent()
		{
			var list = new List<TestElm>() {
				new TestElm() { Data = "1" },
				new TestElm() { Data = "2" },
				new TestElm() { Data = "3" },
				new TestElm() { Data = "4" },
				new TestElm() { Data = "5" }
			};

			bool expected = false;
			bool actual = list.IsPatternPresent(1, (a,b) => { return a.Data.Equals(b.Data); },
				new TestElm() { Data = "5" },
				new TestElm() { Data = "4" },
				new TestElm() { Data = "3" });

			Assert.AreEqual(expected, actual);
		}
		#endregion Simple, not present
	}
}