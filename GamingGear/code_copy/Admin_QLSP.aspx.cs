//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace DoAn
//{
//    public partial class Admin_QLSP : System.Web.UI.Page
//    {
//        Tool tool = new Tool();
//        string conn = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Page.IsPostBack) return;
//            try
//            {
//                GridView1.DataSource = tool.GetData("select * from HANG");
//                GridView1.DataBind();
//            }
//            catch (SqlException er)
//            {

//                Response.Write(er.Message);
//            }
//        }

//        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//        {
//            GridView1.EditIndex = -1;
//            GridView1.DataSource = tool.GetData("SELECT * FROM HANG");
//            GridView1.DataBind();
//        }

//        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GridView1.EditIndex = e.NewEditIndex;
//            GridView1.DataSource = tool.GetData("SELECT * FROM HANG");
//            GridView1.DataBind();
//        }

//        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            string mahang = e.Values["MAHANG"].ToString();
//            int kq = tool.Action("DELETE FROM HANG WHERE MAHANG = '" + mahang + "'");
//            if (kq > 0)
//            {
//                Response.Write("<script>alert('Xóa thành công');</script>");
//                GridView1.DataSource = tool.GetData("SELECT * FROM HANG");
//                GridView1.DataBind();
//            }
//            else
//            {
//                Response.Write("<script>alert('Xóa không thành công');</script>");
//            }
//        }

//        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            string mahang = e.NewValues["MAHANG"].ToString();
//            string tenhang = e.NewValues["TENHANG"].ToString();
//            string dongia = e.NewValues["DONGIA"].ToString();
//            string mota = e.NewValues["MOTA"].ToString();
//            string maloai = e.NewValues["MALOAI"].ToString();
//            int kq = tool.Action("update HANG set TENHANG = '" + tenhang + "'," +
//                " DONGIA = '" + dongia + "', MOTA = '" + mota +
//                "', MALOAI = '" + maloai + "' where MAHANG = '" + mahang + "'");
//            if (kq > 0)
//            {
//                Response.Write("<script>alert('Cập nhật thành công');</script>");
//                GridView1.DataSource = tool.GetData("SELECT * FROM HANG");
//                GridView1.EditIndex = -1;
//                GridView1.DataBind();
//            }
//            else
//            {
//                Response.Write("<script>alert('Cập nhật không thành công');</script>");
//            }
//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            Server.Transfer("ADTool.aspx");
//        }

//        protected void Button2_Click(object sender, EventArgs e)
//        {
//            Panel1.Visible = true;
//        }

//        protected void Button3_Click(object sender, EventArgs e)
//        {
//            Panel1.Visible = false;
//        }

//        protected void Button4_Click(object sender, EventArgs e)
//        {
//            string mh = TextBox7.Text;
//            string th = TextBox8.Text;
//            string dg = TextBox9.Text;
//            string mt = TextBox10.Text;
//            //string ml = TextBox11.Text;
//            string ml = DropDownList1.SelectedItem.Text;
//            string img = "";
//            if(Path.GetFileName(FileUpload1.PostedFile.FileName) != "")
//            {
//                img = Path.GetFileName(FileUpload1.PostedFile.FileName);
//                FileUpload1.SaveAs(Server.MapPath("~/Image/") + img);
//            }
//            try
//            {
//                SqlConnection con = new SqlConnection(conn);
//                con.Open();
//                string query = "insert into HANG values (@MAHANG, @TENHANG, @DONGIA, @HINHANH, @MOTA, @MALOAI)";
//                SqlCommand cmd = new SqlCommand(query, con);
//                cmd.Parameters.AddWithValue("@MAHANG", mh);
//                cmd.Parameters.AddWithValue("@TENHANG", th);
//                cmd.Parameters.AddWithValue("@DONGIA", dg);
//                cmd.Parameters.AddWithValue("@HINHANH", img);
//                cmd.Parameters.AddWithValue("@MOTA", mt);
//                cmd.Parameters.AddWithValue("@MALOAI", ml);
//                cmd.ExecuteNonQuery();
//                con.Close();
//                sync();
//                Response.Write("<script>alert('Thêm thành công');</script>");
//            }
//            catch (SqlException ex)
//            {
//                Response.Write("<script>alert('Mã hàng đã tồn tại hoặc chưa điền đủ thông tin hàng!');</script>");
//            }
            
//        }

//        private void sync()
//        {
//            GridView1.DataSource = tool.GetData("Select * from HANG");
//            GridView1.DataBind();
//        }
//    }
    
//}