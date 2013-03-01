using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;
namespace libtests.Parsing
{
	[TestFixture]
	public class UnderlinedHeaderOneTests
	{
		#region two lines valid
		[Test]
		public void TwoLines_Valid()
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
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);
			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion two lines valid

		#region three lines, newline after, valid
		[Test]
		public void ThreeLines_NewlineAfter_Valid()
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
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 1,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 1,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);
			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion three lines, newline after, valid

		#region three lines, newline before, valid
		[Test]
		public void ThreeLines_NewlineBefore_Valid()
		{
			string source = @"
Header1
=======";
			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 1,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);
			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion three lines, newline before, valid

		#region four lines, newline before and after, valid
		[Test]
		public void FourLines_NewlineBeforeAndAfter_Valid()
		{
			string source = @"
Header1
=======
";
			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Header1"
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 1,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 4,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 6,
				LineNumber = 2,
				Type = TokenType.StrongLine
			});
			expected.Add(new Token() {
				Column = 7,
				LineNumber = 2,
				Type = TokenType.Newline,
				Content = String.Empty
			});
			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);
			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion four lines, newline before and after, valid
	}
}