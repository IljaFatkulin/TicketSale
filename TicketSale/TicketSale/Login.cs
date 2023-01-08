using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using System.Diagnostics;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicketSale
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Design.SetRoundedShape(panel1, 50);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string user = tbLogin.Text;
            string pass = tbPass.Text;
            int tmp = Authorization.login(user, pass);
            if (tmp == 1)
            {
                Home r = new Home();
                r.Show();
                this.Hide();
            }
            
        }

        private void bRegister_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/c start http://localhost/WEB/signup.php");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}