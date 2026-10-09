using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EjemploWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public bool desactivarUsuario(string user)
        {

			string conexion = "Data Source=localhost;Initial Catalog=EJEMPLO_BD;User ID=sa;Password=sqlserver@2026;Encrypt=False";
			contextoDatosDataContext contexto = new contextoDatosDataContext(conexion);
			List<Usuarios> datos = (from r in contexto.Usuarios where r.NombreUsuario.Equals(user) select r).ToList();
            if (datos.Count > 0)
            {
                datos.FirstOrDefault().Activo = false;
                contexto.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
		}

        public void eliminarUsuario(string user)
        {
            string conexion = "Data Source=localhost;Initial Catalog=EJEMPLO_BD;User ID=sa;Password=sqlserver@2026;Encrypt=False";
            contextoDatosDataContext contexto = new contextoDatosDataContext(conexion);
            List<Usuarios> datos = (from r in contexto.Usuarios where r.NombreUsuario.Equals(user) select r).ToList();
            if (datos.Count > 0)
            {
                contexto.Usuarios.DeleteOnSubmit(datos.FirstOrDefault());
                contexto.SubmitChanges();
            }
        }

        public void insertarUsuario(string user, string pass)
        {
			string conexion = "Data Source=localhost;Initial Catalog=EJEMPLO_BD;User ID=sa;Password=sqlserver@2026;Encrypt=False";
			contextoDatosDataContext contexto = new contextoDatosDataContext(conexion);
            Usuarios add_user =new Usuarios();
            add_user.NombreUsuario = user;
            add_user.Pass = pass;
            contexto.Usuarios.InsertOnSubmit (add_user);
            contexto.SubmitChanges();
		}

        public List<Usuarios> obtenerUsuarios()
        {
			string conexion = "Data Source=localhost;Initial Catalog=EJEMPLO_BD;User ID=sa;Password=sqlserver@2026;Encrypt=False";
			contextoDatosDataContext contexto=new contextoDatosDataContext(conexion);
            return (from r in contexto.Usuarios select r).ToList();
        }

        public bool verificarAcceso(string user, string pass)
        {
			string conexion = "Data Source=localhost;Initial Catalog=EJEMPLO_BD;User ID=sa;Password=sqlserver@2026;Encrypt=False";
			contextoDatosDataContext contexto = new contextoDatosDataContext(conexion);
			List<Usuarios> datos = (from r in contexto.Usuarios
									where r.NombreUsuario.Equals(user) && r.Pass.Equals(pass)select r).ToList();
		 return datos.Count > 0; 
		}
    }
}
