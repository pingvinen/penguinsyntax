using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class LinkTests
	{
		#region Start text, one link, no title
		[Test]
		public void StartText_OneLink_Http_NoTitle()
		{
			string source = @"[A link](http://domain.tld/folder/file.ext) in a text";

			var expected = new TokenListBuilder()
					.LinkLabel(0, 0, "A link")
					.LinkUrl(0, 8, "http://domain.tld/folder/file.ext")
					.String(0, 43, " in a text");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Start text, one link, no title

		#region Mid text, one link, no title
		[Test]
		public void MidText_OneLink_Http_NoTitle()
		{
			string source = @"This is a text about [a link](http://domain.tld/folder/file.ext) in a text";

			var expected = new TokenListBuilder()
				.String(0, 0, "This is a text about ")
					.LinkLabel(0, 21, "a link")
					.LinkUrl(0, 29, "http://domain.tld/folder/file.ext")
					.String(0, 64, " in a text");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Mid text, one link, no title

		#region End text, one link, no title
		[Test]
		public void EndText_OneLink_Http_NoTitle()
		{
			string source = @"This is a text with [a link](http://domain.tld/folder/file.ext)";

			var expected = new TokenListBuilder()
				.String(0, 0, "This is a text with ")
					.LinkLabel(0, 20, "a link")
					.LinkUrl(0, 28, "http://domain.tld/folder/file.ext");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion End text, one link, no title
	}
}