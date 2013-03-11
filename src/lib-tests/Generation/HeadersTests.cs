using System;
using NUnit.Framework;
using PenguinSyntax.Generation;

namespace libtests.Generation
{
	[TestFixture]
	public class HeadersTests
	{
		[Test]
		[Ignore("Have not begun implementation yet")]
		public void Header1()
		{
			var tokens = new TokenListBuilder()
				.Header1(0, 0)
					.String(0, 2, "Header 1");

			string expected = "<h1>Header 1</h1>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
	}
}