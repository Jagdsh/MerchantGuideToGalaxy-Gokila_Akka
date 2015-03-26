using System;
using MerchantGuideToGalaxy;
using StructureMap;

namespace MerchantGuideTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = ObjectFactory.GetInstance<MerchantCalculator>();
            while (true)
            {
                Console.WriteLine(calculator.Calculate(Console.ReadLine()));
            }
        }
    }
}