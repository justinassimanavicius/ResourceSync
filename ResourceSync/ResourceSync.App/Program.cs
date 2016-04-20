using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceSync.Engine;

namespace ResourceSync.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Exporter().Export());

            Console.Read();
        }
    }
}
