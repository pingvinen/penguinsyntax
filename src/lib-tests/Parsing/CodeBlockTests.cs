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

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.CodeOpen,
				Content = "plain"
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.CodeClose
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion Empty, no lang

		#region Empty, with lang
		[Test]
		public void Empty_WithLang()
		{
			string source = @"```javascript
```";

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.CodeOpen,
				Content = "javascript"
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.CodeClose
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
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

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.CodeOpen,
				Content = "plain"
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Verbatim
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.Verbatim
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 3,
				Type = TokenType.Verbatim
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 3,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 4,
				Type = TokenType.CodeClose
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
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

			List<Token> expected = new List<Token>();
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 0,
				Type = TokenType.CodeOpen,
				Content = "javascript"
			});
			expected.Add(new Token() {
				Column = 3,
				LineNumber = 0,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 1,
				Type = TokenType.Verbatim
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 2,
				Type = TokenType.Verbatim
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 3,
				Type = TokenType.Verbatim
			});
			expected.Add(new Token() {
				Column = 1,
				LineNumber = 3,
				Type = TokenType.Newline
			});
			expected.Add(new Token() {
				Column = 0,
				LineNumber = 4,
				Type = TokenType.CodeClose
			});

			Tokenizer nizer = new Tokenizer();
			List<Token> actual = nizer.Tokenize(source);

			CollectionAssert.AreEqual(expected, actual);
		}
		#endregion js loop, with lang
	}
}