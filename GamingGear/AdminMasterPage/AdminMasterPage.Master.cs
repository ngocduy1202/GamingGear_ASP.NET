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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            if (Page.IsPostBack) return;
            try
            {
                string query = "select * from TAIKHOAN where TENDN= '"+cookies+"' ";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                this.DataList1.DataSource = dataTable;
                this.DataList1.DataBind();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void lblAdminName_Click(object sender, EventArgs e)
        {
            Response.Cookies["TENDN"].Value = cookies;
            Response.Redirect("~/WebForm/Info.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm/AdminPages/QLTK.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm/AdminPages/QLH.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm/AdminPages/QLK.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm/AdminPages/TK.aspx");
        }
    }
}