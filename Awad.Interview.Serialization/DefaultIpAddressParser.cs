namespace Awad.Interview.Serialization
{
    using System.Net;
    using Practices;

    internal class DefaultIpAddressParser : IParser<IPAddress>
    {
        #region IIpAddressParser

        public IPAddress Parse(string source)
            => IPAddress.TryParse(source, out var result)
                ? result
                : null;

        #endregion
    }
}
