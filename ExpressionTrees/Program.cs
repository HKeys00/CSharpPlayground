// See https://aka.ms/new-console-template for more information
using ExpressionTrees;

Console.WriteLine("Hello, World!");

var users = new List<User>
{
    new User { Age = 25, Name = "Alice" },
    new User { Age = 40, Name = "Bob" },
    new User { Age = 18, Name = "Charlie" }
}.AsQueryable();

var filter = new FilterRequest { Field = "Age", Operator = "GreaterThan", Value = 30 };

// Build predicate dynamically
var predicate = Expressions.BuildPredicate<User>(filter);

// Apply to query
var results = users.Where(predicate).ToList();
