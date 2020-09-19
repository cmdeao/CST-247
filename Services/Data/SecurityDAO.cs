using Activity1Part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NLog;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        string connection = "Data Source=(localdb)\\MSSQLLocalDB;initial catalog=Test ;Integrated Security=True;";
        public bool FindByUser(UserModel user)
        {
            bool succ = false;
            SqlConnection conn = new SqlConnection(connection);
            string query = "SELECT * FROM dbo.Users WHERE USERNAME = @Username AND PASSWORD = @Password";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
            command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
            conn.Open();
            SqlDataReader read = command.ExecuteReader();
            
            if(read.HasRows)
            {
                succ = true;
            }
            read.Close();
            return succ;
        }
    }
}