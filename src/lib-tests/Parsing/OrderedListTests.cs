using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class OrderedListTests
	{
		#region 1 item
		[Test]
		public void OneItem()
		{
			string source = @"1. Item";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.OrderedList
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion 1 item

		#region 3 items
		[Test]
		public void ThreeItems()
		{
			string source = @"1. Item 1
2. Item 2
3. Item 3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.OrderedList
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item 1"
			});
			expected.Add(new Token() {
				Column = 9,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.OrderedList
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Item 2"
			});
			expected.Add(new Token() {
				Column = 9,
				LineNumber = 1,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.OrderedList
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 2,
				Type = TokenType.String,
				Content = "Item 3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion 3 items

		#region 1 item large index number
		[Test]
		public void OneItemLargeIndexNumber()
		{
			string source = @"123. Item";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.OrderedList
			});
			expected.Add(new Token() {
				Column = 5,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion 1 item

		#region Accidental ordered list
		[Test]
		public void AccidentalOrderedList()
		{
			string source = @"1987\. What a great year to be born.";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "1987. What a great year to be born."
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Accidental ordered list
	}
}