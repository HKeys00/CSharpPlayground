// See https://aka.ms/new-console-template for more information
using Class_v_Record_v_Struct;

void ManipulateClass(Class c)
{
    c.A = 100;
    c.B = 100;
}

void ManipulateStruct(Struct s)
{
    s.X = 100;
    s.Y = 100;
}

void ManipulateRecord(Record r)
{

}

//Class 
Class c = new Class();

// - Mutable by default
c.A = 10;
c.B = 20;

// - Reference semantics
ManipulateClass(c);
Console.WriteLine("{0} {1}", c.A, c.B);

// - Reference based equality semantics
Class anotherC = new Class();
c.A = 100;
c.B = 100;
Console.WriteLine(c == anotherC);

Class anotherC2 = c;
Console.WriteLine(c == anotherC2);

//Struct
// - Copy semantics
Struct s =  new Struct();
s.X = 100;
s.Y = 100;

Struct anotherS = s;
anotherS.X = 200;

Console.WriteLine("{0} {1}", s.X, s.Y);
Console.WriteLine("{0} {1}", anotherS.X, anotherS.Y);

//Record
//Immutable by default
Record r = new Record("Test", 25);
//r.Age = 25; //*Compiler error

//Value based quality semantics
Record d = new Record("Test", 25);
Console.WriteLine(r == d); //Results in true.

//With keyword
//Can instantiate new records, using another as a base
//Reduces the amount of boilerplate code that would otherwise need to be written
Record newRecord = d with { Age = 30 };

