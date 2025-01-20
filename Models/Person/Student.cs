namespace FirstProject.Models.Person
{
    public class Student : Person
    {


        public string Ecole { get; set; }

        public Student(string name, int age, string ecole) : base(name, age)
        {
            Ecole = ecole;
        }

        public override void IntroduceOneself()
        {
            Console.WriteLine($"Je m'appelle {Name}, j'ai {Age} ans et j'étudie à {Ecole}.");
        }
    }
}
