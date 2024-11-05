using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeManagementSystem
{
    public partial class UcCaregory : UserControl
    {
        public UcCaregory()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");


        private void DisplayElements(String TName, Guna.UI2.WinForms.Guna2DataGridView dgvItem)
        {
            Con.Open();
            string Query = "select * from CategoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvItem.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtENCategory.Text == "")
            {
                MessageBox.Show("Missing Information !!!");
            }
            else
            {
                try
                { 
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into CategoryTbl(CategoryName) values(@CN)", Con);
                    cmd.Parameters.AddWithValue("@CN", txtENCategory.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Category Successfully Added !!!");
                    Con.Close();

                    DisplayElements("CategoryTbl", dgvCategory);

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UcCaregory_Load(object sender, EventArgs e)
        {
            DisplayElements("CategoryTbl", dgvCategory);
        }

        int CKey = 0;
        private void DgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CKey = int.Parse(dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
            String CategoryName = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();

            txtENCategory.Text = CategoryName;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (txtENCategory.Text == "")
            {
                MessageBox.Show("Missing Information !!!");
            }
            else
            {
                Con.Open();
                String query = "Update CategoryTbl set CategoryName='" + txtENCategory.Text + "' where CategoryID =" + CKey + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Category Successfully Updated !!!");
                Con.Close();

                DisplayElements("CategoryTbl", dgvCategory);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (CKey == 0)
            {
                MessageBox.Show("Select the Item to be Deleted !!!");
            }
            else
            {
                Con.Open();
                String query = "delete from CategoryTbl where CategoryID ='" + CKey + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item Successfully Deleded !!!");
                Con.Close();

                DisplayElements("CategoryTbl", dgvCategory);
            }
        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            frmDashBoard ds = new frmDashBoard();
            ds.Show();
            this.Hide();
        }
    }
}
