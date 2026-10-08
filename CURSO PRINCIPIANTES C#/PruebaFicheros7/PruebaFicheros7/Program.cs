using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruebaFicheros7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Actor actor=new Actor();
            actor.age = 20;
            actor.theatre = false;
            actor.name = "Fulanito";

            string json = JsonConvert.SerializeObject(actor);
        }
    }
}
