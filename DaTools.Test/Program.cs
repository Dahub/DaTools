using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaTools.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(NameMaker.Creator.Build(NameMaker.NameType.ANIMALS, NameMaker.NameType.ANIMALS));
            }
            Console.Read();
        }
    }
}
