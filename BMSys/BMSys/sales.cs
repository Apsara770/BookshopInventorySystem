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
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
            DisplaySales();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\BookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void lblclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplaySales()
        {
            Con.Open();
            string query = "select * from BillTbl "; 
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvsreports.DataSource = ds.Tables[0];
            Con.Close();
        }
        

        private void sales_Load(object sender, EventArgs e)
        {

        }
    }
}
