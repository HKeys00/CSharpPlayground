// See https://aka.ms/new-console-template for more information
using DynamicTyping;

dynamic obj = new SimpleDynamicExample();

obj.ThisIsAMethodCall("You know who");
Console.WriteLine(obj.ThisIsAProperty);