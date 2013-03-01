using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class UnorderedListTests
	{
		#region Star: 1 item
		[Test]
		public void Star_OneItem()
		{
			string source = @"* Item";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Star: 1 item

		#region Star: 3 items
		[Test]
		public void Star_ThreeItems()
		{
			string source = @"* Item 1
* Item 2
* Item 3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item 1"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Item 2"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 1,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 2,
				Type = TokenType.String,
				Content = "Item 3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Star: 3 items
	
		#region Plus: 1 item
		[Test]
		public void Plus_OneItem()
		{
			string source = @"+ Item";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Plus: 1 item

		#region Plus: 3 items
		[Test]
		public void Plus_ThreeItem()
		{
			string source = @"+ Item 1
+ Item 2
+ Item 3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item 1"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Item 2"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 1,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 2,
				Type = TokenType.String,
				Content = "Item 3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Plus: 3 items

		#region Minus: 1 item
		[Test]
		public void Minus_OneItem()
		{
			string source = @"- Item";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Minus: 1 item

		#region Minus: 3 items
		[Test]
		public void Minus_ThreeItems()
		{
			string source = @"- Item 1
- Item 2
- Item 3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item 1"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Item 2"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 1,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 2,
				Type = TokenType.String,
				Content = "Item 3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Minus: 3 items

		#region Mixed: 3 items
		[Test]
		public void Mixed_ThreeItems()
		{
			string source = @"- Item 1
* Item 2
+ Item 3";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "Item 1"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "Item 2"
			});
			expected.Add(new Token() {
				Column = 8,
				LineNumber = 1,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.UnorderedList
			});
			expected.Add(new Token() {
				Column = 2,
				LineNumber = 2,
				Type = TokenType.String,
				Content = "Item 3"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Mixed: 3 items
	}
}