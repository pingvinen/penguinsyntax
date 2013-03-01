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

		private void AddToken(TokenType type, int line, int column)
		{
			this.List.Add(new Token() {
				Type = type,
				LineNumber = line,
				Column = column
			});
		}

		private void AddToken(TokenType type, int line, int column, string content)
		{
			this.List.Add(new Token() {
				Type = type,
				LineNumber = line,
				Column = column,
				Content = content
			});
		}

		#region Newline
		public TokenListBuilder Newline(int line, int column)
		{
			this.AddToken(TokenType.Newline, line, column);
			return this;
		}
		#endregion Newline

		#region Blockquote
		public TokenListBuilder Blockquote(int line, int column)
		{
			this.AddToken(TokenType.Blockquote, line, column);
			return this;
		}
		#endregion Blockquote

		#region String
		public TokenListBuilder String(int line, int column, string content)
		{
			this.AddToken(TokenType.String, line, column, content);
			return this;
		}
		#endregion String

		#region Code open
		public TokenListBuilder CodeOpen(int line, int column, string content)
		{
			this.AddToken(TokenType.CodeOpen, line, column, content);
			return this;
		}
		#endregion Code open

		#region Code close
		public TokenListBuilder CodeClose(int line, int column)
		{
			this.AddToken(TokenType.CodeClose, line, column);
			return this;
		}
		#endregion Code close

		#region Verbatim
		public TokenListBuilder Verbatim(int line, int column, string content)
		{
			this.AddToken(TokenType.Verbatim, line, column, content);
			return this;
		}
		#endregion Verbatim
	}
}