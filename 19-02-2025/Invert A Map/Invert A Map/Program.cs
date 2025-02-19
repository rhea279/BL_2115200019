using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invert_A_Map
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> inputDict = new Dictionary<string, int>();

            Console.Write("Enter the number of key-value pairs: ");
            int n = int.Parse(Console.ReadLine());

            // Taking user input
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter key: ");
                string key = Console.ReadLine();

                Console.Write("Enter value: ");
                int value = int.Parse(Console.ReadLine());

                inputDict[key] = value; // Adding key-value pair
            }

            // Invert the dictionary
            Dictionary<int, List<string>> invertedDict = InvertMap(inputDict);

            // Display the inverted dictionary
            Console.WriteLine("\nInverted Dictionary:");
            foreach (var entry in invertedDict)
            {
                Console.WriteLine($"{entry.Key} = [ {string.Join(", ", entry.Value)} ]");
            }
        }
        public static Dictionary<V, List<K>> InvertMap<K, V>(Dictionary<K, V> dict)
        {
            Dictionary<V, List<K>> inverted = new Dictionary<V, List<K>>();
            foreach (var pair in dict)
            {
                if (!inverted.ContainsKey(pair.Value))
                {
                    inverted[pair.Value] = new List<K>();
                }
                inverted[pair.Value].Add(pair.Key);
            }
            return inverted;
        }
    }
}
