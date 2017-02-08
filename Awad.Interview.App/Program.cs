namespace Awad.Interview.App
{
    using System;
    using System.Linq;
    using System.Net;
    using Autofac;
    using AppStart;
    using static Helper;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Ip ip = App.Container.Resolve<Ip>();

                if (args.Length < 1)
                    throw new ArgumentException("No file name specified.");

                IPAddress[] result;

                var bounds = Io.GetBounds(ip);

                using (var source = Io.GetSource(args[0], ip))
                {
                    result = source
                        .Where(i => i != null && bounds.Contains(i))
                        .ToArray();
                }

                Io.Result(result);
            }
            catch (Exception x)
            {
                Console.WriteLine($"An error occured: {x.Message}");
            }

            Io.AnyKey();
        }
    }
}
