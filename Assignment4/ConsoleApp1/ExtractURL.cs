using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ExtractURL
    {
        static void Main(string[] args)
        {
            string[] urls =
            {
                "https://www.apple.com/iphone",
                "ftp://www.example.com/employee",
                "https://google.com",
                "www.apple.com"
            };
            foreach (string url in urls)
            {
                extract(url);
            }
        }

        static void extract(string url)
        {
            string protocol = "";
            string server = "";
            string resource = "";

            // Find protocol
            int protocolEnd = url.IndexOf("://");
            if (protocolEnd != -1)
            {
                protocol = url.Substring(0, protocolEnd);
                url = url.Substring(protocolEnd + 3); 
            }

            // Find server and resource
            int resourceStart = url.IndexOf('/');
            if (resourceStart != -1)
            {
                server = url.Substring(0, resourceStart);
                resource = url.Substring(resourceStart + 1);
            }
            else
            {
                server = url;
            }

            Console.WriteLine($"[protocol] = \"{protocol}\"");
            Console.WriteLine($"[server] = \"{server}\"");
            Console.WriteLine($"[resource] = \"{resource}\"");
        }
    }

}
