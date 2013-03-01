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

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Blockquote
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "something quoted"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion One line

		#region Multiple lines
		[Test]
		public void MultipleLines()
		{
			string source = @"> something quoted
> second line";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Blockquote
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "something quoted"
			});
			expected.Add(new Token() {
				Column = 18,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Blockquote
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "second line"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Multiple lines

		#region Nested, one line
		[Test]
		public void NestedOneLine()
		{
			string source = @">> something quoted";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Blockquote
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 0,
				Type = TokenType.Blockquote
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "something quoted"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Nested, one line

		#region One line, no text
		[Test]
		public void OneLine_NoText()
		{
			string source = @">";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Blockquote
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion One line, no text

		#region Two lines, no text
		[Test]
		public void TwoLines_NoText()
		{
			string source = @">
>";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Blockquote
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Blockquote
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Two lines, no text
	}
}