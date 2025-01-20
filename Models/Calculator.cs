namespace FirstProject.Models
{
  public class Calculator
  {
    public int Add(int number1, int number2)
    {
      return number1 + number2;
    }

    public void PrintNumbersFrom1To10()
    {
      for (int i = 1; i <= 10; i++)
      {
        Console.WriteLine(i);
      }
    }
  }
}
