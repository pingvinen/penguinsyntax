using System;
using System.Collections.Generic;
using System.Text;

namespace PenguinSyntax.Parsing
{
	public class Tokenizer
	{
		#region Escapable characters
		private IDictionary<char, bool> escapableChars = new Dictionary<char, bool>() {
			{'\\', true},
			{'`', true},
			{'*', true},
			{'_', true},
			{'{', true},
			{'}', true},
			{'[', true},
			{']', true},
			{'#', true},
			{'+', true},
			{'-', true},
			{'.', true},
			{'!', true}
		};
		#endregion Escapable characters

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
			char next = '\0';
			while (this.globalposition < this.source.Length-1)
			{
				this.globalposition++;
				this.column++;
				cur = this.source[this.globalposition];
				next = this.Lookahead();

				//
				// newlines
				//
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
				// space
				//
				if (cur == ' ')
				{
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
				if (cur == '-' && (next == '-' || next == '\n' || next == '\0'))
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
					tokens.Add(this.GetOneLineHeaderType());
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
				// unordered list
				//
				if (cur == '*' || cur == '+' || cur == '-')
				{
					tokens.Add(new Token() {
						Column = this.column,
						LineNumber = this.linenumber,
						Type = TokenType.UnorderedList
					});
					continue;
				}

				//
				// ordered list
				//
				if (Char.IsDigit(cur) && (Char.IsDigit(next) || next == '.'))
				{
					var tmp = this.GetOrderedList();

					if (tmp == null)
					{
						// this was an accidental list
						tokens.Add(this.GetString());
						continue;
					}

					tokens.Add(tmp);
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

		#region Lookahead
		private char Lookahead()
		{
			int nextPos = this.globalposition + 1;

			if (nextPos < this.source.Length)
			{
				return this.source[nextPos];
			}

			return '\0';
		}
		#endregion Lookahead

		#region Get string
		private Token GetString()
		{
			Token t = new Token() {
				Column = this.column,
				LineNumber = this.linenumber,
				Type = TokenType.String
			};

			StringBuilder sb = new StringBuilder();

			char cur = '\0';
			char next = '\0';
			while (this.globalposition < this.source.Length)
			{
				cur = this.source[this.globalposition];
				next = this.Lookahead();

				if (cur == '\\' && this.escapableChars.ContainsKey(next))
				{
					this.globalposition++;
					this.column++;
					continue;
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
						// then we need to add the current character
						sb.Append(cur);
					}

					t.Content = sb.ToString();
					return t;
				}

				sb.Append(cur);
				this.globalposition++;
				this.column++;
			}

			throw new PenguinSyntaxException("I was not able to find the end of the string");
		}
		#endregion Get string

		#region Get oneline header type
		private Token GetOneLineHeaderType()
		{
			Token t = new Token() {
				Column = this.column,
				LineNumber = this.linenumber
			};

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
							t.Type = TokenType.Header1;
							return t;
						}

						case 2:
						{
							t.Type = TokenType.Header2;
							return t;
						}

						case 3:
						{
							t.Type = TokenType.Header3;
							return t;
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

		#region Get ordered list
		private Token GetOrderedList()
		{
			Token t = new Token() {
				Column = this.column,
				LineNumber = this.linenumber,
				Type = TokenType.OrderedList
			};

			int originalGlobal = this.globalposition;
			int originalColumn = this.column;

			char cur = '\0';
			while (this.globalposition < this.source.Length)
			{
				cur = this.source[this.globalposition];

				if (cur == '.')
				{
					return t;
				}

				else if (cur == '\\')
				{
					// oh shit... abort abort
					this.globalposition = originalGlobal;
					this.column = originalColumn;
					return null;
				}

				this.globalposition++;
				this.column++;
			}

			throw new PenguinSyntaxException("I was unable to find the end of the ordered list item index. They have the format '123.'.");
		}
		#endregion Get ordered list
	}
}

