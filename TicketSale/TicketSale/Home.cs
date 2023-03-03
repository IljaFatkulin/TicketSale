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

namespace TicketSale
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            mostPopularTicket();
            showNews();
            if (Authorization.admin == "1")
                Admin();
            Design.SetRoundedShape(panel5, 50);
            Design.SetRoundedShape(panel3, 50);

        }
        private void Admin()
        {
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
        }

        private void mostPopularTicket()
        {
            DB db = new DB();

            db.openConnection();

            int purchases = 0;
            string id = "";
            var cmd = new MySqlCommand("SELECT `ticket_id`, `purchases` FROM `tickets`", db.getConnection());
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    int tmp = Int32.Parse(reader["purchases"].ToString());
                    if (tmp > purchases)
                    {
                        purchases = tmp;
                        id = reader["ticket_id"].ToString();
                    }
                }
            };

            db.closeConnection();

            db.openConnection();

            var cmd2 = new MySqlCommand("SELECT * FROM `tickets` WHERE `ticket_id` = @id", db.getConnection());
            cmd2.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            using (MySqlDataReader reader2 = cmd2.ExecuteReader())
            {
                while(reader2.Read())
                {
                    price.Text = reader2["price"].ToString();
                    ddate.Text = reader2["departure_date"].ToString();
                    adate.Text = reader2["arrival_date"].ToString();
                    dcity.Text = reader2["departure_city"].ToString();
                    acity.Text = reader2["arrival_city"].ToString();
                }
            }

                db.closeConnection();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Profile p = new Profile();
            this.Hide();
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
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
        private void showNews()
        {
            DB db = new DB();
            db.openConnection();
            var cmd = new MySqlCommand($"SELECT `text` FROM `news`", db.getConnection());
            MySqlDataReader reader= cmd.ExecuteReader();
            reader.Read();
            label4.Text = reader["text"].ToString();
            reader.Read();
            label5.Text = reader["text"].ToString();
            db.closeConnection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            textBox2.Visible= false;
            button7.Visible = true;
            textBox1.Text = label4.Text;
            textBox1.Visible = true; 
            button6.Visible = false;
            button8.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            textBox1.Visible = false;
            button6.Visible = true;
            textBox2.Text = label5.Text;
            textBox2.Visible = true;
            button7.Visible = false;
            button9.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button6.Visible= true;
            textBox1.Visible = false;
            button8.Visible = false;
            updateNews(1, textBox1.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            textBox2.Visible = false;
            button9.Visible = false;
            updateNews(2, textBox2.Text);
        }

        private void updateNews(int id, string text)
        {
            DB db = new DB();
            db.openConnection();
            var cmd = new MySqlCommand($"UPDATE `news` SET `text` = @text WHERE `id` = @id", db.getConnection());
            cmd.Parameters.Add("@text", MySqlDbType.VarChar).Value = text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            MySqlDataReader reader = cmd.ExecuteReader();
            db.closeConnection();
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aboutus a = new Aboutus();
            this.Hide();
            a.Show();
        }
    }
}
