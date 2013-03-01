using System;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace libtests
{
	public class TokenListBuilder
	{
		public TokenListBuilder()
		{
			this.List = new List<Token>();
		}

		public List<Token> List { get; set; }

		#region Newline
		public TokenListBuilder Newline(int line, int column)
		{
			this.List.Add(new Token() {
				Type = TokenType.Newline,
				LineNumber = line,
				Column = column
			});

			return this;
		}
		#endregion Newline

		#region Blockquote
		public TokenListBuilder Blockquote(int line, int column)
		{
			this.List.Add(new Token() {
				Type = TokenType.Blockquote,
				LineNumber = line,
				Column = column
			});

			return this;
		}
		#endregion Blockquote

		#region String
		public TokenListBuilder String(int line, int column, string content)
		{
			this.List.Add(new Token() {
				Type = TokenType.String,
				LineNumber = line,
				Column = column,
				Content = content
			});

			return this;
		}
		#endregion String
	}
}