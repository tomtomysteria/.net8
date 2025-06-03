namespace FirstProject.Models.Person
{
    public class Student : Person
    {

        public string Ecole { get; set; }
        public double Grade { get; set; }

        public Student(int id, string firstName, string lastName, int age, string ecole, double grade) : base(id, firstName, lastName, age)
        {
            Ecole = ecole;
            Grade = grade;
        }

        public override void IntroduceOneself()
        {
            Console.WriteLine($"Je m'appelle {FirstName} {LastName}, j'ai {Age} ans et j'étudie à {Ecole}.");
        }
    }
}
