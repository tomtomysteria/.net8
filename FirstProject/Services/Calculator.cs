namespace FirstProject.Services
{
    public static class Calculator
    {
        public static int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public static void PrintNumbersFrom1To10()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
