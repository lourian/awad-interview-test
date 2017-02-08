namespace Awad.Interview.Practices
{
    /// <summary>
    /// Provides an interface to the parser.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public interface IParser<T>
    {
        #region Methods

        /// <summary>
        /// Parses string to an instance of the <see cref="T"/> type.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>
        /// An instance of the <see cref="T"/> type or null.
        /// </returns>
        T Parse(string source);

        #endregion
    }
}
