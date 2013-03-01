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

			var expected = new TokenListBuilder()
				.OrderedList(0, 0)
					.String(0, 3, "Item");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion 1 item

		#region 3 items
		[Test]
		public void ThreeItems()
		{
			string source = @"1. Item 1
2. Item 2
3. Item 3";

			var expected = new TokenListBuilder()
				.OrderedList(0, 0)
					.String(0, 3, "Item 1")
					.Newline(0, 9)
					.OrderedList(1, 0)
					.String(1, 3, "Item 2")
					.Newline(1, 9)
					.OrderedList(2, 0)
					.String(2, 3, "Item 3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion 3 items

		#region 1 item large index number
		[Test]
		public void OneItemLargeIndexNumber()
		{
			string source = @"123. Item";

			var expected = new TokenListBuilder()
				.OrderedList(0, 0)
					.String(0, 5, "Item");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion 1 item

		#region Accidental ordered list
		[Test]
		public void AccidentalOrderedList()
		{
			string source = @"1987\. What a great year to be born.";

			var expected = new TokenListBuilder()
				.String(0, 0, "1987. What a great year to be born.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Accidental ordered list
	}
}