using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSys
{
    public partial class admincs : Form
    {
        public admincs()
        {
            InitializeComponent();
        }

        private void btnAlogin_Click(object sender, EventArgs e)
        {
            if (txtpw.Text=="ADMIN123")
            {
                books obj = new books();
                obj.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }

        private void lblcancel_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            if (chb.Checked)
            {
                txtpw.UseSystemPasswordChar = false;
            }

            else
            {
                txtpw.UseSystemPasswordChar = true;
            }
        }

        private void admincs_Load(object sender, EventArgs e)
        {
            txtpw.UseSystemPasswordChar = true;
        }
    }
}
