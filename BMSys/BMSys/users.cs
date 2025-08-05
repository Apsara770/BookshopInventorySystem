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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\BookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void lblbooks_Click(object sender, EventArgs e)
        {
            books obj = new books();
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

        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            string query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvuser.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0;
        private void dgvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtusername.Text = dgvuser.SelectedRows[0].Cells[1].Value.ToString();
            txtphone.Text = dgvuser.SelectedRows[0].Cells[2].Value.ToString();
            txtadd.Text = dgvuser.SelectedRows[0].Cells[3].Value.ToString();
            txtpw.Text = dgvuser.SelectedRows[0].Cells[4].Value.ToString();

            if (txtusername.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dgvuser.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void Reset()
        {
            txtusername.Text = "";
            txtadd.Text = "";
            txtphone.Text = "";
            txtpw.Text = "";
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UserTbl where UserId =" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Succesfully.");
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
            if (txtusername.Text.Trim() == "" || txtadd.Text.Trim() == "" || txtpw.Text.Trim() == "" || txtphone.Text.Trim() == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string query = "update UserTbl set UserName = @UserName, UserPhone = @UserPhone, UserAddress = @UserAddress, UserPassword = @UserPassword where UserId = @UserId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@UserName", txtusername.Text);
                    cmd.Parameters.AddWithValue("@UserPhone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@UserAddress", (txtadd.Text)); // Assuming quantity is an integer
                    cmd.Parameters.AddWithValue("@UserPassword", (txtpw.Text)); // Assuming price is a decimal
                    cmd.Parameters.AddWithValue("@UserId", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfully");
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

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (txtusername.Text.Trim() == "" || txtadd.Text.Trim() == "" || txtpw.Text.Trim() == "" || txtphone.Text.Trim() == "" )
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTbl Values('" + txtusername.Text + "','" + txtphone.Text + "','" + txtadd.Text + "','" + txtpw.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Saved Succesfully");
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

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            populate();
        }


        private void SearchUser()
        {
            try
            {
                Con.Open();
                string query = "select * from UserTbl where UserName LIKE @UserName";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                sda.SelectCommand.Parameters.AddWithValue("@UserName", "%" + txtsearch.Text.Trim() + "%");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvuser.DataSource = dt;

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
            SearchUser();
        }
    }
}