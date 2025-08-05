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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\BookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string UN;

        public object Sda { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "SELECT COUNT(*) FROM UserTbl WHERE UserName = @UserName AND UserPassword = @UserPassword";

                // Using SqlCommand with parameters to prevent SQL injection
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@UserName", txtUN.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", txtPS.Text);

                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        UN = txtUN.Text;
                        billing obj = new billing();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred

                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            admincs obj = new admincs();
            obj.Show();
            this.Hide();
        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            if (chb .Checked)
            {
                txtPS.UseSystemPasswordChar = false  ;
            }

            else
            {
                txtPS.UseSystemPasswordChar = true  ;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPS.UseSystemPasswordChar = true;
        }
    }
}
