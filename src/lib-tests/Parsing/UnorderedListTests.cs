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

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Star: 1 item

		#region Star: 3 items
		[Test]
		public void Star_ThreeItems()
		{
			string source = @"* Item 1
* Item 2
* Item 3";

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item 1")
					.Newline(0, 8)
					.UnorderedList(1, 0)
					.String(1, 2, "Item 2")
					.Newline(1, 8)
					.UnorderedList(2, 0)
					.String(2, 2, "Item 3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Star: 3 items
	
		#region Plus: 1 item
		[Test]
		public void Plus_OneItem()
		{
			string source = @"+ Item";

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Plus: 1 item

		#region Plus: 3 items
		[Test]
		public void Plus_ThreeItem()
		{
			string source = @"+ Item 1
+ Item 2
+ Item 3";

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item 1")
					.Newline(0, 8)
					.UnorderedList(1, 0)
					.String(1, 2, "Item 2")
					.Newline(1, 8)
					.UnorderedList(2, 0)
					.String(2, 2, "Item 3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Plus: 3 items

		#region Minus: 1 item
		[Test]
		public void Minus_OneItem()
		{
			string source = @"- Item";

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Minus: 1 item

		#region Minus: 3 items
		[Test]
		public void Minus_ThreeItems()
		{
			string source = @"- Item 1
- Item 2
- Item 3";

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item 1")
					.Newline(0, 8)
					.UnorderedList(1, 0)
					.String(1, 2, "Item 2")
					.Newline(1, 8)
					.UnorderedList(2, 0)
					.String(2, 2, "Item 3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Minus: 3 items

		#region Mixed: 3 items
		[Test]
		public void Mixed_ThreeItems()
		{
			string source = @"- Item 1
* Item 2
+ Item 3";

			var expected = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item 1")
					.Newline(0, 8)
					.UnorderedList(1, 0)
					.String(1, 2, "Item 2")
					.Newline(1, 8)
					.UnorderedList(2, 0)
					.String(2, 2, "Item 3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Mixed: 3 items
	}
}