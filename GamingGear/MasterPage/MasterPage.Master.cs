using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamingGear
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            
            if (Page.IsPostBack) return;
            bindData();
            visible_btn_login(); // check cookie == null ? visible : not visible
            visible_Controls(PanelLogin, "an");
            visible_Controls(PanelRegister, "an");
            Check_Cookies_ID();


        }

        protected void btnAccount_Click(object sender, EventArgs e) // nút chứa tên tài khoản
        {
            Response.Redirect("Info.aspx");
        }

        protected void btnAllProduct_Click(object sender, EventArgs e) // nút tất cả sp
        {
            Response.Redirect("Products.aspx");
        }

        protected void btnAccountInfo_Click(object sender, EventArgs e) // nút thông tin account
        {
            Response.Redirect("Info.aspx");
        }

        protected void btnHistory_Click(object sender, EventArgs e) //nút lịch sử đơn hàng
        {
            Response.Redirect("Info.aspx");
        }

        protected void btnLoginMaster_Click(object sender, EventArgs e) // nút đăng nhập ngoài giao diện home
        {

            visible_Controls(PanelLogin, "hien");
            
        }

        protected void btnLogin_Click(object sender, EventArgs e) // nút submit trong form đăng nhập
        {
            string tttk = "enable";
            string userName = tbUserName.Text;
            string passLogin = tbPassword.Text;
            string query = "select * from TAIKHOAN where TENDN='{0}' and MATKHAU= '{1}' and TTTK ='" + tttk + "'";
            query = String.Format(query, userName, passLogin);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                lbl.Text = "Sai tên đăng nhập hoặc mật khẩu hoặc tài khoản bị khoá !";
                return;
            }
            else
            {
                query = "select LOAITK from TAIKHOAN where TENDN = '" + userName + "'";
                SqlConnection sql = new SqlConnection(connectionString);
                SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                sqlDataAdapter.Fill(data);           //Lấy loại tài khoản fill vô data table
                foreach (DataRow dataRow in dataTable.Rows)
                {                                    //Lấy row loại tk trong data table
                    if (dataRow["LOAITK"].Equals(0)) //So sánh với loại tài khoản = 0 (admin)
                    {
                        Response.Cookies["TENDN"].Value = userName;
                        Response.Redirect("~/WebForm/AdminPages/AdminHome.aspx");//Vào trang quản lý của admin
                        visible_Controls(PanelLogin, "an");
                    }                                                  
                }
                Response.Cookies["TENDN"].Value = userName;
                visible_Controls(PanelLogin, "an");       
                Response.Redirect(HttpContext.Current.Request.Url.ToString());
            }
        }

        protected void Check_Cookies_ID() //Ẩn nút vào trang admin nếu đăng nhập tài khoản của khách
        {
            string query = "select LOAITK from TAIKHOAN where TENDN = '" + cookies + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            sqlData.Fill(data);           //Lấy loại tài khoản fill vô data table
            foreach (DataRow dataRow in data.Rows)
            {                                    //Lấy row loại tk trong data table
                if (dataRow["LOAITK"].Equals(1)) //So sánh với loại tài khoản = 0 (admin)
                {
                    visble_span_Go_To_Admin();
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e) // nút đăng kí trong form đăng nhập
        {
            visible_Controls(PanelLogin, "an");
            visible_Controls(PanelRegister, "hien");
        }

        protected void btnExitLogin_Click(object sender, EventArgs e) // nút exit trong form đăng nhập
        {
            visible_Controls(PanelLogin, "an");
        }

        protected void btnRegis_Click(object sender, EventArgs e) // nút submit trong form đăng kí
        {
            
            string tenDN = tbUserNameRegis.Text;
            string matKhau = tbPasswordRegis.Text;
            string tenKH = tbNameRegis.Text;
            string sdt = tbSDTRegis.Text;
            string query = "select * from TAIKHOAN where TENDN = '" + tenDN + "'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                DangKy(tenDN, matKhau, tenKH, sdt);
                Response.Cookies["TENDN"].Value = tenDN;
                visible_Controls(PanelRegister, "an");
            }
            else
            {
                lblMessageRegis.Text = "Tên đăng nhập đã trùng, vui lòng chọn tên khác";
            }
        }

        protected void DangKy(string tenDN, string matKhau, string tenKH, string sdt) // function thêm tài khoản
        {
            string tt = "enable";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "insert into TAIKHOAN (TENDN, MATKHAU, TENKH, SDT, LOAITK, TTTK) values ('{0}','{1}','{2}','{3}',1, '" + tt + "')";
            query = String.Format(query, tenDN, matKhau, tenKH, sdt);
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        protected void btnExitRegis_Click(object sender, EventArgs e) // nút exit trong form đăng kí
        {
            visible_Controls(PanelRegister, "an");
        }

        protected void btnLogout_Click(object sender, EventArgs e) // logout tất cả, nhưng chưa xóa được s
        {
            Response.Cookies["TENDN"].Value = null;
            Server.Transfer("Home.aspx");

            DataTable gioHang = (DataTable)Session["GioHangDB"];
            DataTable thongTinDatHang = (DataTable)Session["TTDH"];

            if (gioHang == null) return;
            else { Session.Clear(); Session.Abandon(); }

            if (thongTinDatHang == null) return;
            else { Session.Clear(); Session.Abandon(); }
        }

        protected void bindData() // đổ tên tài khoản vô nút tài khoản
        {
            string query = "Select * from TAIKHOAN where TENDN = '"+cookies+"'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.DataList1.DataSource = dataTable;
            this.DataList1.DataBind();
        }

        

        protected void visible_btn_login() // kiểm tra cookies và visible nút đăng nhập
        {
            if(cookies !="")
            {
                visible_Controls(buttonLoginMaster, "an");
            }
            else if (cookies == "")
            {
                visible_Controls(buttonLoginMaster, "hien");
            }
        }

        protected void visible_Controls(Control control, string action) { // thay thế .visible = true
            if (action.Equals("an"))
            {
                control.Visible = false;
                
            }
            else if (action.Equals("hien"))
            {
                control.Visible = true;
            }
        }

        protected void visible_menuAccount(int value) // đang k dùng nhưng để làm mẫu lỡ cần
        {
            foreach (DataListItem item in DataList1.Items)
            {
                Control infoAccount = item.FindControl("accountInfo");
                Control history = item.FindControl("history");
                if (infoAccount != null && history != null && value == 0)
                {
                    infoAccount.Visible = false;
                    history.Visible = false;
                }
                else if (infoAccount != null && history != null && value == 1)
                {
                    infoAccount.Visible = true;
                    history.Visible = true;
                }
            }
        }

        protected void visble_span_Go_To_Admin()
        {
            foreach (DataListItem item in DataList1.Items)
            {
                Control spanBtnAccount = item.FindControl("AdminPage") as Control;
                spanBtnAccount.Visible = false;
            }
        }

        protected void find_btnAccount() // đang k dùng nhưng để làm mẫu lỡ cần
        {
            foreach (DataListItem item in DataList1.Items)
            {
                Button btnAccount = (Button)item.FindControl("AdminPage");
            }
        }

        protected void lbCardView_Click(object sender, EventArgs e)
        {
            Server.Transfer("PayForm.aspx");
        }

        protected void btnGoToAdminPage_Click(object sender, EventArgs e)
        {
            Response.Cookies["TENDN"].Value = cookies;
            Response.Redirect("~/WebForm/AdminPages/AdminHome.aspx");
        }
    }
}