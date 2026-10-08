using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola
{
    public class Song : Media
    {
        public long seconds { get; set; }
       
        public ShelvePosition position { get; set; }
        public string category { get; set; }
        public List<Artist> artists { get; set; }
        public int visits { get; set; }

        public override void play()
        {   
            //el base es como el super en java, accede a los métodos/atributos de la clase padre desde una clase hija
            base.play();
            Console.WriteLine("Increase volume");
        }
        public override bool Equals(object obj)
        {
            var mediaObj = (Media)obj;
            if (mediaObj.title == this.title)
            {
                return true;
            }else{
                return false;
            }
        }
		/* getHashCode permite obtener el identificador único que posea el objeto
        public override int GetHashCode()
        {
			//seria o  return seconds.GetHashCode(); si solo tuviera un atributo o
            int hash = 17;
			 Multiplicamos por otro primo (23) y sumamos el hash de cada propiedad
			hash = (hash * 23) + (Nombre != null ? Nombre.GetHashCode() : 0);
			hash = (hash * 23) + Edad.GetHashCode();
			return hash;		 
		}
        */

		public override string ToString()
        {
            return $"Title: {title} Duration: {seconds}";
        }
    }
}
