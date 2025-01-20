using System;
using FirstProject.Models;

namespace FirstProject
{
    static class Program
    {
        static void Main(string[] args)
        {
            TestCalculator();
            // TestAnotherFeature();
        }

        static void TestCalculator()
        {
            var calculator = new Calculator();

            Console.Write("Entrez le premier nombre : ");
            if (!int.TryParse(Console.ReadLine(), out int number1))
            {
                Console.WriteLine("Saisie invalide. Veuillez entrer un nombre valide.");
                return;
            }

            Console.Write("Entrez le deuxième nombre : ");
            if (!int.TryParse(Console.ReadLine(), out int number2))
            {
                Console.WriteLine("Saisie invalide. Veuillez entrer un nombre valide.");
                return;
            }

            int sum = calculator.Add(number1, number2);

            Console.WriteLine($"La somme est : {sum}");

            Console.WriteLine();

            Console.WriteLine("Les nombres de 1 à 10 sont :");
            calculator.PrintNumbersFrom1To10();
        }

        static void TestAnotherFeature()
        {
            Console.WriteLine("This is another feature.");
        }
    }
}
