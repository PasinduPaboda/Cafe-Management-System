using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class UcStaffAdminAndGuest : UserControl
    {
        public UcStaffAdminAndGuest()
        {
            InitializeComponent();
        }

        private void BtnAdmin_Click_1(object sender, EventArgs e)
        {
            UcStaffReg Ad = new UcStaffReg();
            MainControlClass.showControl(Ad, Content1);
        }

        private void BtnCashier_Click_1(object sender, EventArgs e)
        {
            UcCashierReg Ca = new UcCashierReg();
            MainControlClass.showControl(Ca, Content1);
        }
    }
}
