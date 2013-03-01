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
		Header3 = 6,

		Blockquote = 7,

		UnorderedList = 8,
		OrderedList = 9,

		CodeOpen = 10,
		CodeClose = 11,

		Verbatim = 12,

		LinkLabel = 13,
		LinkUrl = 14,
		LinkTitle = 15
	}
}