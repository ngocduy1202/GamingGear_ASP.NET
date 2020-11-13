using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamingGear.AdminMasterPage
{
    public partial class TK : System.Web.UI.Page
    {
        Tool tool = new Tool();
        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            sync();            
        }      
      

        private void sync()
        {
            GridView1.DataSource = tool.GetData("select * from DH");
            GridView1.DataBind();
        }
        
        private void doanhThuThang()
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand cmd = new SqlCommand("doanhThuThang", connection);
            cmd.Parameters.AddWithValue("@thang", DropDownList1.SelectedItem.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            double tong = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
                tong = tong + thanhtien;
            }
            this.Label2.Text = "Tổng doanh thu tháng " + DropDownList1.SelectedItem.Text + " : " + String.Format("{0:0,0}", tong) + " vnđ";

            connection.Close();
        }


        private void tongDoanhThu()
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand cmd = new SqlCommand("tongDoanhThu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            double tong = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
                tong = tong + thanhtien;
            }
            this.Label3.Text = "Tổng doanh  thu: " + String.Format("{0:0,0}", tong) + " vnđ";

            connection.Close();
        }
                

        private void doanhThuNgay()
        {
            string date = TextBox2.Text;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand cmd = new SqlCommand("doanhThuNgay", connection);
            cmd.Parameters.AddWithValue("@ngay", date);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            double tong = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
                tong = tong + thanhtien;
            }
            this.Label4.Text = "Doanh thu ngày " + String.Format("{0:MM/dd/yyyy}", date) + " : " + String.Format("{0:0,0}", tong) + " vnđ";

            connection.Close();
        }

        

        private void doanhthudh()
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            SqlCommand cmd = new SqlCommand("doanhThuDH", connection);
            cmd.Parameters.AddWithValue("@madh", DropDownList2.SelectedItem.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            double tong = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
                tong = tong + thanhtien;
            }
            this.Label5.Text = "Tổng thành tiền: " + String.Format("{0:0,0}", tong) + " vnđ";

            connection.Close();
        }

        protected void btnDTDH_Click(object sender, EventArgs e)
        {
            doanhthudh();
        }

        protected void btnDTN_Click(object sender, EventArgs e)
        {
            doanhThuNgay();
        }

        protected void btnDTT_Click(object sender, EventArgs e)
        {
            doanhThuThang();
        }

        protected void btnTDT_Click(object sender, EventArgs e)
        {
            tongDoanhThu();
        }

        protected void btnXCT_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            string mdh = tbmdh.Text;
            if (mdh == "")
            {
                Label1.Text = "Không có đơn hàng này!";
            }
            GridView2.DataSource = tool.GetData("select *, CTDH.DONGIA*CTDH.SOLUONG AS THANHTIEN " +
                "from DH, CTDH, HANG where CTDH.MAHANG = HANG.MAHANG and DH.MADH = CTDH.MADH and DH.MADH ='" + mdh + "' and CTDH.MADH ='" + mdh + "'");
            GridView2.DataBind();
        }

        protected void btnDongCT_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
    }
}