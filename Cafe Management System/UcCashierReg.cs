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
    public partial class UcCashierReg : UserControl
    {
        public UcCashierReg()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");

        private void Guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {
            UcStaffAdminAndGuest Sr = new UcStaffAdminAndGuest();
            MainControlClass.showControl(Sr, Content);
        }

        private void BtnCashReg_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtAge.Text == "" || txtContactNo.Text == "" || txtAddress.Text == "" || txtUName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information !!!");
            }
            else if (txtPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show("Password Do Not Match !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into CashierTbl(FirstName, LastName, Age, ContactNO, Address, UserName, Password) values(@FN, @LN, @AG, @CN, @AD, @UN, @PA)", Con);
                    cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                    cmd.Parameters.AddWithValue("@AG", txtAge.Text);
                    cmd.Parameters.AddWithValue("@CN", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@AD", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@UN", txtUName.Text);
                    cmd.Parameters.AddWithValue("@PA", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is Successfull !!!");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
