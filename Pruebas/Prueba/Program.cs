using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Prueba
{
    public class Program
    {
       public static void Main(string[] args)
        {
			string cadena = ConfigurationManager.ConnectionStrings["MiConexionPostgres"].ConnectionString;

			using (var conexion = new NpgsqlConnection(cadena))
			{
				try
				{
					Console.WriteLine("Intentando conectar a PostgreSQL en Docker...");
					conexion.Open();

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("¡Conectado con éxito a PostgreSQL en Docker!");
					Console.ResetColor();

					// Aquí ya puedes escribir tus consultas de SQL (SELECT, INSERT, etc.)

				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error al conectar: " + ex.Message);
					Console.ResetColor();
				}
			}

			Console.WriteLine("\nPresiona ENTER para salir...");
			Console.ReadLine();
		}
	}
    }

