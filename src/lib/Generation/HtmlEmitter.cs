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

				if (this.source.IsPatternPresent(this.curPos, this.TypeTester, 
				                                 new Token() { Type = TokenType.String },
													new Token() { Type = TokenType.Newline },
													new Token() { Type = TokenType.StrongLine }))
				{
					sb.AppendFormat("<h1>{0}</h1>", this.cur.Content);
				}
			}

			return sb.ToString();
		}
		#endregion Emit

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