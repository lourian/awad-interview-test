namespace Awad.Interview.Practices
{
     using System.Collections.Generic;

    public class Range<T>
    {
        #region Fields

        private readonly IComparer<T> _comparer;
        private readonly RangeType _type;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="comparer">An instance of the <see cref="IComparer{T}"/>.</param>
        /// <param name="bounds">An instance of the <see cref="Tuple{T,T}"/> containing bounds.</param>
        public Range(IComparer<T> comparer, T lo, T hi, RangeType type = RangeType.Strict)
        {
            _comparer = comparer;
            _type = type;
            Low = lo;
            High = hi;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the low bound.
        /// </summary>
        public T Low { get;  }

        /// <summary>
        /// Gets the high bound.
        /// </summary>
        public T High { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Checks that <paramref name="target"/> is in range.
        /// </summary>
        /// <returns>
        /// True if range contains the <paramref name="target"/>.
        /// </returns>
        public bool Contains(T target)
        {
            var lo = _comparer.Compare(Low, target);
            var hi = _comparer.Compare(target, High);

            switch (_type)
            {
                case RangeType.StrictLeft:
                    return lo < 0 && hi <= 0;
                case RangeType.StrictRight:
                    return lo <= 0 && hi < 0;
                case RangeType.Unstrict:
                    return lo <= 0 && hi <= 0;
                case RangeType.Strict:
                default:
                    return lo < 0 && hi < 0;
            }
        }

        #endregion
    }
}
