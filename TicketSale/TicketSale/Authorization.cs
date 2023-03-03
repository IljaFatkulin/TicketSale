using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSale
{
    internal class Authorization
    {
        public static string cmdB;
        public static string user;
        public static string pass;
        public static string user_id;
        public static string status;
        public static string admin;
        static public int login(string u, string p)
        {
            user = u;
            pass = p;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand logIn = new MySqlCommand($"SELECT * FROM `users` WHERE `user_name` = @u AND `password` = @p", db.getConnection());
            logIn.Parameters.Add("@u", MySqlDbType.VarChar).Value = user;
            logIn.Parameters.Add("@p", MySqlDbType.VarChar).Value = pass;
            adapter.SelectCommand = logIn;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.openConnection();
                var cmd = new MySqlCommand($"SELECT `user_id` FROM `users` WHERE `user_name` = @u AND `password` = @p", db.getConnection());
                var cmd2 = new MySqlCommand($"SELECT `Admin` FROM `users` WHERE `user_id` = @uid", db.getConnection());
                cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@p", MySqlDbType.VarChar).Value = pass;
                user_id = cmd.ExecuteScalar().ToString();
                cmd2.Parameters.Add("@uid", MySqlDbType.VarChar).Value = user_id;
                status = cmd2.ExecuteScalar().ToString();
                db.closeConnection();
                return 1;
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
                return 0;
            }
        }
        
        
        
    }
}
