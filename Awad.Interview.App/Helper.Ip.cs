namespace Awad.Interview.App
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Practices;

    internal static partial class Helper
    {
        public class Ip
        {
            #region Ctor

            public Ip(IComparer<IPAddress> comparer, IParser<IPAddress> parser)
            {
                if (comparer == null)
                    throw new ArgumentNullException(nameof(comparer));
                if (parser == null)
                    throw new ArgumentNullException(nameof(parser));

                Comparer = comparer;
                Parser = parser;
            }

            #endregion

            #region Properties

            public IComparer<IPAddress> Comparer { get; }

            public IParser<IPAddress> Parser { get; }

            #endregion

            #region Methods

            public IPAddress Max(IPAddress left, IPAddress right)
                => Comparer.Compare(left, right) < 0 ? right : left;

            public IPAddress Min(IPAddress left, IPAddress right)
                => Comparer.Compare(left, right) < 0 ? left : right;

            #endregion
        }
    }
}