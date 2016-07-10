using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace DaTools.NameMaker
{
    public static class Creator
    {
        public static string Build(string[] firstList, string[] secondList)
        {
            StringBuilder toReturn = new StringBuilder();
            Random rand = new Random(DateTime.Now.Millisecond);
            toReturn.Append(ChoiseFromElems(firstList, rand));
            toReturn.Append(".");
            toReturn.Append(ChoiseFromElems(secondList, rand));

            return toReturn.ToString();
        }

        public static string Build(NameType firstPart, NameType secondPart)
        {
            StringBuilder toReturn = new StringBuilder();

            string firstRessourceName = ExtractRessouceName(firstPart);
            string secondRessourceName = ExtractRessouceName(secondPart);

            var assembly = Assembly.GetExecutingAssembly();

            Random rand = new Random(DateTime.Now.Millisecond);

            string[] elems = GetElems(firstRessourceName, assembly);
            toReturn.Append(ChoiseFromElems(elems, rand));

            if(firstPart != secondPart)
            {
                elems = GetElems(secondRessourceName, assembly);
            }

            toReturn.Append(".");
            toReturn.Append(ChoiseFromElems(elems, rand));

            return toReturn.ToString();
        }

        private static string ChoiseFromElems(string[] elems, Random rand)
        {
            string toReturn;
            int numberOfLines = elems.Length;

            int randLine = rand.Next(0, numberOfLines);

            toReturn = elems.Skip(randLine).Take(1).First();
            return toReturn;
        }

        private static string[] GetElems(string firstRessourceName, Assembly assembly)
        {
            string myFile = String.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(firstRessourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                myFile = reader.ReadToEnd();
            }
            return myFile.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static string ExtractRessouceName(NameType part)
        {
            string ressourceName;
            switch (part)
            {
                case NameType.FIRST_NAMES:
                    ressourceName = "DaTools.NameMaker.Sources.Names.txt";
                    break;
                case NameType.ANIMALS:
                    ressourceName = "DaTools.NameMaker.Sources.Animals.txt";
                    break;
                case NameType.GENUS:
                    ressourceName = "DaTools.NameMaker.Sources.Genus.txt";
                    break;
                case NameType.SPECIES:
                    ressourceName = "DaTools.NameMaker.Sources.Species.txt";
                    break;
                default:
                    throw new Exception("Type non pris en charge");
            }

            return ressourceName;
        }
    }
}
