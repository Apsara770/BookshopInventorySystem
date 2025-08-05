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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\BookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void lblammount_Click(object sender, EventArgs e)
        {
            sales obj = new sales();
            obj.Show();
            
        }

        private void lblbooks_Click(object sender, EventArgs e)
        {
            books obj = new books();
            obj.Show();
            this.Hide();
        }

        private void lbluser_Click(object sender, EventArgs e)
        {
            users obj = new users();
            obj.Show();
            this.Hide();
        }

        private void lblbilling_Click(object sender, EventArgs e)
        {
            billing obj = new billing();
            obj.Show();
            this.Hide();
        }

        private void lbllogout_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            {
                Con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select sum(BookQuantity) from BookTbl", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt );
                lblBStock.Text = dt.Rows[0][0].ToString();

                SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Ammount) from BillTbl", Con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                lblammount.Text = "RS." + dt1.Rows[0][0].ToString();

                SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from UserTbl", Con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                lblUStock.Text = dt2.Rows[0][0].ToString();

                Con.Close();

            }
        }
    }
}
