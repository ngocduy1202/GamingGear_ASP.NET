<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_QLSP.aspx.cs" Inherits="DoAn.Admin_QLSP" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" />
        <asp:Button ID="Button2" runat="server" Text="Thêm hàng" OnClick="Button2_Click" />
        <br />
        <asp:Panel ID="Panel1" Visible="false" runat="server">
            <table style="width: 50%;">
                <tr>
                    <td>Mã hàng</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>Tên hàng</td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>Đơn giá</td>
                    <td>
                        <asp:TextBox ID="TextBox9" TextMode="Number" runat="server"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>Hình ảnh</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>                    
                </tr>
                <tr>
                    <td>Mô tả</td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>Mã Loại</td>
                    <td>
                        <%--<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>--%>

                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="MALOAI" DataValueField="MALOAI">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connect %>" SelectCommand="SELECT [MALOAI] FROM [LOAIHANG]"></asp:SqlDataSource>

                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Exit" OnClick="Button3_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="ADD" Width="165px" OnClick="Button4_Click" />
                    </td>                    
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:GridView ID="GridView1" runat="server" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="373px" Width="845px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Mã Hàng">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" Enabled="false" runat="server" Text='<%# Bind("MAHANG") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MAHANG") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên Hàng">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TENHANG") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("TENHANG") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Đơn Giá">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DONGIA") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server"  Text='<%# Bind("DONGIA","{0:0,0}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hình Ảnh">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" Enabled="false" runat="server" Text='<%# Bind("HINHANH") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" ImageUrl='<%#"~/Image/"+Eval("HINHANH") %>' Width="100px" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mô Tả">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("MOTA") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("MOTA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mã Loại">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("MALOAI") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("MALOAI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField CancelText="Huỷ" DeleteText="Xoá" EditText="Sửa" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />

<RowStyle HorizontalAlign="Center" BackColor="#E3EAEB"></RowStyle>
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    
</asp:Content>
