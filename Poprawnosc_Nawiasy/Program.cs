using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprawnosc_Nawiasy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();


                string wartosc;
                Console.WriteLine("Proszę wpisać ciąg nawiasów w celu sprawdzenia poprawności:");
                wartosc = Console.ReadLine();

                Console.WriteLine($"Wynik: {TesterNawiasow.sprawdzNawiasyBezWskazywania(wartosc)}");

                Console.ReadKey();
            } while (true);

        }


    }
}
