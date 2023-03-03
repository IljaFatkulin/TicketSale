using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TicketSale
{   
    public partial class BuyTickets : Form
    {
        int lastid;
        int selectedTicket = 1;
        int sid;
        int ticketCount = 0;
        string ePrice;
        string eDdate;
        string eAdate;
        string eDcity;
        string eAcity;
        public BuyTickets()
        {
            InitializeComponent();
            if (Authorization.admin == "1")
                Admin();
            showTickets(Authorization.cmdB);
        }
        private void showTickets(string cmd)
        {
            ticketCount = 0;
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand(cmd, db.getConnection());
            string price;
            string ddate;
            string adate;
            string dcity;
            string acity;
            int id; 
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = Int32.Parse(reader["ticket_id"].ToString());
                    price = reader["price"].ToString();
                    ddate = reader["departure_date"].ToString();
                    adate = reader["arrival_date"].ToString();
                    dcity = reader["departure_city"].ToString();
                    acity = reader["arrival_city"].ToString();
                    createTicket(price, ddate, adate, dcity, acity, id);
                    selectedTicket++;
                    if (lastid < id)
                        lastid = id;
                }
            }
            db.closeConnection();

        }
        private void createTicket(string price, string ddate, string adate, string dcity, string acity, int id)
        {
            ticketCount++;
            Panel pnl = new Panel();
            Label p = new Label();
            Label dd = new Label();
            Label ad = new Label();
            Label dc = new Label();
            Label ac = new Label();
            Label ID = new Label();
            ID.ForeColor = Color.Red;
            ID.Text = "ID: " + id.ToString();
            ID.Location= new Point(0, 0);
            Button remove = new Button();
            Button edit = new Button();
            Button buy = new Button();
            p.Text = price;
            p.Location = new Point(0, 45);
            dd.Text = ddate;
            dd.Location= new Point(100, 45);
            ad.Text = adate;
            ad.Location = new Point(300, 45);
            dc.Text = dcity;
            dc.Location = new Point(500, 45);
            ac.Text = acity;
            ac.Location = new Point(600, 45);
            remove.Text = "Remove";
            remove.BackColor = Color.FromArgb(255, 128, 128);
            remove.FlatStyle= FlatStyle.Flat;
            edit.Text = "Edit";
            edit.BackColor = Color.FromArgb(255, 128, 128);
            edit.FlatStyle = FlatStyle.Flat;
            buy.Text = "Buy";
            buy.Size = new Size(95, 45);
            buy.FlatStyle = FlatStyle.Flat;
            if (Authorization.admin == "1")
            {
                remove.Visible = true;
                edit.Visible = true;
                ID.Visible = true;
            }
            else
            {
                remove.Visible = false;
                edit.Visible = false;
                ID.Visible = false;
            }
            remove.Location = new Point(950, 20);
            edit.Location = new Point(950, 60);
            buy.Location = new Point(1070, 30);
            pnl.Location = new Point(27, (selectedTicket) *150);
            pnl.Controls.Add(p);
            pnl.Controls.Add(dd);
            pnl.Controls.Add(ad);
            pnl.Controls.Add(dc);
            pnl.Controls.Add(ac);
            pnl.Controls.Add(ID);
            pnl.Controls.Add(remove);
            pnl.Controls.Add(edit);
            pnl.Controls.Add(buy);
            pnl.BackColor = Color.White;
            pnl.Size = new Size(1200, 100);
            this.Controls.Add(pnl);
            remove.Click += (object sender, EventArgs e) =>
            {
                removeTicket(id);
            };
            edit.Click += (object sender, EventArgs e) =>
            {
                panel2.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                button7.Visible = true;
                button10.Visible = true;
                button9.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = price;
                textBox2.Text = ddate;
                textBox3.Text = dcity;
                textBox4.Text = adate;
                textBox5.Text = acity;
                ePrice = price;
                eDdate = ddate;
                eAdate = dcity;
                eDcity = adate;
                eAcity = acity;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                sid = id;
            };
            buy.Click += (object sender, EventArgs e) =>
            {
                DB db = new DB();
                db.openConnection();
                var cmd = new MySqlCommand($"SELECT `Tickets` FROM `users` WHERE `user_id` = @uid", db.getConnection());
                cmd.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Authorization.user_id;
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string Tickets = reader["Tickets"].ToString();
                db.closeConnection();
                db.openConnection();
                var cmd2 = new MySqlCommand($"UPDATE `users` SET `Tickets` = @ticket_id WHERE `user_id` = @uid", db.getConnection());
                cmd2.Parameters.Add("@ticket_id", MySqlDbType.VarChar).Value = Tickets + id + " ";
                cmd2.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Authorization.user_id;
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                db.closeConnection();
                MessageBox.Show("Payment successful");

                db.openConnection();

                var cmd3 = new MySqlCommand("SELECT `purchases` FROM `tickets` WHERE `ticket_id` = @id", db.getConnection());
                cmd3.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                reader3.Read();
                int purchases = Int32.Parse(reader3["purchases"].ToString());

                db.closeConnection();

                db.openConnection();

                var cmd4 = new MySqlCommand("UPDATE `tickets` SET `purchases` = @p WHERE `ticket_id` = @id", db.getConnection());
                cmd4.Parameters.Add("@p", MySqlDbType.VarChar).Value = purchases+1;
                cmd4.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                cmd4.ExecuteReader();

                db.closeConnection();
            };
        }
        private void Admin()
        {
            button8.Visible= true;
            button5.Visible= true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button8_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Profile p = new Profile();
            p.Show();
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
            button10.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Visible= true;
            textBox2.Visible= true;
            textBox3.Visible= true;
            textBox4.Visible= true;
            textBox5.Visible = true;
            
           
        }
        private void addTicket(string price, string ddate, string adate, string dcity, string acity)
        {
            DB db = new DB();

            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM tickets", db.getConnection());
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = Int32.Parse(reader["ticket_id"].ToString());
                    selectedTicket++;
                    if (lastid < id)
                        lastid = id;
                }
            }
            db.closeConnection();

            db.openConnection();

            var cmd = new MySqlCommand($"INSERT INTO `tickets` (`ticket_id`, `price`, `departure_date`, `arrival_date`, `departure_city`, `arrival_city`) VALUES(@1, @2, @3, @4, @5, @6)", db.getConnection());
            cmd.Parameters.Add("@1", MySqlDbType.VarChar).Value = lastid + 1;
            lastid++;
            cmd.Parameters.Add("@2", MySqlDbType.VarChar).Value = price;
            cmd.Parameters.Add("@3", MySqlDbType.VarChar).Value = ddate;
            cmd.Parameters.Add("@4", MySqlDbType.VarChar).Value = adate;
            cmd.Parameters.Add("@5", MySqlDbType.VarChar).Value = dcity;
            cmd.Parameters.Add("@6", MySqlDbType.VarChar).Value = acity;
            MySqlDataReader reader2 = cmd.ExecuteReader();

            db.closeConnection();
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void removeTicket(int id)
        {
            DB db = new DB();
            db.openConnection();
            var cmd = new MySqlCommand($"DELETE FROM `tickets` WHERE `tickets`.`ticket_id` = @id", db.getConnection());
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            MySqlDataReader reader = cmd.ExecuteReader();
            db.closeConnection();
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void BuyTickets_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            button7.Visible = false;
            button9.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string price = textBox1.Text;
            string ddate = textBox2.Text;
            string adate = textBox4.Text;
            string dcity = textBox3.Text;
            string acity = textBox5.Text;
            addTicket(price, ddate, adate, dcity, acity);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string price = ePrice;
            string ddate = eDdate;
            string adate = eAdate;
            string dcity = eDcity;
            string acity = eAcity;
            if (textBox1.Text.Length != 0)
                price = textBox1.Text;
            if (textBox1.Text.Length != 0)
                ddate = textBox2.Text;
            if (textBox1.Text.Length != 0)
                adate = textBox4.Text;
            if (textBox1.Text.Length != 0)
                dcity = textBox3.Text;
            if (textBox1.Text.Length != 0)
                acity = textBox5.Text;
            editTicket(price, ddate, adate, dcity, acity);
        }
        private void editTicket(string price, string ddate, string adate, string dcity, string acity)
        {
            DB db = new DB();
            db.openConnection();

            var cmd = new MySqlCommand($"UPDATE `tickets` SET `price` = @p, `departure_date` = @dd, `arrival_date` = @ad, `departure_city` = @dc, `arrival_city` = @ac WHERE `tickets`.`ticket_id` = @id", db.getConnection());
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = sid;
            cmd.Parameters.Add("@p", MySqlDbType.VarChar).Value = price;
            cmd.Parameters.Add("@dd", MySqlDbType.VarChar).Value = ddate;
            cmd.Parameters.Add("@ad", MySqlDbType.VarChar).Value = adate;
            cmd.Parameters.Add("@dc", MySqlDbType.VarChar).Value = dcity;
            cmd.Parameters.Add("@ac", MySqlDbType.VarChar).Value = acity;
            MySqlDataReader reader = cmd.ExecuteReader();
            db.closeConnection();
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            string input = "";
            try
            {
                input = textBox6.Text.Remove(0, 1);

            }
            catch
            {
                MessageBox.Show("Incorrect input");
            }
            Authorization.cmdB = "SELECT * FROM tickets WHERE `departure_date` LIKE '" + input + "'";
            MessageBox.Show(Authorization.cmdB);
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            string input = "";
            try
            {
                input = textBox7.Text;

            }
            catch
            {
                MessageBox.Show("Incorrect input");
            }
            Authorization.cmdB = "SELECT * FROM tickets WHERE `arrival_date` LIKE '" + input + "'";
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            string input = "";
            try
            {
                input = textBox8.Text;

            }
            catch
            {
                MessageBox.Show("Incorrect input");
            }
            Authorization.cmdB = "SELECT * FROM tickets WHERE `departure_city` LIKE '" + input + "'";
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            string input = "";
            try
            {
                input = textBox9.Text;

            }
            catch
            {
                MessageBox.Show("Incorrect input");
            }
            Authorization.cmdB = "SELECT * FROM tickets WHERE `arrival_city` LIKE '" + input + "'";
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Authorization.cmdB = "SELECT * FROM tickets";
            BuyTickets b = new BuyTickets();
            b.Show();
            this.Hide();
        }
    }
}
