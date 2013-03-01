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

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "I am amazing."
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion One line

		#region Multiple lines
		[Test]
		public void MultipleLines()
		{
			string source = @"I am amazing.
And everyone knows it :)";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.String,
				Content = "I am amazing."
			});
			expected.Add(new Token() {
				Column = 13,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.String,
				Content = "And everyone knows it :)"
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Multiple lines
	}
}