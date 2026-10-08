using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruebaFicheros7
{
    public class Actor
    {
        [JsonProperty("Nombre")]
        public string name { get; set; }
        [JsonIgnore]
        public bool theatre { get; set; }
        public int age { get; set; }
    }
}
