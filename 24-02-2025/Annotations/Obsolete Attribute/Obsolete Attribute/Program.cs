
using System;

namespace Obsolete_Attribute
{
    class LegacyAPI
    {
        [Obsolete("OldFeature() is deprecated.Use NewFeature()",true)]
        public void OldFeature() {
            Console.WriteLine("This is old feature");
        }
        public void NewFeature()
        {
            Console.WriteLine("This is the new feature");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LegacyAPI program = new LegacyAPI();
            program.OldFeature();
            program.NewFeature();
        }
    }
}
