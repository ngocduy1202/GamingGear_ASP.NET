using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GamingGear.WebForm
{
    public partial class PayForm : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        string query = "";
        DataTable dataTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
                Bind_Data_Page();
            }
            catch (Exception ex)
            {
                info.InnerText = "You Did Not Choose Any Product Yet. Your Product's Cart Is Empty";
                btnReturnDiv.Visible = false;
                payFormDiv.Visible = false;
                lbl.Visible = false;
            }
        }


        protected void Bind_Data_Page()
        {
            try // đổ data vào giỏ hàng
            {
                dataTable = (DataTable)Session["GioHangDB"];
                GridView.DataSource = dataTable;
                GridView.DataBind();
                if (dataTable.Rows.Count == 0)
                {
                    info.InnerText = "You Did Not Choose Any Product Yet. Your Product's Card Is Empty";
                    btnReturnDiv.Visible = false;
                    payFormDiv.Visible = false;
                    lbl.Visible = false;
                }
                double tong = 0;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    double thanhtien = Convert.ToDouble(dataTable.Rows[i]["SOLUONG"]) * Convert.ToDouble(dataTable.Rows[i]["DONGIA"]);
                    tong = tong + thanhtien;
                }

                this.lbl.Text = "Tổng cộng: " + Convert.ToDecimal(tong).ToString("#,##0");
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }
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

        protected void TaoThongTinDatHang()
        {
            dataTable = new DataTable();
            dataTable.Rows.Clear();
            dataTable.Columns.Add("TENDN", typeof(string));
            dataTable.Columns.Add("DIACHI", typeof(string));
            dataTable.Columns.Add("SDT", typeof(string));
            dataTable.Columns.Add("GHICHU", typeof(string));
            Session["TTDH"] = dataTable;
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            if (cookies == "")
            {
                Panel panelLogin = (Panel)Page.Master.FindControl("PanelLogin");
                panelLogin.Visible = true;
            }
            else
            {
                string address = tbAddress.Text;
                string phoneNumber = tbPhoneNumber.Text;
                string note = tbNote.Text;
                dataTable = (DataTable)Session["TTDH"];
                if (dataTable == null) TaoThongTinDatHang();
                bool isAdded = false;
                foreach (DataRow dataRow1 in dataTable.Rows)
                {
                    if (dataRow1["TENDN"].Equals(cookies))
                    {
                        
                        dataRow1["DIACHI"] = address;
                        dataRow1["SDT"] = phoneNumber;
                        dataRow1["GHICHU"] = note;
                        isAdded = true;
                        break;
                    }
                }
                if (! isAdded) {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["TENDN"] = cookies;
                    dataRow["DIACHI"] = address;
                    dataRow["SDT"] = phoneNumber;
                    dataRow["GHICHU"] = note;
                    dataTable.Rows.Add(dataRow);
                }
                Server.Transfer("ConfirmOrder.aspx");
            }
        }

        protected void lblMaHang_Click(object sender, EventArgs e)
        {
            string maHang = ((LinkButton)sender).CommandArgument.ToString();
            Context.Items["MAHANG"] = maHang;
            Server.Transfer("ProductInfo.aspx");
        }
    }
}
