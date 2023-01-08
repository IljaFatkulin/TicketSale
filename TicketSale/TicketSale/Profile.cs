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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicketSale
{
    public partial class Profile : Form
    {
        DB db = new DB();
        public Profile()
        {
            InitializeComponent();
            showTickets();
            if (Authorization.status == "1" && Authorization.admin != "1")
                Admin();
            else if(Authorization.admin == "1")
                ShowAdmin();
            Design.SetRoundedShape(panel2, 50);
            UpdateData();
        }

        private void UpdateData()
        {
            username.Text = Authorization.user;
            textBox1.Clear();
            textBox2.Clear();
            textBox1.PasswordChar =  '\0';
        }
        
        private void HideAll()
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            confirmP.Visible = false;
            confirmU.Visible = false;
        }
        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void confirmU_Click(object sender, EventArgs e)
        {
            HideAll();

            string user = textBox1.Text;

            db.openConnection();

            var cmd = new MySqlCommand($"UPDATE `users` SET `user_name` = @u WHERE `user_id` = @uid", db.getConnection());
            cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = user;
            cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Authorization.user_id;
            MySqlDataReader reader = cmd.ExecuteReader();
            Authorization.user = user;
            UpdateData();
            MessageBox.Show("Username was changed");

            db.closeConnection();
        }

        private void confirmP_Click(object sender, EventArgs e)
        {
            HideAll();

            string old_password = textBox1.Text;
            string new_password = textBox2.Text;

            if (old_password == Authorization.pass)
            {
                db.openConnection();

                var cmd = new MySqlCommand($"UPDATE `users` SET `password` = @p WHERE `user_id` = @uid", db.getConnection());
                cmd.Parameters.Add("@p", MySqlDbType.VarChar).Value = new_password;
                cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Authorization.user_id;
                MySqlDataReader reader = cmd.ExecuteReader();
                Authorization.pass = new_password;
                UpdateData();
                MessageBox.Show("Password was changed");
            }
            else
            {
                MessageBox.Show("Incorrect old password");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HideAll();
            UpdateData();
            label4.Visible = true;
            textBox1.Visible = true;
            confirmU.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideAll();
            UpdateData();
            label5.Visible = true;
            label6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            confirmP.Visible = true;
            textBox1.PasswordChar = '●';
        }

        public void Admin()
        {
            button7.Visible = true;
        }
        public void ShowAdmin()
        {
            button7.Visible = false;
            label7.Visible = true;
            label8.Visible = true;
            button8.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Authorization.admin = "1";
            button7.Visible = false;
            ShowAdmin();
            MessageBox.Show("You are logged in as admin");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            this.Hide();
            u.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Authorization.cmdB = "SELECT * FROM tickets";
            BuyTickets b = new BuyTickets();
            this.Hide();
            b.Show();
        }
        int ticketPosition = 25;
        private void showTickets()
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT `Tickets` FROM `users` WHERE `user_id` = @uid", db.getConnection());
            cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Authorization.user_id;
            string Tickets = cmd.ExecuteScalar().ToString();
            string[] t = Tickets.Split(' ');
            db.closeConnection();
            for (int i = 0; i < t.Length; i++)
            {
                db.openConnection();
                MySqlCommand tempcmd = new MySqlCommand("SELECT * FROM `tickets` WHERE `ticket_id` = @id", db.getConnection());
                tempcmd.Parameters.Add("id", MySqlDbType.VarChar).Value = t[i];
                string price;
                string ddate;
                string adate;
                string dcity;
                string acity;
                int id;
                using (MySqlDataReader reader = tempcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        price = reader["price"].ToString();
                        ddate = reader["departure_date"].ToString();
                        adate = reader["arrival_date"].ToString();
                        dcity = reader["departure_city"].ToString();
                        acity = reader["arrival_city"].ToString();
                        createTicket(price, ddate, adate, dcity, acity);
                        ticketPosition += 125;
                    }
                }
                db.closeConnection();
            }

        }
        private void createTicket(string price, string ddate, string adate, string dcity, string acity)
        {
            Panel pnl = new Panel();
            Label p = new Label();
            Label dd = new Label();
            Label ad = new Label();
            Label dc = new Label();
            Label ac = new Label();
            p.Text = price;
            p.Location = new Point(0, 45);
            dd.Text = ddate;
            dd.Location = new Point(100, 45);
            ad.Text = adate;
            ad.Location = new Point(300, 45);
            dc.Text = dcity;
            dc.Location = new Point(500, 45);
            ac.Text = acity;
            ac.Location = new Point(600, 45);
            pnl.Location = new Point(27, ticketPosition);
            pnl.Controls.Add(p);
            pnl.Controls.Add(dd);
            pnl.Controls.Add(ad);
            pnl.Controls.Add(dc);
            pnl.Controls.Add(ac);
            pnl.BackColor = Color.White;
            pnl.Size = new Size(730, 100);
            panel2.Controls.Add(pnl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aboutus a = new Aboutus();
            this.Hide();
            a.Show();
        }
    }
}
