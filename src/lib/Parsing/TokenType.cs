using System;

namespace PenguinSyntax.Parsing
{
	public enum TokenType
	{
		String = 0,
		Newline = 1,

		/// <summary>
		/// Represents "="
		/// </summary>
		StrongLine = 2,

		/// <summary>
		/// Represents "-"
		/// </summary>
		Line = 3,

		Header1 = 4,
		Header2 = 5,
		Header3 = 6
	}
}