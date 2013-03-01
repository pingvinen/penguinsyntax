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

				//
				// strong line
				//
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
				// line
				//
				if (cur == '-')
				{
					tokens.Add(new Token() {
						Column = this.column,
						LineNumber = this.linenumber,
						Type = TokenType.Line
					});
					continue;
				}

				//
				// oneline header
				//
				if (cur == '#')
				{
					tokens.Add(this.GetOneLineHeader());
					continue;
				}

				//
				// blockquote
				//
				if (cur == '>')
				{
					tokens.Add(new Token() {
						Column = this.column,
						LineNumber = this.linenumber,
						Type = TokenType.Blockquote
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

			throw new PenguinSyntaxException("I was not able to find the end of the string");
		}
		#endregion Get string

		#region Get oneline header
		private Token GetOneLineHeader()
		{
			Token t = new Token() {
				Column = this.column,
				LineNumber = this.linenumber
			};

			t.Type = this.GetOneLineHeaderType();

			int start = -1;
			int substringlength = 0;

			char cur = '\0';
			while (this.globalposition < this.source.Length)
			{
				cur = this.source[this.globalposition];

				// skip spaces at the beginning
				if (start == -1 && cur != ' ')
				{
					start = this.globalposition;
				}

				else if (cur == '\n' || (this.globalposition == this.source.Length-1))
				{
					if (cur == '\n')
					{
						// let the main method handle the newline
						this.globalposition--;
						this.column--;
					}
					else
					{
						// if end-of-source is the reason we are stopping,
						// then we need to increase the substring
						substringlength++;
					}

					t.Content = this.source.Substring(start, substringlength);
					return t;
				}

				this.globalposition++;
				this.column++;

				if (cur != ' ')
				{
					substringlength++;
				}
			}

			throw new PenguinSyntaxException("I was not able to find the end of the one-line header");
		}
		#endregion Get oneline header

		#region Get oneline header type
		private TokenType GetOneLineHeaderType()
		{
			int headerlvl = 0;
			char cur = '\0';
			while (this.globalposition < this.source.Length)
			{
				cur = this.source[this.globalposition];

				if (cur != '#')
				{
					switch (headerlvl)
					{
						case 1:
						{
							return TokenType.Header1;
						}

						case 2:
						{
							return TokenType.Header2;
						}

						case 3:
						{
							return TokenType.Header3;
						}

						default:
						{
							throw new PenguinSyntaxException("You are only allowed to use between 1 and 3 '#' for headers. You used {0}", headerlvl);
						}
					}
				}

				this.globalposition++;
				this.column++;
				headerlvl++;
			}

			throw new PenguinSyntaxException("I was not able to find the end of the header type");
		}
		#endregion Get oneline header type
	}
}

