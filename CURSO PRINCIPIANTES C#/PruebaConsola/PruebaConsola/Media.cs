using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola
{
    public class Media
    {
		/*abstract: sirve para crear plantillas u obligaciones que otras clases deben cumplir
		 * clases abstractas: Se declaran con public abstract class NombreClase. No se pueden instanciar (no puedes hacer new NombreClase())
		 * metodos abstractos: Se declaran sin cuerpo ni llaves (public abstract void hacerSonido();). Obligan a que cualquier clase hija concreta que herede de la clase abstracta implemente obligatoriamente ese método
		 */
		//default: sirve para obtener el valor predeterminado de un tipo de dato o en estructuras de control
		private int parentRate;

		public string title { get; set; }

		//al marcar una propiedad o método con virtual, nos indicará que permite que una clase hija cambie el comportamiento de un método de la clase padre (este método es sobrecargable (permite override)
		public virtual void play()
        {
            Console.WriteLine($"Playing {title}");

        }
		//visible para la propia clase y la hija
		protected bool thisContentIsCorrectForThisAge(int age) {
            if (age >= parentRate)
            {
                return true;
            } else {
                return false;

            }
        }
    }
}
