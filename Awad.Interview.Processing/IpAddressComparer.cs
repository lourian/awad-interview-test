namespace Awad.Interview.Processing
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    internal class IpAddressComparer : IComparer<IPAddress>
    {
        #region IComparer

        public int Compare(IPAddress left, IPAddress right)
            => ConvertToUInt(left).CompareTo(ConvertToUInt(right));
    
        #endregion

        #region Methods

        private uint ConvertToUInt(IPAddress target)
            => BitConverter.ToUInt32(target.GetAddressBytes(), 0);

        #endregion
    }
}
