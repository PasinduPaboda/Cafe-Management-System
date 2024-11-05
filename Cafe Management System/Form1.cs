using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            String username, user_password;

            username = txtUserName.Text;
            user_password = txtPassword.Text;

            try
            {
                String querry = "SELECT * FROM AdminTbl WHERE UserName = '" + txtUserName.Text + "' AND Password = '"+txtPassword.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, Con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = txtUserName.Text;
                    user_password = txtPassword.Text;

                    frmDashBoard ds = new frmDashBoard("admin");
                    ds.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid UserName or Password !!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void LlblGuest_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmGuestLogin Fl = new frmGuestLogin();
            Fl.Show();
            this.Hide();

        }
    }
}
