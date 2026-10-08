using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace PruebaFicheros7
{
    public class ADOConnected
    {
		public List<Tuple<int, string, float>> Connect()
		{
			//string connectionString = "Driver={MySQL ODBC 8.0 Driver};Server=localhost;Database=mi_bd;Uid=usuario;Pwd=clave;";
			//OdbcConnection connection = new OdbcConnection(connectionString);
			OdbcConnection connection = new OdbcConnection(string.Empty);
			List<Tuple<int, string, float>> table1 = new List<Tuple<int, string, float>>();

			try
			{
				connection.Open();
				OdbcCommand command = connection.CreateCommand();

				command.CommandText = "SELECT Param1, Param2, Param3 FROM Table1 WHERE Param1 = @Param1Where";

				command.Parameters.Add(new OdbcParameter("@Param1",10));
				OdbcDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					table1.Add(new Tuple<int, string, float>(
						reader.GetInt32(0),
						reader.GetString(1),
						reader.GetFloat(2)
					));
				}
				connection.Close();

			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
			finally
			{
				if (connection.State != ConnectionState.Closed)
				{
					connection.Close();
				}
				if (connection != null)
				{
					//libera memoria
					connection.Dispose();
				}
			}
			return table1;
        }
		public int Execute()
		{
			int rowsAffected = 0;
			OdbcConnection connection = new OdbcConnection(string.Empty);
			OdbcTransaction transaction = null;
			try
			{
				connection.Open();
				OdbcCommand command = connection.CreateCommand();

				command.CommandText = "INSERT INTO Table1 (Param1,Param2,Param3) VALUES (@Param1,@Param2,@Param3)";
				command.Parameters.Add(new OdbcParameter("@Param1", 11));
				command.Parameters.Add(new OdbcParameter("@Param2", "Leila"));
				command.Parameters.Add(new OdbcParameter("@Param1", 150.43));

				transaction = connection.BeginTransaction();
				rowsAffected = command.ExecuteNonQuery();	
				connection.Close();

			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
				if (transaction != null)
				{
					transaction.Rollback();
					transaction.Dispose();
				}
			}
			finally
			{
				if (connection.State != ConnectionState.Closed)
				{
					connection.Close();
				}
				if (connection != null)
				{
					connection.Dispose();
				}
				if (transaction != null)
				{
					transaction.Commit();
				}
			}
			return rowsAffected;
		}
	}
}


