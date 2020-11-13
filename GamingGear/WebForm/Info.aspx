<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="GamingGear.WebForm.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/CssInfo6.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="info-left">
            <div class="infor-user box left">
                <asp:DataList ID="DataList2" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("TENKH") %>'></asp:Label>
                        <div class="form1" runat="server">
                            <asp:Label ID="lbUserName" CssClass="lb1" runat="server" Text="User Name:"></asp:Label>
                            <asp:Label ID="lbAddress" CssClass="lb1" runat="server" Text="Address:"></asp:Label>
                            <asp:Label ID="lbPhoneNumber" CssClass="lb1" runat="server" Text="Phone Number:"></asp:Label>
                            <asp:Label ID="lbPassword" CssClass="lb1" runat="server" Text="Password:"></asp:Label>
                            <asp:Label ID="lbNewPassword" CssClass="lb1" runat="server" Text="New Password:"></asp:Label>
                            <asp:Label ID="lbRePassword" CssClass="lb1" runat="server" Text=" Re-Password:"></asp:Label>
                        </div>
                        <div class="form1" runat="server">
                            <asp:Label ID="lbUserNameShow" CssClass="tb" runat="server" Text='<%# Eval("TENDN") %>'></asp:Label>
                            <asp:TextBox ID="tbAddress" CssClass="tb" runat="server" Text='<%# Eval("DIACHI") %>'></asp:TextBox>
                            <asp:TextBox ID="tbPhoneNumber" CssClass="tb" runat="server" Text='<%# Eval("SDT") %>'></asp:TextBox>
                            <asp:TextBox ID="tbPasswordUpdate" CssClass="tb" runat="server" Text=''></asp:TextBox>
                            <asp:TextBox ID="tbNewPassword" CssClass="tb" runat="server" Text=''></asp:TextBox>
                            <asp:TextBox ID="tbRePasswordUpdate" CssClass="tb" runat="server" Text=''></asp:TextBox>
                        </div>
                        <div>
                            <br />
                            <asp:Label CssClass="lbl1" ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <span class="span-btn-all hover-btn css-location-btnUpdate">
                            <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="button button-update-size" runat="server" Text="Update" />
                        </span>
                    </ItemTemplate>
                </asp:DataList>

            </div>
            <!--user_left-->

            <div class="infor-product box left">
                <h1>Orders</h1>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" >
                    <Columns>
                        <asp:BoundField HeaderText="Order ID" DataField="MADH"/>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lbNgay" runat="server" Text='<%# Eval("NGAY") %>' HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TTDH">
                            <ItemTemplate>
                                <asp:Label ID="lbTTDH" runat="server" Text='<%# Eval("TTDH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbMaDH" runat="server" Text="More Detail" OnClick="lbMaDH_Click" CommandArgument='<%# Eval("MADH") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                                                
                        
                    </Columns>
                </asp:GridView>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Order ID"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDone" runat="server" OnClick="btnDone_Click" Text="Done" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                        </td>
                    </tr>
                    
                </table>
            </div>
            <!--product_left-->
        </div>

        <div id="orderDetail" runat="server" class="infor-details-product box">
            <h1>Order details</h1>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Product's Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbTenHang" runat="server" Text='<%# Eval("TENHANG") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Prire">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("DONGIA","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("SOLUONG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Total" DataField="THANHTIEN" DataFormatString="{0:0,0}"/>
                </Columns>
            </asp:GridView>
        </div>
        <!--details_product_right-->
    </div>
</asp:Content>
