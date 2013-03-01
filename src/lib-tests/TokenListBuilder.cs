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

		#region Header 1
		public TokenListBuilder Header1(int line, int column)
		{
			this.AddToken(TokenType.Header1, line, column);
			return this;
		}
		#endregion Header 1

		#region Header 2
		public TokenListBuilder Header2(int line, int column)
		{
			this.AddToken(TokenType.Header2, line, column);
			return this;
		}
		#endregion Header 2

		#region Header 3
		public TokenListBuilder Header3(int line, int column)
		{
			this.AddToken(TokenType.Header3, line, column);
			return this;
		}
		#endregion Header 3

		#region Ordered list
		public TokenListBuilder OrderedList(int line, int column)
		{
			this.AddToken(TokenType.OrderedList, line, column);
			return this;
		}
		#endregion Ordered list

		#region Strong line
		public TokenListBuilder StrongLine(int line, int column)
		{
			this.AddToken(TokenType.StrongLine, line, column);
			return this;
		}
		#endregion Strong line

		#region Line
		public TokenListBuilder Line(int line, int column)
		{
			this.AddToken(TokenType.Line, line, column);
			return this;
		}
		#endregion Line

		#region Unordered list
		public TokenListBuilder UnorderedList(int line, int column)
		{
			this.AddToken(TokenType.UnorderedList, line, column);
			return this;
		}
		#endregion Unordered list

		#region Link label
		public TokenListBuilder LinkLabel(int line, int column, string content)
		{
			this.AddToken(TokenType.LinkLabel, line, column, content);
			return this;
		}
		#endregion Link label

		#region Link URL
		public TokenListBuilder LinkUrl(int line, int column, string content)
		{
			this.AddToken(TokenType.LinkUrl, line, column, content);
			return this;
		}
		#endregion Link URL

		#region Link title
		public TokenListBuilder LinkTitle(int line, int column, string content)
		{
			this.AddToken(TokenType.LinkTitle, line, column, content);
			return this;
		}
		#endregion Link title
	}
}