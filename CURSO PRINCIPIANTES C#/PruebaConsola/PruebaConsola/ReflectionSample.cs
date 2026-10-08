using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaConsola
{
    [MyAtributte(count =10)]
    public class ReflectionSample
    {
        public int number { get; set; }
		public string name { get; set; }
		public string surName { get; set; }
		public void doSomething()
        {

        }

	}
}
