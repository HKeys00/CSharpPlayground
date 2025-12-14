// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Reflection;

List<Character> characters = new List<Character>()
{
    new Thief(),
    new Mage(),
    new Bandit()
};

foreach (Character character in characters)
{
    var type = character.GetType();
    
    Console.WriteLine(type);

    var method = type.GetMethod("BackStab");

    if (method != null)
    {
        method.Invoke(character, null);
    }
    else
    {
        Console.WriteLine("Methods back stab not found");
    }
}

var tyoes = new Type[0];
var type1 = typeof(Character);

var m = Activator.CreateInstance(type1);
var l = type1.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.HasThis, tyoes, null)?.Invoke(null);

var methods = type1.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
var fields = type1.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
var properties = type1.GetProperties(BindingFlags.Instance | BindingFlags.Public);

var field = fields[0];
field.SetValue(m, 5);

var property = properties[0];
property.SetValue(l, 5);
var t = property.GetValue(l);

var type2 = characters[0].GetType();
var type3 = Type.GetType("Character");

Console.ReadLine();