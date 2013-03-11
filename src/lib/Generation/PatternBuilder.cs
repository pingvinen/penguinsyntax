using System;
using System.Collections.Generic;
using PenguinSyntax.Parsing;

namespace PenguinSyntax.Generation
{
	public class PatternBuilder
	{
		public PatternBuilder()
		{
			this.List = new List<Token>();
		}

		public List<Token> List { get; set; }

		private void AddToken(TokenType type)
		{
			this.List.Add(new Token() {
				Type = type
			});
		}

		private void AddToken(TokenType type, string content)
		{
			this.List.Add(new Token() {
				Type = type,
				Content = content
			});
		}

		#region Newline
		public PatternBuilder Newline()
		{
			this.AddToken(TokenType.Newline);
			return this;
		}
		#endregion Newline

		#region Blockquote
		public PatternBuilder Blockquote()
		{
			this.AddToken(TokenType.Blockquote);
			return this;
		}
		#endregion Blockquote

		#region String
		public PatternBuilder String()
		{
			this.AddToken(TokenType.String, System.String.Empty);
			return this;
		}

		public PatternBuilder String(string content)
		{
			this.AddToken(TokenType.String, content);
			return this;
		}
		#endregion String

		#region Code open
		public PatternBuilder CodeOpen(string content)
		{
			this.AddToken(TokenType.CodeOpen, content);
			return this;
		}
		#endregion Code open

		#region Code close
		public PatternBuilder CodeClose()
		{
			this.AddToken(TokenType.CodeClose);
			return this;
		}
		#endregion Code close

		#region Verbatim
		public PatternBuilder Verbatim(string content)
		{
			this.AddToken(TokenType.Verbatim, content);
			return this;
		}
		#endregion Verbatim

		#region Header 1
		public PatternBuilder Header1()
		{
			this.AddToken(TokenType.Header1);
			return this;
		}
		#endregion Header 1

		#region Header 2
		public PatternBuilder Header2()
		{
			this.AddToken(TokenType.Header2);
			return this;
		}
		#endregion Header 2

		#region Header 3
		public PatternBuilder Header3()
		{
			this.AddToken(TokenType.Header3);
			return this;
		}
		#endregion Header 3

		#region Ordered list
		public PatternBuilder OrderedList()
		{
			this.AddToken(TokenType.OrderedList);
			return this;
		}
		#endregion Ordered list

		#region Strong line
		public PatternBuilder StrongLine()
		{
			this.AddToken(TokenType.StrongLine);
			return this;
		}
		#endregion Strong line

		#region Line
		public PatternBuilder Line()
		{
			this.AddToken(TokenType.Line);
			return this;
		}
		#endregion Line

		#region Unordered list
		public PatternBuilder UnorderedList()
		{
			this.AddToken(TokenType.UnorderedList);
			return this;
		}
		#endregion Unordered list

		#region Link label
		public PatternBuilder LinkLabel(string content)
		{
			this.AddToken(TokenType.LinkLabel, content);
			return this;
		}
		#endregion Link label

		#region Link URL
		public PatternBuilder LinkUrl(string content)
		{
			this.AddToken(TokenType.LinkUrl, content);
			return this;
		}
		#endregion Link URL

		#region Link title
		public PatternBuilder LinkTitle(string content)
		{
			this.AddToken(TokenType.LinkTitle, content);
			return this;
		}
		#endregion Link title

		#region Strong
		public PatternBuilder Strong()
		{
			this.AddToken(TokenType.Strong);
			return this;
		}
		#endregion Strong

		#region Emphasis
		public PatternBuilder Emphasis()
		{
			this.AddToken(TokenType.Emphasis);
			return this;
		}
		#endregion Emphasis
	}
}