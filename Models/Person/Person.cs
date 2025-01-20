namespace FirstProject.Models.Person
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void IntroduceOneself()
        {
            Console.WriteLine($"Je m'appelle {Name} et j'ai {Age} ans.");
        }

    }
}
