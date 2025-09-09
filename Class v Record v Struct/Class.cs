using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_v_Record_v_Struct
{
    public class Class
    {
        public int A { get; set; }

        public int B { get; set; }

        public Action<int> SuperComplicatedAction { get; set; }

        public void SuperComplicatedMethod()
        {

        }
    }

    public class Vehicle
    {
        public string brand = "Ford";

        public void Honk()
        {
            Console.WriteLine("Tuut, tuut!");
        }
    }

    public class Car : Vehicle
    {
        public string modelName = "Mustang";
    }

}
