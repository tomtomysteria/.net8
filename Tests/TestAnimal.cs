using FirstProject.Models.Animal;

namespace FirstProject.Tests
{
    public static class TestAnimal
    {
        public static void Run()
        {
            List<Animal> animals = [
                new Cat(),
                new Dog(),
                new Cat(),
                new Dog()
            ];

            foreach (var animal in animals)
            {
                animal.MakeNoise();
            }
        }
    }
}
