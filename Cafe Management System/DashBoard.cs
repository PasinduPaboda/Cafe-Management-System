using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }
        public frmDashBoard(String user)
        {
            InitializeComponent();

            if (user == "Guest")
            {
                btnItem.Hide();
                btnCategory.Hide();
                btnStaffReg.Hide();   
            }
        }

        private void BtnPlaceOrd_Click_1(object sender, EventArgs e)
        {
            UcPlaceOrder Po = new UcPlaceOrder();
            MainControlClass.showControl(Po, Content);
        }

        private void BtnStaffReg_Click_1(object sender, EventArgs e)
        {
            UcStaffAdminAndGuest Sr = new UcStaffAdminAndGuest();
            MainControlClass.showControl(Sr, Content);
        }

        private void BtnCategory_Click_1(object sender, EventArgs e)
        {
            UcCaregory Cm = new UcCaregory();
            MainControlClass.showControl(Cm, Content);
        }

        private void BtnItem_Click_1(object sender, EventArgs e)
        {
            UcManageItem Mi = new UcManageItem();
            MainControlClass.showControl(Mi, Content);

        }

        private void BtnReport_Click_1(object sender, EventArgs e)
        {
            UcReport Rg = new UcReport();
            MainControlClass.showControl(Rg, Content);
        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin fm = new frmLogin();
            this.Hide();
            fm.Show();
        }

        private void Guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
