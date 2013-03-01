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
		StrongLine = 2
	}
}