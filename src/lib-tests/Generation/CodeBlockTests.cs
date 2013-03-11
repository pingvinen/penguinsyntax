using System;
using NUnit.Framework;
using PenguinSyntax.Generation;

namespace libtests.Generation
{
	[TestFixture]
	public class CodeBlockTests
	{
		#region Plain, with code
		[Test]
		public void Plain_WithCode()
		{
			var tokens = new TokenListBuilder()
				.CodeOpen(0, 0, "plain")
					.Newline(0, 3)
					.Verbatim(1, 0, "for (var i=0; i<10; i++) {")
					.Newline(1, 26)
					.Verbatim(2, 0, "\t// do something")
					.Newline(2, 16)
					.Verbatim(3, 0, "}")
					.Newline(3, 1)
					.CodeClose(4, 0);

			string expected = @"<pre>for (var i=0; i<10; i++) {
	// do something
}</pre>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Plain, with code

		#region Javascript, with code
		[Test]
		public void JavaScript_WithCode()
		{
			var tokens = new TokenListBuilder()
				.CodeOpen(0, 0, "javascript")
					.Newline(0, 3)
					.Verbatim(1, 0, "for (var i=0; i<10; i++) {")
					.Newline(1, 26)
					.Verbatim(2, 0, "\t// do something")
					.Newline(2, 16)
					.Verbatim(3, 0, "}")
					.Newline(3, 1)
					.CodeClose(4, 0);

			string expected = @"<pre class=""brush: javascript;"">for (var i=0; i<10; i++) {
	// do something
}</pre>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Javascript, with code
	}
}