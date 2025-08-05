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
    public partial class books : Form
    {
        public books()
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
            dgvbooks.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Filter()
        {
            if (cbcatlist.SelectedItem != null)
            {
                Con.Open();
                string query = "select * from BookTbl where BookCategories='" + cbcatlist.SelectedItem.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dgvbooks.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbluser_Click(object sender, EventArgs e)
        {
            users obj = new users();
            obj.Show();
            this.Hide();
        }

        private void lbldashboard_Click(object sender, EventArgs e)
        {
            dashboard obj = new dashboard();
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtbtitle.Text.Trim() == "" || txtbauthor.Text.Trim() == "" || txtqty.Text.Trim() == "" || txtprice.Text.Trim() == "" || cbcat.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into BookTbl Values('" + txtbtitle.Text + "','" + txtbauthor.Text + "','" + cbcat.SelectedItem.ToString() + "','" + txtqty.Text + "','" + txtprice.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Saved Succesfully");
                    Con.Close();
                    populate();
                    Reset();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void cbcatlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            populate();
            cbcatlist.SelectedIndex = -1;
        }

        private void Reset()
        {
            txtbtitle.Text = "";
            txtbauthor.Text = "";
            cbcat.SelectedIndex = -1;
            txtprice.Text = "";
            txtqty.Text = "";
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        int key = 0;
        private void dgvbooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbtitle.Text = dgvbooks.SelectedRows[0].Cells[1].Value.ToString();
            txtbauthor.Text = dgvbooks.SelectedRows[0].Cells[2].Value.ToString();
            cbcat.SelectedItem = dgvbooks.SelectedRows[0].Cells[3].Value.ToString();
            txtqty.Text = dgvbooks.SelectedRows[0].Cells[4].Value.ToString();
            txtprice.Text = dgvbooks.SelectedRows[0].Cells[5].Value.ToString();

            if (txtbtitle .Text =="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvbooks.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from BookTbl where BookId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted Succesfully");
                    Con.Close();
                    populate();
                    Reset();
                       
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtbtitle.Text.Trim() == "" || txtbauthor.Text.Trim() == "" || txtqty.Text.Trim() == "" || txtprice.Text.Trim() == "" || cbcat.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update BookTbl set BookTitle = @BookTitle, BookAuthor = @BookAuthor, BookCategories = @BookCategories, BookQuantity = @BookQuantity, BookPrice = @BookPrice where BookId = @BookId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@BookTitle", txtbtitle.Text);
                    cmd.Parameters.AddWithValue("@BookAuthor", txtbauthor.Text);
                    cmd.Parameters.AddWithValue("@BookCategories", cbcat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@BookQuantity", int.Parse(txtqty.Text)); // Assuming quantity is an integer
                    cmd.Parameters.AddWithValue("@BookPrice", decimal.Parse(txtprice.Text)); // Assuming price is a decimal
                    cmd.Parameters.AddWithValue("@BookId", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Updated Successfully");
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
                finally
                {
                    Con.Close();
                }
                populate();
                Reset();
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
                dgvbooks.DataSource = dt;

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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }
    }
}
