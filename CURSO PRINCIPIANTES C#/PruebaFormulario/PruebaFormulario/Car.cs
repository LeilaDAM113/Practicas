using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFormulario
{
    public class Car
    {
        public string name { get; set; }
        public string maker { get; set; }

        public override string ToString()
        {
            return $"{name} {maker}";
        }
    }
}
