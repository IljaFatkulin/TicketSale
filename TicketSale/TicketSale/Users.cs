using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TicketSale
{
    public partial class Users : Form
    {
        string selectedUserId;
        int ticketPosition;
        int ticketNumber;
        public Users()
        {
            InitializeComponent();

            ShowAllUsers();
            
        }
        
        private void DrawTicket(string id)
        {
            ticketNumber++;
            int index = ticketNumber;
            Panel pnl = new Panel();
            Label lbl = new Label();
            Button show = new Button();
            Button remove = new Button();
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(show);
            pnl.Controls.Add(remove);
            panel3.Controls.Add(pnl);
            pnl.BackColor= Color.White;
            pnl.Size = new Size(195, 40);
            pnl.Location = new Point(10, ticketPosition);
            ticketPosition += 60;
            lbl.Location = new Point(10, 10);
            lbl.Size = new Size(40, 15);
            show.Location = new Point(135, 10);
            show.Size = new Size(50, 23);
            remove.Location = new Point(65, 10);
            remove.Size = new Size(65, 23);
            lbl.Text = id;
            show.Text = "show";
            remove.Text = "remove";
            show.Click += (object sender, EventArgs e) =>
            {
                ticket.Visible = true;
                DB db = new DB();
                db.openConnection();

                var cmd = new MySqlCommand("SELECT * FROM `tickets` WHERE `ticket_id` = @id", db.getConnection());
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        price.Text = reader["price"].ToString();
                        ddate.Text = reader["departure_date"].ToString();
                        adate.Text = reader["arrival_date"].ToString();
                        dcity.Text = reader["departure_city"].ToString();
                        acity.Text = reader["arrival_city"].ToString();
                    }
                }

                db.closeConnection();
            };
            remove.Click += (object sender, EventArgs e) =>
            {
                DB db = new DB();
                db.openConnection();

                MySqlCommand cmd = new MySqlCommand("SELECT `Tickets` FROM `users` WHERE `user_id` = @uid", db.getConnection());
                cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = selectedUserId;
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string[] t = reader["Tickets"].ToString().Split(' ');
                string tmp = "";
                db.closeConnection();
                for (int i =0; i < index-1; i++)
                {
                    if(t[i] != "")
                        tmp += t[i] + " ";
                }
                for(int i = index; i < t.Length; i++)
                {
                    if (t[i] != "")
                        tmp += t[i] + " ";
                }
                db.openConnection();
                MySqlCommand cmd2 = new MySqlCommand("UPDATE `users` SET `Tickets` = @t WHERE `user_id` = @uid", db.getConnection());
                cmd2.Parameters.Add("@uid", MySqlDbType.VarChar).Value = selectedUserId;
                cmd2.Parameters.Add("@t", MySqlDbType.VarChar).Value = tmp;
                cmd2.ExecuteReader();
                db.closeConnection();
                ShowTickets();
                MessageBox.Show("Ticket removed");
            };
        }

        private void ShowTickets()
        {
            ticketNumber = 0;
            ticketPosition = 20;
            foreach (Control item in panel3.Controls.OfType<Control>().ToList())
            {
                panel3.Controls.Remove(item);
            }
            DB db = new DB();
            db.openConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT `Tickets` FROM `users` WHERE `user_id` = @uid", db.getConnection());
            cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = selectedUserId;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string[] t = reader["Tickets"].ToString().Split(' ');

            int tmp = 0;
            for(int i = 0; i < t.Length; i++)
            {
                if (t[i] != "") tmp++;
            }
            if (t.Length < 2) return;
            for(int i = 0; i < tmp; i++)
            {

                DrawTicket(t[i]);
            }
            //ShowTicket(Int32.Parse(reader[""])); 

        }
        private void ShowAllUsers()
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users`", db.getConnection());
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tmp = reader["user_name"].ToString();
                    listBox1.Items.Add(tmp);
                }
            }
            db.closeConnection();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ticket.Visible = false;
            panel5.Visible = false;
            string selectedUser = listBox1.SelectedItem.ToString();
            DB db = new DB();
            db.openConnection();
            var cmd = new MySqlCommand($"SELECT * FROM `users` WHERE `user_name` = @u", db.getConnection());
            cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = selectedUser;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    selectedUserId = reader["user_id"].ToString();
                    uID.Text = selectedUserId;
                    uN.Text = reader["user_name"].ToString();
                    if (reader["Admin"].ToString() == "1")
                        uStatus.Text = "Admin";
                    else
                        uStatus.Text = "None";
                    

                }
            }
            db.closeConnection();
            ShowTickets();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void addTicket_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panel5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            var cmd = new MySqlCommand("SELECT `Tickets` FROM `users` WHERE `user_id` = @uid", db.getConnection());
            cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = selectedUserId;
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string tickets = reader["Tickets"].ToString();

            db.closeConnection();

            db.openConnection();

            var cmd2 = new MySqlCommand("UPDATE `users` SET `Tickets` = @t WHERE `user_id` = @uid", db.getConnection());
            cmd2.Parameters.Add("@uid", MySqlDbType.VarChar).Value = selectedUserId;
            cmd2.Parameters.Add("@t", MySqlDbType.VarChar).Value = tickets + textBox1.Text + " ";
            cmd2.ExecuteReader();

            db.closeConnection();
            panel5.Visible = false;
            ShowTickets();
            MessageBox.Show("Ticket added");
        }

        private void adate_Click(object sender, EventArgs e)
        {

        }
    }
}
