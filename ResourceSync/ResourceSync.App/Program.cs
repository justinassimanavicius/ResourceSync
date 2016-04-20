using System;
using System.Collections.Generic;
using System.IO;
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
            //Console.WriteLine(new Exporter().Export());
            
            var input = File.ReadAllText("out.txt");

            new Exporter().Import(input);
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
