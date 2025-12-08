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