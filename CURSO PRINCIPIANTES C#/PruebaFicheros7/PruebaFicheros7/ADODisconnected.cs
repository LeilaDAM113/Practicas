using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
namespace PruebaFicheros7
{
    public class ADODisconnected
    {
        public void Connection()
        {
			//string connectionString = "Driver={MySQL ODBC 8.0 Driver};Server=localhost;Database=mi_bd;Uid=usuario;Pwd=clave;";
			//OdbcConnection connection = new OdbcConnection(connectionString);
			OdbcConnection connection = new OdbcConnection(string.Empty);

            try
            {
				connection.Open();
                OdbcCommand com=connection.CreateCommand();
                com.CommandText = "SELECT Param1, Param2, Param3 FROM table1";
                OdbcDataAdapter dataAdapter= new OdbcDataAdapter(com);
                DataSet ds=new DataSet();
                dataAdapter.Fill(ds);
				DataRow nuevaFila = ds.Tables[0].NewRow();
				nuevaFila["Param1"] = "Valor 1";
				nuevaFila["Param2"] = "Valor 2";
				nuevaFila["Param3"] = "Valor 3";

				ds.Tables[0].Rows.Add(nuevaFila);

				connection.Close();
			}
            catch (Exception ex)
            {
				Console.WriteLine($"Error en la base de datos: {ex.Message}");
			}
			finally
			{
				if (connection != null && connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}
    }
}
	
}