using System;
using NUnit.Framework;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests.Parsing
{
	[TestFixture]
	public class CodeBlockTests
	{
		#region Empty, no lang
		[Test]
		public void Empty_NoLang()
		{
			string source = @"```
```";

			var expected = new TokenListBuilder()
				.CodeOpen(0, 0, "plain")
					.Newline(0, 3)
					.CodeClose(1, 0);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Empty, no lang

		#region Empty, with lang
		[Test]
		public void Empty_WithLang()
		{
			string source = @"```javascript
```";

			var expected = new TokenListBuilder()
				.CodeOpen(0, 0, "javascript")
					.Newline(0, 13)
					.CodeClose(1, 0);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion Empty, with lang

		#region js loop, no lang
		[Test]
		public void JsLoop_NoLang()
		{
			string source = @"```
for (var i=0; i<10; i++) {
	// do something
}
```";

			var expected = new TokenListBuilder()
				.CodeOpen(0, 0, "plain")
					.Newline(0, 3)
					.Verbatim(1, 0, "for (var i=0; i<10; i++) {")
					.Newline(1, 26)
					.Verbatim(2, 0, "\t// do something")
					.Newline(2, 16)
					.Verbatim(3, 0, "}")
					.Newline(3, 1)
					.CodeClose(4, 0);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion js loop, no lang

		#region js loop, with lang
		[Test]
		public void JsLoop_WithLang()
		{
			string source = @"```javascript
for (var i=0; i<10; i++) {
	// do something
}
```";

			var expected = new TokenListBuilder()
				.CodeOpen(0, 0, "javascript")
					.Newline(0, 13)
					.Verbatim(1, 0, "for (var i=0; i<10; i++) {")
					.Newline(1, 26)
					.Verbatim(2, 0, "\t// do something")
					.Newline(2, 16)
					.Verbatim(3, 0, "}")
					.Newline(3, 1)
					.CodeClose(4, 0);

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected.List, actual);
		}
		#endregion js loop, with lang
	}
}