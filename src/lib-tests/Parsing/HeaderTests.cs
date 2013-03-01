using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class HeaderTests
	{
		#region Underlined header 1
		[Test]
		public void UnderlinedH1_TwoLines_Valid()
		{
			string source = @"Header1
=======";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});

			Tokenizer nizer = new Tokenizer();

			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void UnderlinedH1_ThreeLines_NewlineAfter_Valid()
		{
			string source = @"Header1
=======
";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});

			Tokenizer nizer = new Tokenizer();

			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void UnderlinedH1_ThreeLines_NewlineBefore_Valid()
		{
			string source = @"
Header1
=======";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});

			Tokenizer nizer = new Tokenizer();

			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void UnderlinedH1_FourLines_NewlineBeforeAndAfter_Valid()
		{
			string source = @"
Header1
=======
";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 1,
				Type = TokenType.StrongLine,
				Content = "="
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});

			Tokenizer nizer = new Tokenizer();

			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Underlined header 1
	}
}