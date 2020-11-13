using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class PayForm : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        //Tool tool = new Tool();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Page.IsPostBack) return;
            try
            {
                DataTable dataTable = (DataTable)Session["GioHangDB"];
                GridView.DataSource = dataTable;
                GridView.DataBind();

                double tong = 0;
                for (int i = 0; i < dataTable.Rows.Count; i++)                {
                    
                    double thanhtien = Convert.ToDouble(dataTable.Rows[i]["SOLUONG"]) * Convert.ToDouble(dataTable.Rows[i]["DONGIA"]);
                    tong = tong + thanhtien;
                }
                
                this.lbl.Text = "Tổng cộng: " + String.Format("{0:0,0}", tong);                
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }

            try
            {
                string TENDN = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
                string query = "Select SDT from TAIKHOAN where TENDN = '"+TENDN+"' ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connectionString);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                this.DataList1.DataSource = dataTable;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
        

        protected void btnBuyNow_Click(object sender, EventArgs e)
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
                if(result > 0)
                {
                    taoPhieuXuat();
                    //taoDonHang();
                    taoDH();
                    //Response.Write("<script>alert('Mua hàng thành công, mua tiếp đi bạn êi :>');</script>");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('Số lượng trong kho không đủ, gọi thằng admin nhập thêm hàng đi ạ :<');</script>");
                }
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
            DataTable dt = (DataTable)Session["GioHangDB"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();            
            SqlCommand cmd = new SqlCommand("taoDH", connection);
            cmd.CommandType = CommandType.StoredProcedure;                
            cmd.Parameters.AddWithValue("@tendn", TENDN);                
            cmd.ExecuteNonQuery();            
            connection.Close();
            taoCTDH();
        }

        private void taoCTDH()
        {
            string TENDN = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";

            if (TENDN == "")
            {
                Response.Write("<script>alert('Đăng nhập để mua hàng');</script>");
                return;
            }
            DataTable dt = (DataTable)Session["GioHangDB"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            
            foreach (DataRow dataRow in dt.Rows)
            {
                SqlCommand cmd = new SqlCommand("taoCTDH", connection);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@mahang", dataRow["MAHANG"]);
                cmd.Parameters.AddWithValue("@tendn", TENDN);
                cmd.Parameters.AddWithValue("@tenhang", dataRow["TENHANG"]);
                cmd.Parameters.AddWithValue("@dongia", dataRow["DONGIA"]);
                cmd.Parameters.AddWithValue("@soluong", dataRow["SOLUONG"]);
                cmd.Parameters.AddWithValue("@ngay", getdate());
                cmd.Parameters.AddWithValue("@diachi", tbAddress.Text);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        private void taoDonHang()
        {
            string TENDN = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";

            if (TENDN == "")
            {
                Response.Write("<script>alert('Đăng nhập để mua hàng');</script>");
                return;
            }
            DataTable dt = (DataTable)Session["GioHangDB"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            foreach (DataRow dataRow in dt.Rows)
            {
                SqlCommand cmd = new SqlCommand("taoDonHang", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mahang", dataRow["MAHANG"]);
                cmd.Parameters.AddWithValue("@tendn", TENDN);
                cmd.Parameters.AddWithValue("@tenhang", dataRow["TENHANG"]);
                cmd.Parameters.AddWithValue("@dongia", dataRow["DONGIA"]);
                cmd.Parameters.AddWithValue("@soluong", dataRow["SOLUONG"]);
                cmd.Parameters.AddWithValue("@ngay", getdate());
                cmd.Parameters.AddWithValue("@diachi", tbAddress.Text);
                cmd.ExecuteNonQuery();
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
        }

        
        private string getdate()
        {
            DateTime today = DateTime.Now;
            return today.ToString("MM/dd/yyyy");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)Session["GioHangDB"];
            this.GridView.DataSource = dataTable;
            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    for (int i = GridView.Rows.Count - 1; i >= 0; i--)
                    {
                        GridViewRow row = GridView.Rows[i];

                        bool isChecked = ((CheckBox)row.FindControl("CheckBox")).Checked;
                        if (((CheckBox)row.FindControl("CheckBox")).Checked)
                        {
                            dataTable.Rows[i].Delete();
                        }
                    }
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void lblMaHang_Click1(object sender, EventArgs e)
        {
            string maHang = ((LinkButton)sender).CommandArgument.ToString();
            Context.Items["MAHANG"] = maHang;
            Server.Transfer("ProductInfo.aspx");
        }                

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = (DataTable)Session["GioHangDB"];
            if(e.CommandName == "edit")
            {
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).Parent.Parent;
                string sl = ((TextBox)row.FindControl("TextBox3")).Text;
                dt.Rows[row.DataItemIndex]["SOLUONG"] = sl;
                string dg = ((Label)row.FindControl("Label1")).Text;
                dt.Rows[row.DataItemIndex]["THANHTIEN"] = Convert.ToDouble(sl) * Convert.ToDouble(dg);
                Session["GioHangDB"] = dt;
            }
            this.docData();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void docData()
        {
            if (Page.IsPostBack) return;
            try
            {
                DataTable dataTable = (DataTable)Session["GioHangDB"];
                this.GridView.DataSource = dataTable;
                this.GridView.DataBind();
                double tong = 0;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    double thanhtien = Convert.ToDouble(dataTable.Rows[i]["SOLUONG"]) 
                        * Convert.ToDouble(dataTable.Rows[i]["DONGIA"]);
                    tong = tong + thanhtien;
                }
                this.lbl.Text = "Tổng cộng: " + tong;
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {            
            DataTable dataTable = (DataTable)Session["GioHangDB"];
            //GridView.EditIndex = e.NewEditIndex;
            GridView.EditIndex = -1;
            GridView.DataSource = dataTable;            
            GridView.DataBind();
            
        }
    }
}