using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamingGear.WebForm
{
    public partial class ConfirmOrder : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        string query = "";
        string sdt, ghichu, diachi;
        DataTable dataTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            Bind_Data_Page();
        }

        protected void Bind_Data_Page()
        {
            try // đổ data vào giỏ hàng
            {
                dataTable = (DataTable)Session["GioHangDB"];
                GridView.DataSource = dataTable;
                GridView.DataBind();
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }
            try
            {
                dataTable = (DataTable)Session["TTDH"];
                DataList1.DataSource = dataTable;
                DataList1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("PayForm.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string TENDN = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            if (TENDN == "")
            {
                Response.Write("<script>alert('Đăng nhập để mua hàng');</script>");
                return;
            }
            checkKho();
        }
                
        private void checkKho()
        {
            string mk = "1";
            DataTable dt = (DataTable)Session["GioHangDB"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            foreach (DataRow dataRow in dt.Rows)
            {
                SqlCommand cmd = new SqlCommand("xuatKho", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makho", mk);
                cmd.Parameters.AddWithValue("@mahang", dataRow["MAHANG"]);
                cmd.Parameters.AddWithValue("@soluong", dataRow["SOLUONG"]);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    taoPhieuXuat();
                    Server.Transfer("Info.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Số lượng trong kho không đủ :<');</script>");
                }
            }
            connection.Close();
        }

        private void taoPhieuXuat()
        {
            string lp = "Xuất";
            DataTable dt = (DataTable)Session["GioHangDB"];
            string date = getdate();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd;
            foreach (DataRow dataRow in dt.Rows)
            {
                cmd = new SqlCommand("taoPhieuXuat", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mahang", dataRow["MAHANG"]);
                cmd.Parameters.AddWithValue("@soluong", dataRow["SOLUONG"]);
                cmd.Parameters.AddWithValue("@loaiphieu", lp);
                cmd.Parameters.AddWithValue("@ngay", date);
                int rowaf = cmd.ExecuteNonQuery();
            }
            connection.Close();
            taoDH();
        }

        private void taoCTDH()
        {
            string TENDN = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";

            if (TENDN == "")
            {
                Response.Write("<script>alert('Đăng nhập để mua hàng');</script>");
                return;
            }            
            DataTable ttdh = (DataTable)Session["TTDH"];
            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();            
            foreach (DataRow dataRow in ttdh.Rows) {
                sdt = dataRow["SDT"].ToString();
                ghichu = dataRow["GHICHU"].ToString();
                diachi = dataRow["DIACHI"].ToString();
            }
            connection1.Close();
            //

            DataTable dt = (DataTable)Session["GioHangDB"];            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            foreach (DataRow dataRow in dt.Rows)
            {
                SqlCommand cmd = new SqlCommand("taoCTDH", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mahang", dataRow["MAHANG"]);                
                cmd.Parameters.AddWithValue("@tenhang", dataRow["TENHANG"]);
                cmd.Parameters.AddWithValue("@dongia", dataRow["DONGIA"]);
                cmd.Parameters.AddWithValue("@soluong", dataRow["SOLUONG"]);
                cmd.Parameters.AddWithValue("@sdt", sdt);                
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@ghichu", ghichu);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        private void taoDH()
        {
            string TENDN = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            
            if (TENDN == "")
            {
                Response.Write("<script>alert('Đăng nhập để mua hàng');</script>");
                return;
            }            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("taoDH", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tendn", TENDN);
            cmd.Parameters.AddWithValue("@ttdh", "dxl");
            cmd.Parameters.AddWithValue("@ngay", getdate());
            cmd.ExecuteNonQuery();
            connection.Close();
            taoCTDH();
        }

        private string getdate()
        {
            DateTime today = DateTime.Now;
            return today.ToString("MM/dd/yyyy");
        }
    }
}