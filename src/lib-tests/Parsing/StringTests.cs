using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class StringTests
	{
		#region One line
		[Test]
		public void OneLine()
		{
			string source = @"I am amazing.";

			var expected = new TokenListBuilder()
				.String(0, 0, "I am amazing.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion One line

		#region Multiple lines
		[Test]
		public void MultipleLines()
		{
			string source = @"I am amazing.
And everyone knows it :)";

			var expected = new TokenListBuilder()
				.String(0, 0, "I am amazing.")
					.Newline(0, 13)
					.String(1, 0, "And everyone knows it :)");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Multiple lines
	}
}