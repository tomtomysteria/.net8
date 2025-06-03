using FirstProject.Models.Person;

namespace FirstProject.Demos
{
    public static class PersonDemo
    {
        public static void Run()
        {
            var person1 = new Person(1, "Bruno", "Lampion", 26);
            person1.IntroduceOneself();

            var person2 = new Person(2, "Vanessa", "Dupont", 78);
            person2.IntroduceOneself();

            var student1 = new Student(3, "Léon", "Durant", 32, "Joubert", 15.5);
            student1.IntroduceOneself();

            var student2 = new Student(4, "Jocelyne", "Poupou", 6, "Lycée Voltaire", 14.0);
            student2.IntroduceOneself();

            List<Student> students = [];

            for (int i = 1; i <= 10; i++)
            {
                var student = new Student(i, $"Student {i}", $"LastName {i}", 20 + i, $"School {i}", 10 + i);
                students.Add(student);
            }

            var bestStudents = students
                .Where(s => s.Grade >= 15)
                .OrderByDescending(s => s.Grade)
                .ToList();

            Console.WriteLine("\nMeilleurs étudiants :");
            foreach (var student in bestStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Nom: {student.FirstName} {student.LastName}, Âge: {student.Age}, École: {student.Ecole}, Note: {student.Grade}");
            }

            var averageGrade = students.Average(s => s.Grade);
            Console.WriteLine($"\nNote moyenne des étudiants : {averageGrade:F2}");




            Dictionary<int, Employee> employees = [];
            for (int i = 1; i <= 5; i++)
            {
                var employee = new Employee(i, $"Employee {i}", $"LastName {i}", 30 + i, 2000 + (i * 100));
                employees.Add(employee.Id, employee);
            }

            Console.WriteLine("\nListe des employés :");
            foreach (var employee in employees.Values)
            {
                Console.WriteLine($"ID: {employee.Id}, Nom: {employee.FirstName} {employee.LastName}, Âge: {employee.Age}, Salaire: {employee.Salary}");
            }

            Console.WriteLine("\nEmployé avec l'Id 3 :");
            var specificEmployee = employees.FirstOrDefault(e => e.Key == 3).Value;
            if (specificEmployee != null)
            {
                Console.WriteLine($"ID: {specificEmployee.Id}, Nom: {specificEmployee.FirstName} {specificEmployee.LastName}, Âge: {specificEmployee.Age}, Salaire: {specificEmployee.Salary}");
            }
            else
            {
                Console.WriteLine("Aucun employé trouvé avec l'ID 3.");
            }

            Console.WriteLine("\nEmployés dont l'id est pair :");
            foreach (var employee in employees.Where(e => e.Key % 2 == 0).Select(e => e.Value))
            {
                Console.WriteLine($"ID: {employee.Id}, Nom: {employee.FirstName} {employee.LastName}, Âge: {employee.Age}, Salaire: {employee.Salary}");
            }
        }
    }
}
