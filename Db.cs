using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePrijimacihoRizeni_Vilimek;

internal class Db
{
	private static string connectionString { get =>
			"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\orbit\\source\\repos\\EvidencePrijimacihoRizeni_Vilimek\\DbFiles\\EvidencePrijimacihoRizeniDb.mdf;Integrated Security=True;Connect Timeout=30";
			}
	public static void test()
	{
		using SqlConnection connection = new SqlConnection(connectionString);
		using SqlCommand command = new SqlCommand("SELECT * from user_idk_complicated_name", connection);
		connection.Open();
		var a = command.ExecuteScalar();
		var b = "";
	}
}
