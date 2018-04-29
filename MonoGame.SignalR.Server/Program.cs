using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace MonoGame.SignalR.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine($"Server running on {url}");
                Console.ReadLine();
            }
        }
    }
}
