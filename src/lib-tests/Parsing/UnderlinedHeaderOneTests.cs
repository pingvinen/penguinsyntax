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

			var expected = new TokenListBuilder()
				.String(0, 0, "Header1")
					.Newline(0, 7)
					.StrongLine(1, 0)
					.StrongLine(1, 1)
					.StrongLine(1, 2)
					.StrongLine(1, 3)
					.StrongLine(1, 4)
					.StrongLine(1, 5)
					.StrongLine(1, 6);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion two lines valid

		#region three lines, newline after, valid
		[Test]
		public void ThreeLines_NewlineAfter_Valid()
		{
			string source = @"Header1
=======
";
			var expected = new TokenListBuilder()
				.String(0, 0, "Header1")
					.Newline(0, 7)
					.StrongLine(1, 0)
					.StrongLine(1, 1)
					.StrongLine(1, 2)
					.StrongLine(1, 3)
					.StrongLine(1, 4)
					.StrongLine(1, 5)
					.StrongLine(1, 6)
					.Newline(1, 7);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion three lines, newline after, valid

		#region three lines, newline before, valid
		[Test]
		public void ThreeLines_NewlineBefore_Valid()
		{
			string source = @"
Header1
=======";
			var expected = new TokenListBuilder()
				.Newline(0, 0)
					.String(1, 0, "Header1")
					.Newline(1, 7)
					.StrongLine(2, 0)
					.StrongLine(2, 1)
					.StrongLine(2, 2)
					.StrongLine(2, 3)
					.StrongLine(2, 4)
					.StrongLine(2, 5)
					.StrongLine(2, 6);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
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
			var expected = new TokenListBuilder()
				.Newline(0, 0)
					.String(1, 0, "Header1")
					.Newline(1, 7)
					.StrongLine(2, 0)
					.StrongLine(2, 1)
					.StrongLine(2, 2)
					.StrongLine(2, 3)
					.StrongLine(2, 4)
					.StrongLine(2, 5)
					.StrongLine(2, 6)
					.Newline(2, 7);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion four lines, newline before and after, valid
	}
}