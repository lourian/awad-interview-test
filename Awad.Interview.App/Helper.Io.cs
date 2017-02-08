namespace Awad.Interview.App
{
    using System;
    using System.IO;
    using System.Net;
    using Practices;

    internal static partial class Helper
    {
        public static class Io
        {
            public static Range<IPAddress> GetBounds(Ip ip)
            {
                var x = ReadIpAddress(ip.Parser);
                var y = ReadIpAddress(ip.Parser);

                return new Range<IPAddress>(ip.Comparer, ip.Min(x, y), ip.Max(x, y), RangeType.Strict);
            }

            public static ISequence<IPAddress> GetSource(string fileName, Ip ip)
            {
                return new TextStreamSequence<IPAddress>(
                    File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read),
                    ip.Parser);
            }

            public static void AnyKey(string message = null)
            {
                Console.Write(message ?? "Press any key...");
                Console.ReadKey();
            }

            public static void Result(IPAddress[] result)
            {
                if (result.Length == 0)
                {
                    Console.WriteLine("There is no addresses in bounds.");
                }
                else
                {
                    Console.WriteLine("The following addresses are in bounds: ");

                    foreach (var i in result)
                    {
                        Console.WriteLine(i);
                    }

                    Console.WriteLine($"Total: {result.Length}");
                }
            }

            private static IPAddress ReadIpAddress(IParser<IPAddress> parser)
            {
                IPAddress result = null;

                do
                {
                    Console.Write("Input IP address: ");
                    result = parser.Parse(Console.ReadLine());
                }
                while (result == null);

                return result;
            }
        }
    }
}
