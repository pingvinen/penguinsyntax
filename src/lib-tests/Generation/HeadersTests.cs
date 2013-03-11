using System;
using NUnit.Framework;
using PenguinSyntax.Generation;

namespace libtests.Generation
{
	[TestFixture]
	public class HeadersTests
	{
		#region One line, header 1
		[Test]
		public void OneLine_Header1()
		{
			var tokens = new TokenListBuilder()
				.Header1(0, 0)
					.String(0, 2, "Header 1");

			string expected = "<h1>Header 1</h1>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion One line, header 1

		#region One line, header 2
		[Test]
		public void OneLine_Header2()
		{
			var tokens = new TokenListBuilder()
				.Header2(0, 0)
					.String(0, 3, "Header 2");

			string expected = "<h2>Header 2</h2>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion One line, header 2

		#region One line, header 3
		[Test]
		public void OneLine_Header3()
		{
			var tokens = new TokenListBuilder()
				.Header3(0, 0)
					.String(0, 4, "Header 3");

			string expected = "<h3>Header 3</h3>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion One line, header 3

		#region Underline, header 1
		[Test]
		public void Underline_Header1()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "Header 1")
					.Newline(0, 8)
					.StrongLine(1, 0)
					.StrongLine(1, 1)
					.StrongLine(1, 2)
					.StrongLine(1, 3)
					.StrongLine(1, 4)
					.StrongLine(1, 5)
					.StrongLine(1, 6)
					.StrongLine(1, 7);

			string expected = "<h1>Header 1</h1>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion One line, header 1

		#region Underline, header 2
		[Test]
		public void Underline_Header2()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "Header 2")
					.Newline(0, 8)
					.Line(1, 0)
					.Line(1, 1)
					.Line(1, 2)
					.Line(1, 3)
					.Line(1, 4)
					.Line(1, 5)
					.Line(1, 6)
					.Line(1, 7);

			string expected = "<h2>Header 2</h2>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion One line, header 2
	}
}