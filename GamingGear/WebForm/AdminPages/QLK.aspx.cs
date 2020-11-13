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
    public partial class QLK : System.Web.UI.Page
    {
        Tool tool = new Tool();
        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                khoSync();
                phieuSync();
            }
            catch (SqlException er)
            {

                Response.Write(er.Message);
            }
        }

        private void phieuSync()
        {
            GridView1.DataSource = tool.GetData("select * from PHIEU");
            GridView1.DataBind();
        }

        private void khoSync()
        {
            GridView2.DataSource = tool.GetData("select * from KHO");
            GridView2.DataBind();
        }


        private string getdate()
        {
            DateTime today = DateTime.Now;
            return today.ToString("MM/dd/yyyy");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string mp = e.Values["MAPHIEU"].ToString();
            int kq = tool.Action("DELETE FROM PHIEU WHERE MAPHIEU = '" + mp + "'");
            if (kq > 0)
            {
                Response.Write("<script>alert('Xóa thành công');</script>");
                GridView1.DataSource = tool.GetData("SELECT * FROM PHIEU");
                GridView1.DataBind();
                //int rs = tool.Action("DBCC CHECKIDENT ('PHIEU', RESEED, 0)"); reset identity
            }
            else
            {
                Response.Write("<script>alert('Xóa không thành công');</script>");
            }
        }


        protected void btnADD_Click(object sender, EventArgs e)
        {
            string lp = DropDownList1.SelectedItem.Value.ToString();
            string mh = DropDownList2.SelectedItem.Text;
            string sl = TextBox2.Text;
            string date = TextBox3.Text;
            string mk = "1";

            int kq = tool.Action("insert into PHIEU values('" + lp + "','" + mh + "','" + sl + "','" + date + "')");
            if (kq > 0)
            {
                Response.Write("<script>alert('Tạo phiếu thành công');</script>");
                phieuSync();
            }
            else
            {
                Response.Write("<script>alert('Phiếu đã tồn tại hoặc không hợp lệ');</script>");
            }

            if (DropDownList1.SelectedItem.Text == "Nhập")
            {
                SqlConnection connection = new SqlConnection(conn);
                connection.Open();
                SqlCommand cmd = new SqlCommand("insKho", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makho", mk);
                cmd.Parameters.AddWithValue("@mahang", mh);
                cmd.Parameters.AddWithValue("@soluong", sl);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                int kq1 = tool.UpdateData("update KHO set SOLUONG = SOLUONG - " + sl + "" +
                    "where MAKHO = " + mk + " and MAHANG = " + mh + "");
                if (kq1 > 0)
                {
                    khoSync();
                }
            }
            khoSync();
            phieuSync();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
    }
}