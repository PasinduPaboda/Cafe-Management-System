using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    class MainControlClass
    {
        public static void showControl(System.Windows.Forms.Control Control , System.Windows.Forms.Control Content)
        {
            Content.Controls.Clear();

            Control.Dock = DockStyle.Fill;
            Control.BringToFront();
            Control.Focus();

            Content.Controls.Add(Control);
        }
    }
}
