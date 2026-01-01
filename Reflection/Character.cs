using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    [DisplayName("Character Display Name")]
    public class Character
    {
        private int field1 = 0;

        [DisplayName("Property Display Name")]
        public int property1 { get; set; }


        public Character()
        {

        }

        [DisplayName("Public Method Display Name")]
        public void PublicMethod()
        {

        }

        private void PrivateMethod()
        {

        }

    }
}
