using System;

namespace PenguinSyntax
{
	[Serializable]
	public class PenguinSyntaxException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PenguinSyntaxException"/> class
		/// </summary>
		public PenguinSyntaxException()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PenguinSyntaxException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public PenguinSyntaxException(string message) : base (message)
		{
		}

		public PenguinSyntaxException(string messagefmt, params object[] messageargs) : this(String.Format(messagefmt, messageargs))
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PenguinSyntaxException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public PenguinSyntaxException(string message, Exception inner) : base (message, inner)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PenguinSyntaxException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected PenguinSyntaxException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}
}