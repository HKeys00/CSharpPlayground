// See https://aka.ms/new-console-template for more information
using Lambdas;

//Capturing variables in lambda expressions
Console.WriteLine("##### Capturing variables in lambda expressions #####");

var methodParameter = "This is a method parameter";
var lambdaParameter = "This is a lambda parameter";
var capturingVariables = new CapturingVariables();

var logLambda = capturingVariables.CreateLogAction(methodParameter);
logLambda.Invoke(lambdaParameter);

var alterLambda = capturingVariables.CreateAlterAction(methodParameter);
alterLambda.Invoke(lambdaParameter);

Console.WriteLine("Instance Field: {0}", capturingVariables.InstanceField);
Console.WriteLine("Method Parameter: {0}", methodParameter);
Console.WriteLine("Lambda Parameter {0}", lambdaParameter);

var listLambdas = capturingVariables.CreateActions();
listLambdas.ForEach(l => l.Invoke());

var counterLambda = capturingVariables.CreateCountingActions();
counterLambda[0].Invoke();
counterLambda[0].Invoke();
counterLambda[1].Invoke();
counterLambda[1].Invoke();

Console.WriteLine("###################################");
//

//Expression Trees
Console.WriteLine("##### Expression Trees #####");

var expressionTrees = new ExpressionTrees();

var expression = expressionTrees.CreateExpression();
Console.WriteLine(expression);

expressionTrees.InspectExpression();
expressionTrees.GetProducts("Desk Chair", "Furniture", 200);
expressionTrees.GetProducts(null, "Stationery", 10);
expressionTrees.GetProducts(null, "Electronics", 100);

Console.WriteLine("###################################");
//