using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GamingGear.AdminMasterPage
{
    public partial class QLTK : System.Web.UI.Page
    {
        Tool tool = new Tool();
        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                bindData();
            }
            catch (SqlException er)
            {
                Response.Write(er.Message);
            }
        }

        private void bindData()
        {
            GridView1.DataSource = tool.GetData("select * from TAIKHOAN");
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string tendn = e.NewValues["TENDN"].ToString();
            string mk = e.NewValues["MATKHAU"].ToString();
            string tenkh = e.NewValues["TENKH"].ToString();
            string sdt = e.NewValues["SDT"].ToString();
            string ltk = e.NewValues["LOAITK"].ToString();
            string dc = e.NewValues["DIACHI"].ToString();
            string tt = e.NewValues["TTTK"].ToString();
            int kq = tool.Action("update TAIKHOAN set MATKHAU = '" + mk + "'," +
                " TENKH = '" + tenkh + "', SDT = '" + sdt +
                "', LOAITK = '" + ltk + "', DIACHI = '" + dc + "', " +
                "TTTK = '" + tt + "'  where TENDN = '" + tendn + "'");
            if (kq > 0)
            {
                Response.Write("<script>alert('Cập nhật thành công');</script>");
                GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
                GridView1.EditIndex = -1;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Cập nhật không thanh công');</script>");
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
            GridView1.DataBind();
        }

        protected void btnLock_Click(object sender, EventArgs e)
        {            
            string tendn = DropDownList1.SelectedItem.Text;
            string tt = "disable";
            int kq = tool.Action("update TAIKHOAN set TTTK = '" + tt + "' where TENDN = '" + tendn + "'");
            bindData();
        }

        protected void btnUnlock_Click(object sender, EventArgs e)
        {            
            string tendn = DropDownList1.SelectedItem.Text;
            string tt = "enable";
            int kq = tool.Action("update TAIKHOAN set TTTK = '" + tt + "' where TENDN = '" + tendn + "'");
            bindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            TextBox tbtdn = (TextBox)GridView1.FooterRow.FindControl("tbtdn");
            string ten = tbtdn.Text;
            TextBox tbmk = (TextBox)GridView1.FooterRow.FindControl("tbmk");
            string mk = tbmk.Text;
            TextBox tbtenkh = (TextBox)GridView1.FooterRow.FindControl("tbtenkh");
            string tenkh = tbtenkh.Text;
            TextBox tbsdt = (TextBox)GridView1.FooterRow.FindControl("tbsdt");
            string sdt = tbsdt.Text;
            TextBox tbdiachi = (TextBox)GridView1.FooterRow.FindControl("tbdiachi");
            string dc = tbdiachi.Text;
            DropDownList drltk = (DropDownList)GridView1.FooterRow.FindControl("DropDownList2");
            string ltk = drltk.SelectedValue.ToString();
            DropDownList drtt = (DropDownList)GridView1.FooterRow.FindControl("DropDownList3");
            string tt = drtt.SelectedValue.ToString();
            if(ten == null)
            {
                Response.Write("<script>alert('Tên đăng nhập không được bỏ trống');</script>");
            }
            else
            {
                int kq = tool.Action("insert into TAIKHOAN values('" + ten + "','" + mk + "','" + tenkh + "','" + sdt + "'," +
                "'" + ltk + "','" + dc + "','" + tt + "')");
                if (kq > 0)
                {
                    Response.Write("<script>alert('Thêm thanh công');</script>");
                    bindData();
                    Response.Redirect(Request.RawUrl);
                }
            }
            
        }
    }
}