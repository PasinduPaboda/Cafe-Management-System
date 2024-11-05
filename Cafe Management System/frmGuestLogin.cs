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

namespace CafeManagementSystem
{
    public partial class frmGuestLogin : Form
    {
        public frmGuestLogin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == "cashier" && txtPassword.Text == "12345")
            {
                frmDashBoard ds = new frmDashBoard("Guest");
                ds.Show();
                this.Hide();
            }
            String username, user_password;

            username = txtUserName.Text;
            user_password = txtPassword.Text;

            try
            {
                String querry = "SELECT * FROM CashierTbl WHERE UserName = '" + txtUserName.Text + "' AND Password = '" + txtPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, Con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUserName.Text;
                    user_password = txtPassword.Text;

                    frmDashBoard ds = new frmDashBoard("Guest");
                    ds.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid UserName or Password !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();

                    txtUserName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
        }

        private void LlblAdmin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin Fl = new frmLogin();
            Fl.Show();
            this.Hide();
        }
    }
}
