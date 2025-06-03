namespace FirstProject.Models.Person
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public virtual void IntroduceOneself()
        {
            Console.WriteLine($"Je m'appelle {FirstName} {LastName} et j'ai {Age} ans.");
        }

    }
}
