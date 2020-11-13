<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="QLH.aspx.cs" Inherits="GamingGear.AdminMasterPage.QLH" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">     
    
    <div>
        <asp:GridView ID="GridView1" runat="server" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="373px" Width="845px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
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
                    <asp:Image ID="Image1" ImageUrl='<%#"~/Images/imageProduct1/"+Eval("HINHANH") %>' Width="100px" runat="server" />
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
            <asp:BoundField HeaderText="Tình trạng" DataField="TTH" />
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Huỷ" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Sửa" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" OnClientClick="return confirm('Are u sure?');" CommandName="Delete" Text="Xoá" />
                </ItemTemplate>
            </asp:TemplateField>
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
    </div>
    
    <div>
        <asp:Button ID="btnThemHang" runat="server" Text="Thêm hàng" OnClick="btnThemHang_Click" />
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
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="MALOAI" DataValueField="MALOAI">
                        </asp:DropDownList>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connect %>" SelectCommand="SELECT [MALOAI] FROM [LOAIHANG]"></asp:SqlDataSource>

                    </td>                    
                </tr>
                <tr>
                    <td>Tình trạng</td>
                    <td>                        
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>enable</asp:ListItem>
                            <asp:ListItem>disable</asp:ListItem>
                        </asp:DropDownList>

                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnADD" runat="server" Text="ADD" Width="165px" OnClick="btnADD_Click" />
                    </td>                    
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>

        <table style="width:300px;">
            <tr>
                <td>Mã Hàng</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="MAHANG" DataValueField="MAHANG">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connect %>" SelectCommand="SELECT [MAHANG] FROM [HANG]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="btnLock" runat="server" OnClick="btnLock_Click" Text="Lock" />
                </td>
                <td>
                    <asp:Button ID="btnUnlock" runat="server" OnClick="btnUnlock_Click" Text="Unlock" />
                </td>
            </tr>            
        </table>

    </div>
</asp:Content>
