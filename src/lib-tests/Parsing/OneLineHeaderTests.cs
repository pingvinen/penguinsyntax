using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class OneLineHeaderTests
	{
		#region Header1: one line, valid
		[Test]
		public void Header1_OneLine_Valid()
		{
			string source = @"# Header1";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Header1,
				Content = "Header1"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header1: one line, valid

		#region Header1: newline before, valid
		[Test]
		public void Header1_NewlineBefore_Valid()
		{
			string source = @"
# Header1";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Header1,
				Content = "Header1"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header1: newline before, valid

		#region Header1: newline after, valid
		[Test]
		public void Header1_NewlineAfter_Valid()
		{
			string source = @"# Header1
";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Header1,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 9,
				LineNumber = 0,
				Type = TokenType.Newline
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header1: newline after, valid
	}
}