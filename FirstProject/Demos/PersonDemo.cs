using FirstProject.Models.Person;

namespace FirstProject.Demos
{
    public static class PersonDemo
    {
        public static void Run()
        {
            var person1 = new Person("Bruno", 26);
            person1.IntroduceOneself();

            var person2 = new Person("Vanessa", 78);
            person2.IntroduceOneself();

            var student1 = new Student("Léon", 32, "Joubert");
            student1.IntroduceOneself();

            var student2 = new Student("Jocelyne", 6, "Pompidou");
            student2.IntroduceOneself();
        }
    }
}
