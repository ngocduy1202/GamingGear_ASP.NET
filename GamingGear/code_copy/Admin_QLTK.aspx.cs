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
//    public partial class Admin_QLTK : System.Web.UI.Page
//    {
//        Tool tool = new Tool();
//        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Page.IsPostBack) return;
//            try
//            {
//                GridView1.DataSource = tool.GetData("select * from TAIKHOAN");
//                GridView1.DataBind();
//            }
//            catch (SqlException er)
//            {

//                Response.Write(er.Message);
//            }
//        }

//        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            string tendn = e.Values["TENDN"].ToString();
//            int kq = tool.Action("DELETE FROM TAIKHOAN WHERE TENDN = '"+tendn+"'");
//            if (kq > 0)
//            {
//                Response.Write("<script>alert('Xóa thanh công');</script>");
//                GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
//                GridView1.DataBind();
//            }
//            else
//            {
//                Response.Write("<script>alert('Xóa không thanh công');</script>");
//            }
//        }

//        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//        {            
//                GridView1.EditIndex = -1;
//                GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
//                GridView1.DataBind();            
//        }

//        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GridView1.EditIndex = e.NewEditIndex;
//            GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
//            GridView1.DataBind();
//        }

//        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            string tendn = e.NewValues["TENDN"].ToString();
//            string mk = e.NewValues["MATKHAU"].ToString();
//            string tenkh = e.NewValues["TENKH"].ToString();
//            string sdt = e.NewValues["SDT"].ToString();
//            string ltk = e.NewValues["LOAITK"].ToString();
//            int kq = tool.Action("update TAIKHOAN set MATKHAU = '" + mk + "'," +
//                " TENKH = '" + tenkh + "', SDT = '" + sdt +
//                "', LOAITK = '" + ltk + "' where TENDN = '" + tendn + "'");
//            if (kq > 0)
//            {
//                Response.Write("<script>alert('Cập nhật thanh công');</script>");
//                GridView1.DataSource = tool.GetData("SELECT * FROM TAIKHOAN");
//                GridView1.EditIndex = -1;
//                GridView1.DataBind();
//            }
//            else
//            {
//                Response.Write("<script>alert('Cập nhật không thanh công');</script>");
//            }
//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            Server.Transfer("ADTool.aspx");
//        }
//    }
//}