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
    public partial class Info : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        string query = "";
        DataTable dataTable;
        Tool tool = new Tool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            visible_Controls(orderDetail, "an");
            Bind_ThongTinTaiKhoan();//bind data form thông tin tài khoản
            Bind_DH(); //bind data form show đơn hàng   
            bindDrop();
        }

        private void bindDrop()
        {
            query = "select MADH from DH where TENDN = '"+ cookies+"' and TTDH = 'dxl' ";
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.DropDownList1.DataSource = dataTable;
            this.DropDownList1.DataBind();
            this.DropDownList1.DataTextField = "MADH";
            this.DropDownList1.DataBind();
        }

        protected void lbMaDH_Click(object sender, EventArgs e)// click linkbutton more detail
        {
            visible_Controls(orderDetail, "hien");
            visible_Controls(GridView2, "hien");
            string maHang = ((LinkButton)sender).CommandArgument.ToString();
            Bind_CTDH(maHang);
        }

        protected void btnUpdate_Click(object sender, EventArgs e) //nút update thông tin khách
        {
            string password = "";
            string address = "";
            string newPassword = "";
            string phoneNumber = "";
            foreach (DataListItem dataListItem in DataList2.Items)
            {
                TextBox tbPassword = (TextBox)dataListItem.FindControl("tbPasswordUpdate");
                TextBox tbAddress = (TextBox)dataListItem.FindControl("tbAddress");
                TextBox tbRePassword = (TextBox)dataListItem.FindControl("tbRePasswordUpdate");
                TextBox tbPhoneNumber = (TextBox)dataListItem.FindControl("tbPhoneNumber");
                Label lblMessage = (Label)dataListItem.FindControl("lblMessage");
                password = tbPassword.Text;
                address = tbAddress.Text;
                newPassword = tbRePassword.Text;
                phoneNumber = tbPhoneNumber.Text;
                lblMessage.Text = tbAddress.Text;
                string userName = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
                if (Check_Password(userName, password, lblMessage))
                {
                    Chose_Query(userName, newPassword, address, phoneNumber);
                    SqlConnection sqlConnection = new SqlConnection(conn);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        protected void Bind_ThongTinTaiKhoan() //bind data form thông tin tài khoản
        {
            query = "select * from TAIKHOAN where TENDN = '" + cookies + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.DataList2.DataSource = dataTable;
            this.DataList2.DataBind();
        }


        protected void Bind_DH() //bind data form show đơn hàng
        {
            query = "select * from DH where TENDN = '" + cookies + "'";            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.GridView1.DataSource = dataTable;
            this.GridView1.DataBind();
        }

        protected void Bind_CTDH(string maHang)//show CTDH khi click linkbutton more detail
        {
            query = "select *, DONGIA*SOLUONG as THANHTIEN from CTDH where MADH = '" + maHang + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.GridView2.DataSource = dataTable;
            this.GridView2.DataBind();

        }

        protected Boolean Check_Password(string tenDN, string password, Label lblMessage)// kiểm tra nhập mật khẩu 
        {
            string query = "select * from TAIKHOAN where TENDN='" + tenDN + "' and MATKHAU= '" + password + "'";
            query = String.Format(query, tenDN, password);
            SqlConnection SQLconnection = new SqlConnection(conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                lblMessage.Text = "Sai mật khẩu";
                return false;
            }
            return true;
        }

        protected String Chose_Query(string userName, string newPassword, string address, string phoneNumber) //chọn query để excute
        {
            if (address == "" || address == null)
            {
                query = "Update TAIKHOAN set MATKHAU = '" + newPassword + "', SDT = '" + phoneNumber + "' where TENDN = '" + userName + "'";
            }
            else if (phoneNumber == "" || phoneNumber == null)
            {
                query = "Update TAIKHOAN set MATKHAU = '" + newPassword + "', DIACHI = '" + address + "' where TENDN = '" + userName + "'";
            }
            else if (newPassword == null || newPassword == "")
            {
                query = "Update TAIKHOAN set DIACHI = '" + address + "', SDT = '" + phoneNumber + "' where TENDN = '" + userName + "'";
            }
            else if (newPassword == null || newPassword == "" & phoneNumber == null || phoneNumber == "")
            {
                query = "Update TAIKHOAN set DIACHI = '" + address + "' where TENDN = '" + userName + "'";
            }
            else if (address == null || address == "" & newPassword == null || newPassword == "")
            {
                query = "Update TAIKHOAN set SDT = '" + phoneNumber + "' where TENDN = '" + userName + "'";
            }
            else if (address == "" || address == null & phoneNumber == "" || phoneNumber == null)
            {
                query = "Update TAIKHOAN set MATKHAU = '" + newPassword + "' where TENDN = '" + userName + "'";
            }
            else
            {
                query = "Update TAIKHOAN set MATKHAU = '" + newPassword + "', SDT = '" + phoneNumber + "', DIACHI = '" + address + "' where TENDN = '" + userName + "'";
            }
            return query;
        }

        protected void visible_Controls(Control control, string action) // thay thế .visible = true
        {
            if (action.Equals("an"))
            {
                control.Visible = false;
            }
            else if (action.Equals("hien"))
            {
                control.Visible = true;
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            string mdh = DropDownList1.SelectedItem.Text;
            string tt = "done";
            int kq = tool.Action("update DH set TTDH= '" + tt + "' where MADH = '" + mdh + "'");            
            Bind_DH();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string mdh = DropDownList1.SelectedItem.Text;
            string tt = "canceled";
            int kq = tool.Action("update DH set TTDH= '" + tt + "' where MADH = '" + mdh + "'");
            Bind_DH();
            Response.Redirect(Request.RawUrl);
        }
    }
}
