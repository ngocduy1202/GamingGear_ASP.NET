//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
//using System.Data.SqlClient;

//namespace DoAn
//{
//    public partial class Admin_ThongKe : System.Web.UI.Page
//    {
//        Tool tool = new Tool();
//        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            sync();            
//        }

//        private void sync()
//        {
//            GridView1.DataSource = tool.GetData("select * from DH ");
//            GridView1.DataBind();
//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            Server.Transfer("ADTool.aspx");
//        }

//        protected void Button2_Click(object sender, EventArgs e)
//        {
//            Panel1.Visible = true;
//            string mdh = TextBox1.Text;
//            if(mdh == "")
//            {
//                Label1.Text = "Không có đơn hàng này!";
//            }
//            GridView2.DataSource = tool.GetData("select *, CTDH.DONGIA*CTDH.SOLUONG AS THANHTIEN from DH, CTDH, HANG where CTDH.MAHANG = HANG.MAHANG and DH.MADH = CTDH.MADH and CTDH.MADH ='" + mdh + "'");
//            GridView2.DataBind();
//        }

//        protected void Button3_Click(object sender, EventArgs e)
//        {
//            Panel1.Visible = false;
//        }

//        protected void Button4_Click(object sender, EventArgs e)
//        {
//            Server.Transfer("TK_DTMH.aspx");
//        }

//        protected void Button5_Click(object sender, EventArgs e)
//        {
//            doanhThuThang();
//        }

//        private void doanhThuThang()
//        {
//            SqlConnection connection = new SqlConnection(conn);
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("doanhThuThang", connection);
//            cmd.Parameters.AddWithValue("@thang", DropDownList1.SelectedItem.Text);
//            cmd.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataTable table = new DataTable();
//            adapter.Fill(table);
//            double tong = 0;
//            for (int i = 0; i < table.Rows.Count; i++)
//            {
//                double thanhtien =Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
//                tong = tong + thanhtien;
//            }
//            this.Label2.Text = "Tổng doanh thu tháng "+ DropDownList1.SelectedItem.Text + " : " + String.Format("{0:0,0}", tong) + " vnđ";
            
//            connection.Close();
//        }

//        protected void Button6_Click(object sender, EventArgs e)
//        {
//            tongDoanhThu();
//        }

//        private void tongDoanhThu()
//        {
//            SqlConnection connection = new SqlConnection(conn);
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("tongDoanhThu", connection);            
//            cmd.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataTable table = new DataTable();
//            adapter.Fill(table);
//            double tong = 0;
//            for (int i = 0; i < table.Rows.Count; i++)
//            {
//                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
//                tong = tong + thanhtien;
//            }            
//            this.Label3.Text = "Tổng doanh  thu: " + String.Format("{0:0,0}", tong) + " vnđ";

//            connection.Close();
//        }

//        protected void Button7_Click(object sender, EventArgs e)
//        {
//            doanhThuNgay();
//        }

//        private void doanhThuNgay()
//        {
//            string date = TextBox2.Text;            
//            SqlConnection connection = new SqlConnection(conn);
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("doanhThuNgay", connection);
//            cmd.Parameters.AddWithValue("@ngay", date);
//            cmd.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataTable table = new DataTable();
//            adapter.Fill(table);
//            double tong = 0;
//            for (int i = 0; i < table.Rows.Count; i++)
//            {
//                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
//                tong = tong + thanhtien;
//            }
//            this.Label4.Text = "Doanh thu ngày " + String.Format("{0:MM/dd/yyyy}", date) + " : " + String.Format("{0:0,0}", tong) + " vnđ";

//            connection.Close();
//        }

//        protected void Button8_Click(object sender, EventArgs e)
//        {
//            doanhthudh();
//        }

//        private void doanhthudh()
//        {
//            SqlConnection connection = new SqlConnection(conn);
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("doanhThuDH", connection);
//            cmd.Parameters.AddWithValue("@madh", DropDownList2.SelectedItem.Text);
//            cmd.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataTable table = new DataTable();
//            adapter.Fill(table);
//            double tong = 0;
//            for (int i = 0; i < table.Rows.Count; i++)
//            {
//                double thanhtien = Convert.ToDouble(table.Rows[i]["TONGTIEN"]);
//                tong = tong + thanhtien;
//            }
//            this.Label5.Text = "Tổng thành tiền: " + String.Format("{0:0,0}",tong) + " vnđ";

//            connection.Close();
//        }
//    }
//}