using System;
using System.Collections.Generic;
using PenguinSyntax.Parsing;
using System.Text;
using PenguinSyntax.Extensions;

namespace PenguinSyntax.Generation
{
	public class HtmlEmitter
	{
		public HtmlEmitter()
		{
		}

		private int curPos = -1;
		private Token cur;
		private Token next;
		private Token prev;
		private IList<Token> source;
		private Stack<TokenType> openElements = new Stack<TokenType>();

		private bool TypeTester(Token inList, Token inPattern)
		{
			return inList.Type == inPattern.Type;
		}

		#region Emit
		public string Emit(IList<Token> tokens)
		{
			this.source = tokens;

			StringBuilder sb = new StringBuilder();

			this.curPos = 0;

			for (; this.curPos!=this.source.Count; this.curPos++)
			{
				this.prev = this.cur;
				this.cur = this.source[this.curPos];
				this.next = this.LookAhead();

				#region Headers
				if (this.IsPattern(new PatternBuilder().String().Newline().StrongLine().List))
				{
					sb.AppendFormat("<h1>{0}</h1>", this.cur.Content);
					this.SkipAheadToNextNot(TokenType.Header1);
				}

				else if (this.IsPattern(new PatternBuilder().Header1().String().List))
				{
					sb.AppendFormat("<h1>{0}</h1>", this.next.Content);
					this.SkipAheadToNextNot(TokenType.Header1);
				}

				else if (this.IsPattern(new PatternBuilder().String().Newline().Line().List))
				{
					sb.AppendFormat("<h2>{0}</h2>", this.cur.Content);
					this.SkipAheadToNextNot(TokenType.Header2);
				}

				else if (this.IsPattern(new PatternBuilder().Header2().String().List))
				{
					sb.AppendFormat("<h2>{0}</h2>", this.next.Content);
					this.SkipAheadToNextNot(TokenType.Header2);
				}

				else if (this.IsPattern(new PatternBuilder().Header3().String().List))
				{
					sb.AppendFormat("<h3>{0}</h3>", this.next.Content);
					this.SkipAheadToNextNot(TokenType.Header3);
				}
				#endregion Headers

				#region Blockquote
				else if (this.cur.Type == TokenType.Blockquote)
				{
					// open a blockquote element in the model
					this.openElements.Push(TokenType.Blockquote);

					// open a blockquote in html
					sb.Append("<blockquote>");

					//
					// somehow handle multiline quotes
					//
				}
				#endregion Blockquote

				else if (this.cur.Type == TokenType.String)
				{
					sb.AppendFormat("<p>{0}</p>", this.cur.Content);
				}

				else if (this.cur.Type == TokenType.Newline && this.next != null && this.next.Type == TokenType.Newline)
				{
					this.CloseOpenElements();
				}
			}

			this.CloseOpenElements();

			return sb.ToString();
		}
		#endregion Emit

		private string CloseOpenElements()
		{
			StringBuilder sb = new StringBuilder();

			TokenType tmp;
			while (this.openElements.Count > 0)
			{
				tmp = this.openElements.Pop();

				switch (tmp)
				{
					case TokenType.Blockquote:
					{
						sb.Append("</blockqoute>");
						break;
					}
				}
			}

			return sb.ToString();
		}

		#region Helper: skip ahead
		private void SkipAheadUntil(TokenType untilType)
		{
			this.SkipAheadUntilTrue(x => x.Type == untilType);
		}

		private void SkipAheadToNextNot(TokenType notThisType)
		{
			this.SkipAheadUntilTrue(x => x.Type != notThisType);
		}

		private void SkipAheadUntilTrue(Func<Token, bool> stopIfTrue)
		{
			for (; this.curPos!=this.source.Count; this.curPos++)
			{
				this.prev = this.cur;
				this.cur = this.source[this.curPos];
				this.next = this.LookAhead();

				if (stopIfTrue(this.cur))
				{
					return;
				}
			}
		}
		#endregion Helper: skip ahead

		#region Helper: is pattern present
		private bool IsPattern(IList<Token> pattern)
		{
			return this.source.IsPatternPresent(this.curPos, this.TypeTester, pattern);
		}
		#endregion Helper: is pattern present

		#region Look ahead
		private Token LookAhead()
		{
			int n = this.curPos + 1;

			if (n < this.source.Count)
			{
				return this.source[n];
			}

			return null;
		}
		#endregion Look ahead
	}
}