<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_ThongKe.aspx.cs" Inherits="DoAn.Admin_ThongKe" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" />

    &nbsp;&nbsp;&nbsp;
        <br />
        <table style="width:800px;">
            <tr>
                <td class="auto-style4">Doanh thu theo từng mặt hàng</td>
                <td class="auto-style2">
                    <asp:Button ID="Button4" runat="server" Text="Xem" OnClick="Button4_Click" />
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td>Doanh thu theo mã đơn hàng
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="MADH" DataValueField="MADH">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connect %>" SelectCommand="SELECT [MADH] FROM [DH]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Xem" />
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Doanh thu theo ngày
                    <asp:TextBox ID="TextBox2" TextMode="Date" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Xem" />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Doanh thu theo tháng
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button5" runat="server" Text="Xem" OnClick="Button5_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Tổng doanh thu</td>
                <td class="auto-style2">
                    <asp:Button ID="Button6" runat="server" Text="Xem" OnClick="Button6_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </div>
       <br />
    <div>
        <strong>THỐNG KÊ ĐƠN HÀNG</strong><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center"  BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="193px" Width="400px">
            <Columns>
                <asp:BoundField HeaderText="Mã đơn hàng" DataField="MADH" ItemStyle-Font-Bold="true"/>
                <asp:BoundField HeaderText="Tên đăng nhập" DataField="TENDN"/>                
                <%--<asp:BoundField HeaderText="Ngày" DataField="NGAY" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}"/>
                <asp:BoundField HeaderText="Địa chỉ" DataField="DIACHI"/> --%>               
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
    </div>
    <div>
        <table style="width: 500px;">
            <tr>
                <td>Mã đơn hàng</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Xem chi tiết" OnClick="Button2_Click" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Đóng" />
                </td>
            </tr>            
        </table>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" HorizontalAlign="Center" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="131px" Width="1090px">
                 <Columns>
                <asp:BoundField HeaderText="Mã đơn hàng" DataField="MADH" ItemStyle-Font-Bold="true"/>
                <asp:BoundField HeaderText="Tên đăng nhập" DataField="TENDN"/>
                <asp:BoundField HeaderText="Mã hàng" DataField="MAHANG"/>
                     <asp:TemplateField HeaderText="Ảnh">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Image ID="Image1" runat="server" Width="100px" ImageUrl='<%#"~/Image/"+Eval("HINHANH") %>' />
                         </ItemTemplate>
                     </asp:TemplateField>
                <asp:BoundField HeaderText="Tên hàng" DataField="TENHANG"/>
                <asp:BoundField HeaderText="Đơn giá" DataField="DONGIA"  DataFormatString="{0:0,0}"/>
                <asp:BoundField HeaderText="Số lượng" DataField="SOLUONG"/>
                <asp:BoundField HeaderText="Thành tiền"  DataField="THANHTIEN" DataFormatString="{0:0,0}"/>
                <asp:BoundField HeaderText="Ngày" DataField="NGAY" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}"/>
                <asp:BoundField HeaderText="Địa chỉ" DataField="DIACHI"/>                
            </Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" ForeColor="#003399" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SortedAscendingCellStyle BackColor="#EDF6F6" />
                 <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                 <SortedDescendingCellStyle BackColor="#D6DFDF" />
                 <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </asp:Panel>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            width: 54px;
        }
        .auto-style3 {
            width: 299px;
        }
        .auto-style4 {
            width: 251px;
        }
    </style>
</asp:Content>

