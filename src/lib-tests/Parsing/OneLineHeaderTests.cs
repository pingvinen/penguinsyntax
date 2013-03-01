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
				Type = TokenType.Header1
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
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
				Type = TokenType.Header1
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.String,
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
				Type = TokenType.Header1
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
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
	
		#region Header2: one line, valid
		[Test]
		public void Header2_OneLine_Valid()
		{
			string source = @"## Header2";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Header2
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header2"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header2: one line, valid

		#region Header2: newline before, valid
		[Test]
		public void Header2_NewlineBefore_Valid()
		{
			string source = @"
## Header2";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Header2
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Header2"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header2: newline before, valid

		#region Header2: newline after, valid
		[Test]
		public void Header2_NewlineAfter_Valid()
		{
			string source = @"## Header2
";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Header2
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header2"
			});
			expected.Add(new Token() {
				Column = 10,
				LineNumber = 0,
				Type = TokenType.Newline
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header2: newline after, valid

		#region Header3: one line, valid
		[Test]
		public void Header3_OneLine_Valid()
		{
			string source = @"### Header3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Header3
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header3: one line, valid

		#region Header3: newline before, valid
		[Test]
		public void Header3_NewlineBefore_Valid()
		{
			string source = @"
### Header3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Header3
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Header3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header3: newline before, valid

		#region Header3: newline after, valid
		[Test]
		public void Header3_NewlineAfter_Valid()
		{
			string source = @"### Header3
";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Header3
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header3"
			});
			expected.Add(new Token() {
				Column = 11,
				LineNumber = 0,
				Type = TokenType.Newline
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Header3: newline after, valid

	}
}