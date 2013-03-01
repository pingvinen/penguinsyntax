using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;
using PenguinSyntax;

namespace libtests.Parsing
{
	[TestFixture]
	public class OneLineHeaderTests
	{
		#region Header1: one line, valid
		[Test]
		public void Header1_OneLine_Valid()
		{
			string source = @"# Header1";

			var expected = new TokenListBuilder()
				.Header1(0, 0)
					.String(0, 2, "Header1");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header1: one line, valid

		#region Header1: newline before, valid
		[Test]
		public void Header1_NewlineBefore_Valid()
		{
			string source = "\n# Header1";

			var expected = new TokenListBuilder()
				.Newline(0, 0)
					.Header1(1, 0)
					.String(1, 2, "Header1");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header1: newline before, valid

		#region Header1: newline after, valid
		[Test]
		public void Header1_NewlineAfter_Valid()
		{
			string source = @"# Header1
";

			var expected = new TokenListBuilder()
				.Header1(0, 0)
					.String(0, 2, "Header1")
					.Newline(0, 9);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header1: newline after, valid
	
		#region Header2: one line, valid
		[Test]
		public void Header2_OneLine_Valid()
		{
			string source = @"## Header2";

			var expected = new TokenListBuilder()
				.Header2(0, 0)
					.String(0, 3, "Header2");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header2: one line, valid

		#region Header2: newline before, valid
		[Test]
		public void Header2_NewlineBefore_Valid()
		{
			string source = "\n## Header2";

			var expected = new TokenListBuilder()
				.Newline(0, 0)
					.Header2(1, 0)
					.String(1, 3, "Header2");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header2: newline before, valid

		#region Header2: newline after, valid
		[Test]
		public void Header2_NewlineAfter_Valid()
		{
			string source = @"## Header2
";

			var expected = new TokenListBuilder()
				.Header2(0, 0)
					.String(0, 3, "Header2")
					.Newline(0, 10);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header2: newline after, valid

		#region Header3: one line, valid
		[Test]
		public void Header3_OneLine_Valid()
		{
			string source = @"### Header3";

			var expected = new TokenListBuilder()
				.Header3(0, 0)
					.String(0, 4, "Header3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header3: one line, valid

		#region Header3: newline before, valid
		[Test]
		public void Header3_NewlineBefore_Valid()
		{
			string source = "\n### Header3";

			var expected = new TokenListBuilder()
				.Newline(0, 0)
					.Header3(1, 0)
					.String(1, 4, "Header3");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header3: newline before, valid

		#region Header3: newline after, valid
		[Test]
		public void Header3_NewlineAfter_Valid()
		{
			string source = @"### Header3
";

			var expected = new TokenListBuilder()
				.Header3(0, 0)
					.String(0, 4, "Header3")
					.Newline(0, 11);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Header3: newline after, valid

		#region Too many hashes
		[Test]
		public void TooManyHashes()
		{
			string source = @"#### Header";

			Tokenizer nizer = new Tokenizer();

			try
			{
				nizer.Tokenize(source);

				Assert.Fail("A syntax exception should have been thrown");
			}

			catch (SyntaxException)
			{
				// hephey
			}
		}
		#endregion Too many hashes

		#region No text
		[Test]
		public void NoText()
		{
			string source = @"##";

			Tokenizer nizer = new Tokenizer();

			try
			{
				nizer.Tokenize(source);

				Assert.Fail("A syntax exception should have been thrown");
			}

			catch (SyntaxException)
			{
				// hephey
			}
		}
		#endregion NoText
	}
}