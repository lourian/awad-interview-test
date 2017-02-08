namespace Awad.Interview.Practices
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Sequence which reads content from text stream.
    /// </summary>
    public class TextStreamSequence<T> : ISequence<T>
    {
        #region Fields

        private readonly StreamReader _reader;
        private readonly IParser<T> _parser;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes an instance of the <see cref="TextStreamSequence"/> type.
        /// </summary>
        /// <param name="stream">The target stream.</param>
        /// <param name="parser">The parser to parse entity.</param>
        public TextStreamSequence(Stream stream, IParser<T> parser)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            _reader = new StreamReader(stream);
            _parser = parser;
        }

        #endregion

        #region IDisposable

        public void Dispose() => _reader.Dispose();

        #endregion

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            while (!_reader.EndOfStream)
            {
                yield return _parser.Parse(_reader.ReadLine());
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
