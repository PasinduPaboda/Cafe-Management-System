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
    public partial class UcReport : UserControl
    {
        //internal static bool visible;

        public UcReport()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-QP4JRJ6;Initial Catalog=CafeManagementSystem;Integrated Security=True");

        private void Guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        internal static void StringToFront()
        {
            throw new NotImplementedException();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ItemTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblItem.Text = dt.Rows[0][0].ToString() + " Items";
            Con.Close();
        }

        private void Guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CategoryTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblCategory.Text = dt.Rows[0][0].ToString() + " Category";
            Con.Close();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {
            //Con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("Select Sum(SAmount) from ItemTbl", Con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //itemLbl.Text = dt.Rows[0][0].ToString() + " Items";
            //Con.Close();
        }

        private void Guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(Total) from BillTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblSales.Text = "Rs : "+ dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand queryReport = new SqlCommand("Select ItemName, SUM (Quontity) From ItemTbl GROUP BY ItemName ORDER BY SUM (Quontity) desc", Con);
            SqlDataAdapter dtAd = new SqlDataAdapter();
            DataTable dtble = new DataTable();
            dtAd.SelectCommand = queryReport;
            dtble.Clear();
            dtAd.Fill(dtble);

            for (int y = 0; y < dtble.Rows.Count; y++)
            {
                rptDemanding.Series["Items"].Points.AddXY(dtble.Rows[y][0].ToString(), dtble.Rows[y][1].ToString());
            }

            rptDemanding.Titles.Add("Demand");
            Con.Close();
        }

        private void BtnCategoryR_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand queryReport = new SqlCommand("Select CategoryName, SUM (CategoryID) From CategoryTbl GROUP BY CategoryName ORDER BY SUM (CategoryID) desc", Con);
            SqlDataAdapter dtAd = new SqlDataAdapter();
            DataTable dtble = new DataTable();
            dtAd.SelectCommand = queryReport;
            dtble.Clear();
            dtAd.Fill(dtble);

            for (int y = 0; y < dtble.Rows.Count; y++)
            {
                rptDemanding.Series["Items"].Points.AddXY(dtble.Rows[y][0].ToString(), dtble.Rows[y][1].ToString());
            }

            rptDemanding.Titles.Add("Demand");
            Con.Close();
        }

        private void Guna2Button1_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand queryReport = new SqlCommand("Select ItemName, SUM (Total) From BillTbl GROUP BY ItemName ORDER BY SUM (Total) desc", Con);
            SqlDataAdapter dtAd = new SqlDataAdapter();
            DataTable dtble = new DataTable();
            dtAd.SelectCommand = queryReport;
            dtble.Clear();
            dtAd.Fill(dtble);

            for (int y = 0; y < dtble.Rows.Count; y++)
            {
                rptDemanding.Series["Items"].Points.AddXY(dtble.Rows[y][0].ToString(), dtble.Rows[y][1].ToString());
            }

            rptDemanding.Titles.Add("Demand");
            Con.Close();
        }

        private void Guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            frmDashBoard ds = new frmDashBoard();
            ds.Show();
            this.Hide();
        }
    }
}
