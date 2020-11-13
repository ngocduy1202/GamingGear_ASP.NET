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
    public partial class ProductInfo : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        string query = "";
        DataTable dataTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            bind_data_loaiHang();
            bind_data_product();
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
        }

        protected void KindOfProduct_Click(object sender, EventArgs e)
        {
            Context.Items["MALOAI"] = ((LinkButton)sender).CommandArgument.ToString();
            Server.Transfer("products.aspx");
        }

        protected void bind_data_loaiHang()
        {
            string query = "Select * from LOAIHANG";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.DataListLoaiSanPham.DataSource = dataTable;
            this.DataListLoaiSanPham.DataBind();
        }

        protected void bind_data_product()
        {
            if (Context.Items["MAHANG"] == null)
            {
                query = "select * from HANG where MAHANG = 1";
            }
            else
            {
                string maHang = Context.Items["MAHANG"].ToString();
                query = "select * from HANG where MAHANG = '" + maHang + "'";
            }
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                this.DataListProduct.DataSource = dataTable;
                this.DataListProduct.DataBind();

                DataTable dataTable1 = new DataTable();
                sqlDataAdapter.Fill(dataTable1);
                this.DataList1.DataSource = dataTable1;
                this.DataList1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void TaoGio()
        {
            dataTable = new DataTable();
            dataTable.Rows.Clear();
            dataTable.Columns.Add("MAHANG", typeof(string));
            dataTable.Columns.Add("TENHANG", typeof(string));
            dataTable.Columns.Add("SOLUONG", typeof(int));
            dataTable.Columns.Add("DONGIA", typeof(double));
            dataTable.Columns.Add("HINH", typeof(string));
            dataTable.Columns.Add("THANHTIEN", typeof(double));
            Session["GioHangDB"] = dataTable;
        }

        protected void btnAddToCard_Click(object sender, EventArgs e)
        {
            Button add = (Button)sender;
            DataListItem item = (DataListItem)add.Parent;

            string urlImage = "";
            bool isAdded = false;
            Image image = (Image)item.FindControl("Image1");
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            string productName = ((Label)item.FindControl("lblProductName")).Text;
            string price = ((Label)item.FindControl("lblPrice")).Text;
            
            string productID = add.CommandArgument.ToString();
            string quantity = ((DropDownList)item.FindControl("DropDownList")).SelectedValue;
            image = (Image)DataListProduct.Items[0].FindControl("Image1");
            
            string getURLImage = image.ImageUrl.ToString();
            string[] arrListStr = getURLImage.Split('/');
            for (int i = 0; i < arrListStr.Length; i++)
            {
                urlImage = arrListStr[arrListStr.Length - 1];
            }
            
            dataTable = (DataTable)Session["GioHangDB"];
            if (dataTable == null) TaoGio();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["MAHANG"].Equals(productID))
                {
                    dataRow["SOLUONG"] = quantity; // không cộng dồn số lượng, lấy số lượng trong datalist
                    isAdded = true;
                    break;
                }
            }
            if (!isAdded)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["MAHANG"] = productID;
                dataRow["TENHANG"] = productName;
                dataRow["SOLUONG"] = quantity;
                dataRow["DONGIA"] = Convert.ToDouble(price);
                dataRow["HINH"] = urlImage;
                dataRow["THANHTIEN"] = Convert.ToDouble(quantity) * Convert.ToDouble(price);
                dataTable.Rows.Add(dataRow);
            }
            Session["GioHangDB"] = dataTable;
        }

    }
}