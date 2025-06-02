using FirstProject.Services;

namespace FirstProject.Demos
{
    public static class CalculatorDemo
    {
        public static void Run()
        {
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

            int sum = Calculator.Add(number1, number2);

            Console.WriteLine($"La somme est : {sum}");

            Console.WriteLine();

            Console.WriteLine("Les nombres de 1 à 10 sont :");
            Calculator.PrintNumbersFrom1To10();
        }
    }
}
