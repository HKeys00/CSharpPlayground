using System.Linq.Expressions;

namespace Lambdas
{
    public class ExpressionTrees
    {
        private List<Product> _products = new()
        {
            new Product { Name = "Pro C# 10", Category = "Books", Price = 45.99 },
            new Product { Name = "Gaming Mouse", Category = "Electronics", Price = 29.99 },
            new Product { Name = "LED Monitor", Category = "Electronics", Price = 199.99 },
            new Product { Name = "The Pragmatic Programmer", Category = "Books", Price = 19.99 },
            new Product { Name = "Desk Chair", Category = "Furniture", Price = 89.50 },
            new Product { Name = "Notebook", Category = "Stationery", Price = 3.25 },
            new Product { Name = "Bluetooth Speaker", Category = "Electronics", Price = 49.99 },
            new Product { Name = "Pen Pack", Category = "Stationery", Price = 5.75 },
            new Product { Name = "Intro to LINQ", Category = "Books", Price = 17.95 },
            new Product { Name = "Standing Desk", Category = "Furniture", Price = 250.00 }
        };

        public Expression<Func<int , int, int>> CreateExpression()
        {
            return (x, y) => x + y;
        }

        public void InspectExpression()
        {
            var expression = CreateExpression();

            Console.WriteLine("Expression body NodeType {0}", expression.Body.NodeType);
            Console.WriteLine("Expression body Type {0}", expression.Body.Type);
            Console.WriteLine("Expression Parameters Count {0}", expression.Parameters.Count);
            Console.WriteLine("Expression First Parameter Type {0}", expression.Parameters[0].Type);
            Console.WriteLine("Expression Second Parameter Type {0}", expression.Parameters[1].Type);
        }

        public void GetProducts(string? name, string category, double maxPrice)
        {
            var productName = Expression.Constant(name, typeof(string));
            var productCategory = Expression.Constant(category, typeof(string));
            var productMaxPrice = Expression.Constant(maxPrice, typeof(double));

            var productParameter = Expression.Parameter(typeof(Product), "p");

            var nameProperty = Expression.Property(productParameter, "Name");
            var categoryProperty = Expression.Property(productParameter, "Category");
            var priceProperty = Expression.Property(productParameter, "Price");

            var nameQuery = Expression.Equal(productName, nameProperty);
            var categoryQuery = Expression.Equal(productCategory, categoryProperty);
            var priceQuery = Expression.LessThanOrEqual(priceProperty, productMaxPrice);

            var query = Expression.And(priceQuery, categoryQuery);
            if(!string.IsNullOrEmpty(name))
            {
                query = Expression.AndAlso(query, nameQuery);
            }


            Func<Product, bool> lambda = Expression.Lambda<Func<Product, bool>>(query, productParameter).Compile();

            var products = _products.Where(lambda);

            foreach (var product in products)
            {
                Console.WriteLine("Name {0}, Category {1}, Price {2}", product.Name, product.Category, product.Price);
            }
        }

        //Test class.
        private class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
        }
    }
}
