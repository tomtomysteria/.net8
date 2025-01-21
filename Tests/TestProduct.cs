using FirstProject.Models.Product;

namespace FirstProject.Tests
{
    public static class TestProduct
    {
        public static void Run()
        {
            Console.WriteLine("Produits supérieurs à 50 euros : ");
            Console.WriteLine("================================");

            List<Product> products = [];

            for (int i = 1; i <= 15; i++)
            {
                var product = new Product(i, $"Product {i}", i * 10);
                products.Add(product);
            }

            var expensiveProducts = products.Where(p => p.Price > 50).OrderByDescending(p => p.Price);

            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"Produit ID: {product.Id}, Nom: {product.Name}, Prix: {product.Price}");
            }
        }
    }
}
