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
    public partial class UcStaffReg : UserControl
    {
        public UcStaffReg()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");


        internal static void StringToFront()
        {
            throw new NotImplementedException();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {
            UcStaffAdminAndGuest Sr = new UcStaffAdminAndGuest();
            MainControlClass.showControl(Sr, Content);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtAge.Text == "" || txtContactNo.Text == "" || txtAddress.Text == "" || txtUName.Text == "" || txtPassword.Text == "" || txtCPassword.Text == "")
            {
                MessageBox.Show("Missing Information !!!");
            }
            else if(txtPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show("Password Do Not Match !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into AdminTbl(FirstName, LastName, Age, ContactNO, Address, UserName, Password, ConfirmPassword) values(@FN, @LN, @AG, @CN, @AD, @UN, @PA, @CP)", Con);
                    cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                    cmd.Parameters.AddWithValue("@AG", txtAge.Text);
                    cmd.Parameters.AddWithValue("@CN", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@AD", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@UN", txtUName.Text);
                    cmd.Parameters.AddWithValue("@PA", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@CP", txtCPassword.Text);
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
