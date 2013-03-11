using System;
using NUnit.Framework;
using PenguinSyntax.Generation;

namespace libtests.Generation
{
	[TestFixture]
	public class ListTests
	{
		#region Unordered
		[Test]
		public void Unordered()
		{
			var tokens = new TokenListBuilder()
				.UnorderedList(0, 0)
					.String(0, 2, "Item 1")
					.Newline(0, 8)
					.UnorderedList(1, 0)
					.String(1, 2, "Item 2")
					.Newline(1, 8)
					.UnorderedList(2, 0)
					.String(2, 2, "Item 3");

			string expected = "<ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Unordered

		#region Ordered
		[Test]
		public void Ordered()
		{
			var tokens = new TokenListBuilder()
				.OrderedList(0, 0)
					.String(0, 2, "Item 1")
					.Newline(0, 8)
					.OrderedList(1, 0)
					.String(1, 2, "Item 2")
					.Newline(1, 8)
					.OrderedList(2, 0)
					.String(2, 2, "Item 3");

			string expected = "<ol><li>Item 1</li><li>Item 2</li><li>Item 3</li></ol>";

			HtmlEmitter emitter = new HtmlEmitter();
			string actual = emitter.Emit(tokens.List);

			Assert.AreEqual(expected, actual);
		}
		#endregion Ordered
	}
}