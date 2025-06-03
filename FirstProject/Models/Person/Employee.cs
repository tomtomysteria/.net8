namespace FirstProject.Models.Person
{
    public class Employee : Person
    {

        public double Salary { get; set; }

        public Employee(int id, string firstName, string lastName, int age, double salary) : base(id, firstName, lastName, age)
        {
            Salary = salary;
        }

        public override void IntroduceOneself()
        {
            Console.WriteLine($"Je m'appelle {FirstName} {LastName}, j'ai {Age} ans et mon salaire est de {Salary}.");
        }
    }
}
