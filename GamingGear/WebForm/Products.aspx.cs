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
    public partial class Products : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string cookies = "";
        string query = "";
        DataTable dataTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            bind_data_loaiHang();
            Bind_Data_Kind_Of_Product();
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            
        }

        protected void bind_data_loaiHang() 
        {
            string query = "Select * from LOAIHANG";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.DataListLoaiSanPham.DataSource = dataTable;
            this.DataListLoaiSanPham.DataBind();
        }

        protected void Bind_Data_Kind_Of_Product()
        {
            string tt = "enable";
            if (Context.Items["MALOAI"] == null)
            {                
                query = "select * from HANG where HANG.TTH = '" + tt + "'";
            }
            else
            {
                string maloai = Context.Items["MALOAI"].ToString();
                query = "select * from HANG where MALOAI = '" + maloai + "' and HANG.TTH = '" + tt + "'";
            }
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                this.DataListProduct.DataSource = dataTable;
                this.DataListProduct.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void KindOfProduct_Click(object sender, EventArgs e) // linkbutton mã loại
        {
            Context.Items["MALOAI"] = ((LinkButton)sender).CommandArgument.ToString();
            Server.Transfer("products.aspx");
        }

        protected void btnMoreDetail_Click(object sender, EventArgs e) // nút xem chi tiết
        {
            Context.Items["MAHANG"] = ((Button)sender).CommandArgument.ToString();
            Server.Transfer("ProductInfo.aspx");
        }

        protected void TaoGio() // tạo session giỏ hàng
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

        protected void btnAddToCard_Click(object sender, EventArgs e) //nút thêm vào giỏ
        {
            cookies = Context.Request.Cookies["TENDN"] != null ? Context.Request.Cookies["TENDN"].Value : "";
            Button add = (Button)sender;
            DataListItem item = (DataListItem)add.Parent;
            string urlImage = "";
            string productName = ((Label)item.FindControl("lblProductName")).Text;
            string price = ((Label)item.FindControl("lblPrice")).Text;
            string productID = add.CommandArgument.ToString();
            int quantity = 1;
            bool isAdded = false;

            Image image = (Image)item.FindControl("Image1");//lấy URL hình
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
                if (dataRow["MAHANG"].Equals(productID)) //cộng dồn số lượng khi click nút mua nhanh
                {
                    dataRow["SoLuong"] = Convert.ToInt32(dataRow["SoLuong"]) + Convert.ToInt32(quantity); 
                    isAdded = true;
                    break;
                }
            }
            if (!isAdded)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["MAHANG"] = productID;
                dataRow["TENHANG"] = productName;
                dataRow["SOLUONG"] = 1;
                dataRow["DONGIA"] = Convert.ToDouble(price);
                dataRow["HINH"] = urlImage;
                dataRow["THANHTIEN"] = Convert.ToDouble(quantity) * Convert.ToDouble(price);
                dataTable.Rows.Add(dataRow);
            }
            Session["GioHangDB"] = dataTable;
        }
    }
}