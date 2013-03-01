using System;
using System.Collections.Generic;

namespace PenguinSyntax.Parsing
{
	public class Tokenizer
	{
		public Tokenizer()
		{
		}

		private string source;
		private int linenumber;
		private int globalposition;
		private int column;

		#region Tokenize
		public List<Token> Tokenize(string inputsource)
		{
			List<Token> tokens = new List<Token>();

			this.source = inputsource;
			this.linenumber = 0;
			this.globalposition = -1;
			this.column = -1;

			char cur = '\0';
			while (this.globalposition < this.source.Length-1)
			{
				this.globalposition++;
				this.column++;
				cur = this.source[this.globalposition];

				if (cur == '\n')
				{
					tokens.Add(new Token() {
						Column = this.column,
						LineNumber = this.linenumber,
						Type = TokenType.Newline
					});

					this.linenumber++;
					this.column = -1;
					continue;
				}

				if (cur == '=')
				{
					tokens.Add(new Token() {
						Column = this.column,
						LineNumber = this.linenumber,
						Type = TokenType.StrongLine
					});
					continue;
				}

				//
				// if we get this far, we must be
				// looking at a string
				//
				tokens.Add(this.GetString());
			}

			return tokens;
		}
		#endregion Tokenize

		#region Get string
		private Token GetString()
		{
			Token t = new Token() {
				Column = this.column,
				LineNumber = this.linenumber,
				Type = TokenType.String
			};

			int start = this.globalposition;
			int substringlength = 0;

			char cur = '\0';
			while (this.globalposition < this.source.Length)
			{
				cur = this.source[this.globalposition];

				if (cur == '\n')
				{
					// let the main method handle the newline
					this.globalposition--;
					this.column--;

					t.Content = this.source.Substring(start, substringlength);
					return t;
				}

				this.globalposition++;
				this.column++;
				substringlength++;
			}

			throw new PenguinSyntaxException("Unable to find end of string");
		}
		#endregion Get string
	}
}

