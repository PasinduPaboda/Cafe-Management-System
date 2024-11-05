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
using DGVPrinterHelper;

namespace CafeManagementSystem
{
    public partial class UcPlaceOrder : UserControl
    {
        public UcPlaceOrder()
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

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    String Category = cmbCategory.Text;
        //    query = "Select name from where Category Category = '" + cmbCategory.Text + "'";
        //    var ds = new DataSet(query);

        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i ++)
        //    {
        //        libDisplay.Items.Add(ds.Tables[0].Rows[1][0].ToString());
        //    }
        }

        private void UcPlaceOrder_Load(object sender, EventArgs e)
        {
            DisplayElements("ItemTbl", dgvItemList);
        }

        int PKey = 0;
        int stock = 0;
        private void DgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //PKey = int.Parse(dgvItemList.Rows[e.RowIndex].Cells[0].Value.ToString());
            //String ItemName = dgvItemList.Rows[e.RowIndex].Cells[1].Value.ToString();
            //int Price = int.Parse(dgvItemList.Rows[e.RowIndex].Cells[2].Value.ToString());
            //int Category = int.Parse(dgvItemList.Rows[e.RowIndex].Cells[4].Value.ToString());

            //txtItemName.Text = ItemName;
            //txtPrice.Text = Price.ToString();
            //cmbCategory.Text = Category.ToString();

            txtItemName.Text = dgvItemList.SelectedRows[0].Cells[1].Value.ToString();
            txtPrice.Text = dgvItemList.SelectedRows[0].Cells[2].Value.ToString();
            cmbCategory.Text = dgvItemList.SelectedRows[0].Cells[4].Value.ToString();

            if (txtItemName.Text == "")
            {
                PKey = 0;
                stock = 0;
            }
            else
            {
                PKey = Convert.ToInt32(dgvItemList.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(dgvItemList.SelectedRows[0].Cells[2].Value.ToString());
            }
        }

        int n = 0;
        int BillTotal = 0;
        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if(nudQuontity.Text == "")
            {
                MessageBox.Show("Enter the Quontity !!!");
            }
            else if(Convert.ToInt32(nudQuontity.Text) > stock)
            {
                MessageBox.Show("No Enough Stock !!!");
            }
            else
            {
                int Total = Convert.ToInt32(nudQuontity.Text) * Convert.ToInt32(txtPrice.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvClientBill);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txtItemName.Text;
                newRow.Cells[2].Value = nudQuontity.Text;
                newRow.Cells[3].Value = txtPrice.Text;
                newRow.Cells[4].Value = Total;
                dgvClientBill.Rows.Add(newRow);
                n++;

                BillTotal = BillTotal + Total;
                lblTotal.Text = "Rs : " + BillTotal;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtItemName.Text = "";
            txtPrice.Text = "";
            cmbCategory.Text = "";
            nudQuontity.Text = "";
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "ABC CAFE Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "TOTAL PAYABLE AMOUNT : " + lblTotal.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvClientBill);

            BillTotal = 0;
            dgvClientBill.Rows.Clear();
            lblTotal.Text = "Rs. " + BillTotal;

            //    if (cmbCategory.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("Missing Information!!!");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            Con.Open();
            //            SqlCommand cmd = new SqlCommand("Insert into SalesTbl(Category,SAmount,SDate)Values(@CA,@SA,@SD)", Con);
            //            cmd.Parameters.AddWithValue("@CA", cmbCategory.SelectedValue.ToString());
            //            cmd.Parameters.AddWithValue("@SA", Total);
            //            cmd.Parameters.AddWithValue("@SD", DateTime.Today.Date);
            //            cmd.ExecuteNonQuery();
            //            MessageBox.Show("Sales Added!!!");
            //            Con.Close();
            //            //DisplayElements("SalesTbl", dgvBill);
            //        }
            //        catch (Exception Ex)
            //        {
            //            MessageBox.Show(Ex.Message);
            //        }
            //    }
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        ////int Key = 0;

        private void BtnRemove_Click(object sender, EventArgs e)
        {

            //if (Key == 0)
            //{
            //    MessageBox.Show("Select the Item to be Deleted !!!");
            //}
            //else
            //{
            //    Con.Open();
            //    String query = "delete from ItemTbl where ItemID ='" + Key + "'";
            //    SqlCommand cmd = new SqlCommand(query, Con);
            //    cmd.ExecuteNonQuery();

            //    MessageBox.Show("Item Successfully Deleded !!!");
            //    Con.Close();

            //    DisplayElements("ItemTbl", dgvItem);
            //}
        }

        private void DgvClientBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Con.Open();
            string Query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvClientBill.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
                if (nudQuontity.Text == "")
                {
                    MessageBox.Show("Missing Information !!!");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("Insert Into BillTbl(ItemName, Quontity, Price, Total) values(@IN, @IQ, @IP, @IT)", Con);
                        cmd.Parameters.AddWithValue("@IN", txtItemName.Text);
                        cmd.Parameters.AddWithValue("@IQ", nudQuontity.Text);
                        cmd.Parameters.AddWithValue("@IP", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@IT", BillTotal);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bill Saved !!!");
                        Con.Close();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
        }

        private void DtpGetDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            frmDashBoard ds = new frmDashBoard();
            ds.Show();
            this.Hide();
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
