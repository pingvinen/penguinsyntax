using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class EmphasisStrongTests
	{
		#region Strong, start text
		[Test]
		public void Strong_StartText()
		{
			string source = @"*Strong* words, sir.";

			var expected = new TokenListBuilder()
				.Strong(0, 0)
					.String(0, 1, "Strong")
					.Strong(0, 7)
					.String(0, 8, " words, sir.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Strong, start text

		#region Strong, mid text
		[Test]
		public void Strong_MidText()
		{
			string source = @"He looks *strong* tonight.";

			var expected = new TokenListBuilder()
				.String(0, 0, "He looks ")
					.Strong(0, 9)
					.String(0, 10, "strong")
					.Strong(0, 16)
					.String(0, 17, " tonight.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Strong, mid text

		#region Strong, end text
		[Test]
		public void Strong_EndText()
		{
			string source = @"He looks *strong*";

			var expected = new TokenListBuilder()
				.String(0, 0, "He looks ")
					.Strong(0, 9)
					.String(0, 10, "strong")
					.Strong(0, 16);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Strong, end text

		#region Emphasis, start text
		[Test]
		public void Emphasis_StartText()
		{
			string source = @"_Strong_ words, sir.";

			var expected = new TokenListBuilder()
				.Emphasis(0, 0)
					.String(0, 1, "Strong")
					.Emphasis(0, 7)
					.String(0, 8, " words, sir.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Emphasis, start text

		#region Emphasis, mid text
		[Test]
		public void Emphasis_MidText()
		{
			string source = @"He looks _strong_ tonight.";

			var expected = new TokenListBuilder()
				.String(0, 0, "He looks ")
					.Emphasis(0, 9)
					.String(0, 10, "strong")
					.Emphasis(0, 16)
					.String(0, 17, " tonight.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Emphasis, mid text

		#region Emphasis, end text
		[Test]
		public void Emphasis_EndText()
		{
			string source = @"He looks _strong_";

			var expected = new TokenListBuilder()
				.String(0, 0, "He looks ")
					.Emphasis(0, 9)
					.String(0, 10, "strong")
					.Emphasis(0, 16);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Emphasis, end text

		#region Mixed, mid text
		[Test]
		public void Mixed_MidText()
		{
			string source = @"He looks *_strong_* tonight.";

			var expected = new TokenListBuilder()
				.String(0, 0, "He looks ")
					.Strong(0, 9)
					.Emphasis(0, 10)
					.String(0, 11, "strong")
					.Emphasis(0, 17)
					.Strong(0, 18)
					.String(0, 19, " tonight.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Mixed, mid text

		#region Non formatting use
		[Test]
		public void NonFormattingUse()
		{
			string source = @"He is a real * in this community.
Words_With_Underscore.
An _ in the middle of everything.
Strange*Use of a star.";

			var expected = new TokenListBuilder()
				.String(0, 0, "He is a real * in this community.")
					.Newline(0, 33)
					.String(1, 0, "Words_With_Underscore.")
					.Newline(1, 22)
					.String(2, 0, "An _ in the middle of everything.")
					.Newline(2, 33)
					.String(3, 0, "Strange*Use of a star.");

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Non formatting use
	}
}