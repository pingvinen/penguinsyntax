using System;
using System.Collections.Generic;

namespace PenguinSyntax.Extensions
{
	/// <summary>
	/// Extensions on <see cref="IList"/>
	/// </summary>
	public static class IListExtensions
	{
		#region Is pattern present
		/// <summary>
		/// Check whether a given pattern is present in the given list from the given index
		/// </summary>
		/// <returns>
		/// <c>true</c> if the pattern is present; <c>false</c> otherwise
		/// </returns>
		/// <param name="list">
		/// The list to check
		/// </param>
		/// <param name="startIndex">
		/// The index in <paramref name="list"/> to start with
		/// </param>
		/// <param name="tester">
		/// A method that takes the current element in <paramref name="list"/>
		/// and the current element in <paramref name="pattern"/> and returns a boolean
		/// stating whether they match
		/// </param>
		/// <param name="pattern">
		/// The set of elements to look for
		/// </param>
		/// <typeparam name="T">
		/// The list element type
		/// </typeparam>
		public static bool IsPatternPresent<T>(this IList<T> list, int startIndex, Func<T, T, bool> tester, params T[] pattern)
		{
			int listIndex;
			for (int patternIndex=0; patternIndex!=pattern.Length; patternIndex++)
			{
				// calculate the index in the list
				listIndex = startIndex + patternIndex;

				// make sure the index is within bounds
				if (listIndex >= list.Count)
				{
					return false;
				}

				// test the elements
				if (!tester(list[listIndex], pattern[patternIndex]))
				{
					return false;
				}
			}

			return true;
		}
		#endregion Is pattern present
	}
}