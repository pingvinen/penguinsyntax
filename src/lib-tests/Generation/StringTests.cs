using System;
using NUnit.Framework;
using PenguinSyntax.Generation;

namespace libtests.Generation
{
	[TestFixture]
	public class StringTests
	{
		#region Plain text, single paragraph
		[Test]
		public void PlainText_SingleParagraph()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "First part of ")
					.Newline(0, 13)
					.String(1, 0, "a long string");

			string expected = "<p>First part of a long string</p>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Plain text, single paragraph

		#region Plain text, multiple paragraphs
		[Test]
		public void PlainText_MultipleParagraphs()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "First part of ")
					.Newline(0, 13)
					.String(1, 0, "a long string")
					.Newline(1, 13)
					.Newline(2, 0)
					.String(3, 0, "Second paragraph");

			string expected = "<p>First part of a long string</p><p>Second paragraph</p>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Plain text, multiple paragraphs

		#region With formatting, strong
		[Test]
		public void WithFormatting_Strong()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "String with ")
					.Strong(0, 12)
					.String(0, 13, "strong")
					.Strong(0, 20)
					.String(0, 21, " formatting");

			string expected = "<p>String with <strong>strong</strong> formatting</p>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion With formatting, strong

		#region With formatting, emphasis
		[Test]
		public void WithFormatting_Emphasis()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "String with ")
					.Emphasis(0, 12)
					.String(0, 13, "emphasis")
					.Emphasis(0, 21)
					.String(0, 22, " formatting");

			string expected = "<p>String with <em>emphasis</em> formatting</p>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion With formatting, emphasis

		#region With formatting, mixed
		[Test]
		public void WithFormatting_Mixed()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "He looks ")
					.Strong(0, 9)
					.Emphasis(0, 10)
					.String(0, 11, "strong")
					.Emphasis(0, 17)
					.Strong(0, 18)
					.String(0, 19, " tonight.");

			string expected = "<p>He looks <strong><em>strong</em></strong> tonight.</p>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion With formatting, mixed

		#region With link
		[Test]
		public void WithLink()
		{
			var tokens = new TokenListBuilder()
				.String(0, 0, "This is a text about ")
					.LinkLabel(0, 21, "a link")
					.LinkUrl(0, 29, "http://domain.tld/folder/file.ext")
					.String(0, 64, " in a text");

			string expected = "<p>This is a text about <a href=\"http://domain.tld/folder/file.ext\">a link</a> in a text</p>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion With link
	}
}