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
    public partial class UserInstruction : Form
    {
        public UserInstruction()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textLV_TextChanged(object sender, EventArgs e)
        {

        }

        private void LV_Click(object sender, EventArgs e)
        {
            textEN.Visible = false;
            textLV.Visible = true;
            LV.BackColor = Color.FromArgb(54, 219, 255);
            EN.BackColor = Color.FromArgb(202, 245, 255);
        }

        private void EN_Click(object sender, EventArgs e)
        {
            textEN.Visible = true;
            textLV.Visible = false;
            EN.BackColor = Color.FromArgb(54, 219, 255);
            LV.BackColor = Color.FromArgb(202, 245, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();
        }
    }
}
