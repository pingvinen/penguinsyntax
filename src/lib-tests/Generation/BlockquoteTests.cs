using System;
using NUnit.Framework;
using PenguinSyntax.Generation;

namespace libtests.Generation
{
	[TestFixture]
	public class BlockquoteTests
	{
		#region One level
		[Test]
		public void OneLevel()
		{
			var tokens = new TokenListBuilder()
				.Blockquote(0, 0)
					.String(0, 2, "Something quoted")
					.Newline(0, 18)
					.Blockquote(1, 0)
					.String(1, 2, "Second line of quote");

			string expected = "<blockquote><p>Something quoted</p><p>Second line of quote</p></blockquote>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion One level

		#region Nested
		[Test]
		public void Nested()
		{
			var tokens = new TokenListBuilder()
				.Blockquote(0, 0)
					.Blockquote(0, 1)
					.String(0, 2, "Oldest quote")
					.Newline(0, 19)
					.Blockquote(1, 0)
					.String(1, 2, "Newer quote");

			string expected = "<blockquote><blockqoute><p>Oldest quote</p></blockquote><p>Newer quote</p></blockquote>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Nested
	}
}