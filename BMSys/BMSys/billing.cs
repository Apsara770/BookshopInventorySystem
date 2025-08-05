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
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\BookShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from BookTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvblist.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void UpdateBook()
        {
            int newqty = stock - Convert.ToInt32(txtqttity.Text);
            try
            {
                Con.Open();
                string query = "update BookTbl set BookQuantity =" + newqty + "where BookId =" + key ;
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                populate();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }
       

        private void lbllogout_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        
        private void btnreset_Click(object sender, EventArgs e)
        {
            Reset();
        }


        int n = 0 , Grdtotal = 0 ;
        private void btnAbill_Click(object sender, EventArgs e)
        {
            if (txtqttity.Text == "" || !int.TryParse(txtqttity.Text, out int quantity) || quantity > stock )
            {
                MessageBox.Show("Not Enough stock, invalid input, or customer name is missing");
            }
            else if (!int.TryParse(txtprice.Text, out int price))
            {
                MessageBox.Show("Invalid Price Input");
            }
            else
            {
                int total = quantity * price;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvbill);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txtbname.Text;
                newRow.Cells[2].Value = quantity;
                newRow.Cells[3].Value = price;
                newRow.Cells[4].Value = total;
                dgvbill.Rows.Add(newRow);
                n++;
                UpdateBook();
                Grdtotal += total;
                lbltotal.Text = "Rs. " + Grdtotal;
            }

        }
        int prodid, prodqty, prodprice, tottal, pos = 60;
        string prodname;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }




        private void Reset()
        {
            txtbname.Text = "";
            txtcname.Text = "";
            txtprice.Text = "";
            txtqttity.Text = "";
            lbltotal.Text = "";
        }

        int key = 0 ,stock = 0;
        private void dgvblist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbname.Text = dgvblist.SelectedRows[0].Cells[1].Value.ToString();
            txtprice.Text = dgvblist.SelectedRows[0].Cells[5].Value.ToString();

            if (txtbname .Text =="")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvblist.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(dgvblist.SelectedRows[0].Cells[4].Value.ToString());

            }
        }

        private void billing_Load(object sender, EventArgs e)
        {
            lblusername.Text = Login.UN;
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    
            {
            e.Graphics.DrawString("Sarasavi Book Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Blue, new Point(78,10));
            e.Graphics.DrawString("No:24, Kandy Road,Kurunegala", new Font("Century Gothic", 9, FontStyle.Bold), Brushes.Black, new Point(8, 30));
            e.Graphics.DrawString("037-8934562", new Font("Century Gothic", 9, FontStyle.Bold), Brushes.Black, new Point(8, 45));
            e.Graphics.DrawString("Payment Receipt", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(86, 60));
            e.Graphics.DrawString("------------------------------------------------------", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(1, 70));
            e.Graphics.DrawString("ID  ITEM    PRICE     QUANTITY  TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(26, 80));

            foreach (DataGridViewRow row in dgvbill.Rows)
            {

                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString(" " + prodid, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(26, pos + 40));
                e.Graphics.DrawString(" " + prodname, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(45, pos + 40));
                e.Graphics.DrawString(" " + prodqty, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(110, pos + 40));
                e.Graphics.DrawString(" " + prodprice, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(165, pos + 40));
                e.Graphics.DrawString(" " + tottal, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(245, pos + 40));
                pos = pos + 20;
            }
            e.Graphics.DrawString("------------------------------------------------------", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(10, pos + 70));
            e.Graphics.DrawString("Grand Total : RS." + Grdtotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(50, pos + 90));
            e.Graphics.DrawString("-------------Sarasavi Book Store-------------", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(14, pos + 115));
            e.Graphics.DrawString("                   Thankyou!          ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(14, pos + 135));
           
            dgvbill.Rows.Clear();
            dgvbill.Refresh();
            pos = 100;
            Grdtotal = 0;
            n = 0;

            }


        private void printPreviewDialog1_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (txtbname.Text == "" || txtcname.Text =="")
            {
                MessageBox.Show("Please enter the client name");
            }
            else


            {
                try
                {
                    Con.Open();
                    string query = "insert into BillTbl (UserName, ClientName, Ammount) VALUES (@UserName, @ClientName, @Ammount)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@UserName", lblusername.Text);
                    cmd.Parameters.AddWithValue("@ClientName", txtcname.Text);
                    cmd.Parameters.AddWithValue("@Ammount", Grdtotal);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved Successfully");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
               

                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 350, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        

        }

        private void SearchBooks()
        {
            try
            {
                Con.Open();
                string query = "select * from BookTbl where BookTitle LIKE @BookTitle";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                sda.SelectCommand.Parameters.AddWithValue("@BookTitle", "%" + txtsearch.Text.Trim() + "%");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvblist.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void btnsearchbooks_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

       

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
