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
    public partial class UcManageItem : UserControl
    {

        public UcManageItem()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");

        internal static void StringToFront()
        {
            throw new NotImplementedException();
        }

        private void DisplayElements(String TName, Guna.UI2.WinForms.Guna2DataGridView dgvItem)
        {
            Con.Open();
            string Query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvItem.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if(txtItemName.Text == "" || txtPrice.Text == "" || nudQuontity.Text == "" || cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into ItemTbl(ItemName, Price_RS, Quontity, Category) values(@IN, @IP, @IQ, @IC)", Con);
                    cmd.Parameters.AddWithValue("@IN", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@IP", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@IQ", nudQuontity.Text);
                    cmd.Parameters.AddWithValue("@IC", cmbCategory.SelectedIndex.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Added !!!");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                //Con.Open();
                //String query = "insert into ItemTbl values(" + txtItemName.Text + ",'" + txtPrice.Text + "','" + nudQuontity.Text + "','" + cmbCategory.SelectedIndex.ToString() + ")";
                //SqlCommand cmd = new SqlCommand(query, Con);
                //cmd.ExecuteNonQuery();

                //MessageBox.Show("Item Successfully Added !!!");
                //Con.Close();

            }
            DisplayElements("ItemTbl" , dgvItem);
        }
       

        private void UcManageItem_Load(object sender, EventArgs e)
        {
            DisplayElements("ItemTbl" , dgvItem);
        }

        int Key = 0;
        private void DgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Key = int.Parse(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString());
            String ItemName = dgvItem.Rows[e.RowIndex].Cells[1].Value.ToString();
            int Price = int.Parse(dgvItem.Rows[e.RowIndex].Cells[2].Value.ToString());
            int Quontity = int.Parse(dgvItem.Rows[e.RowIndex].Cells[3].Value.ToString());
            int Category = int.Parse(dgvItem.Rows[e.RowIndex].Cells[4].Value.ToString());

            txtItemName.Text = ItemName;
            txtPrice.Text = Price.ToString();
            nudQuontity.Text = Quontity.ToString();
            cmbCategory.Text = Category.ToString();

        }

        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || txtPrice.Text == "" || nudQuontity.Text == "" || cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information !!!");
            }
            else
            {
                Con.Open();
                String query = "Update ItemTbl set ItemName='" + txtItemName.Text + "',Price_RS='" + txtPrice.Text + "',Quontity='" + nudQuontity.Text + "', Category='" + cmbCategory.SelectedIndex.ToString() + "'  where ItemID =" + Key + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item Successfully Updated !!!");
                Con.Close();

                DisplayElements("ItemTbl", dgvItem);
            }
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Select the Item to be Deleted !!!");
            }
            else
            {
                Con.Open();
                String query = "delete from ItemTbl where ItemID ='" + Key + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item Successfully Deleded !!!");
                Con.Close();

                DisplayElements("ItemTbl", dgvItem);
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
