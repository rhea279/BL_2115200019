
using System;
using System.Collections;
using System.Collections.Generic;

namespace Suppress_Warnings_for_Unchecked_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CS8602
#pragma warning disable CS8600
            ArrayList list = new ArrayList();
            list.Add(12);
            list.Add("hi");
            list.Add(23.78);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
#pragma warning restore CS8602
#pragma warning disable CS8600
        }
    }
}
