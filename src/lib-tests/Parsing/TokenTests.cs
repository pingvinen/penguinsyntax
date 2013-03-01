using System;
using NUnit.Framework;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class TokenTests
	{
		[Test]
		public void Equatable()
		{
			Token a = new Token() {
				Column = 19,
				LineNumber = 87,
				Content = String.Empty,
				Type = TokenType.String
			};

			Token b = new Token() {
				Column = 19,
				LineNumber = 87,
				Content = String.Empty,
				Type = TokenType.String
			};

			Assert.AreEqual(a, b, "does not work with Assert.AreEqual");
			Assert.IsTrue(a.Equals(b), "does not work with Equals");
		}
	}
}