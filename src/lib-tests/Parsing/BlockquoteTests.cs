using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class BlockquoteTests
	{
		#region One line
		[Test]
		public void OneLine()
		{
			string source = @"> something quoted";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0)
				.String(0, 2, "something quoted");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion One line

		#region Multiple lines
		[Test]
		public void MultipleLines()
		{
			string source = @"> something quoted
> second line";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0)
					.String(0, 2, "something quoted")
					.Newline(0, 18)
					.Blockquote(1, 0)
					.String(1, 2, "second line");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Multiple lines

		#region Nested, one line
		[Test]
		public void NestedOneLine()
		{
			string source = @">> something quoted";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0)
					.Blockquote(0, 1)
					.String(0, 3, "something quoted");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Nested, one line

		#region Nested, with spaces, one line
		[Test]
		public void Nested_WithSpaces_OneLine()
		{
			string source = @"> >   > something quoted";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0)
					.Blockquote(0, 2)
					.Blockquote(0, 6)
					.String(0, 8, "something quoted");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Nested, with spaces, one line

		#region Mixed nesting
		[Test]
		public void MixedNesting()
		{
			string source = @">> something quoted
> more recent quote
And this is now";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0)
					.Blockquote(0, 1)
					.String(0, 3, "something quoted")
					.Newline(0, 19)
					.Blockquote(1, 0)
					.String(1, 2, "more recent quote")
					.Newline(1, 19)
					.String(2, 0, "And this is now");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Mixed nesting

		#region One line, no text
		[Test]
		public void OneLine_NoText()
		{
			string source = @">";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion One line, no text

		#region Two lines, no text
		[Test]
		public void TwoLines_NoText()
		{
			string source = @">
>";

			var expected = new TokenListBuilder()
				.Blockquote(0, 0)
					.Newline(0, 1)
					.Blockquote(1, 0);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Two lines, no text
	}
}