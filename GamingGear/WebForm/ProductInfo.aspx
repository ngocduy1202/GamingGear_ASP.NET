<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="GamingGear.WebForm.ProductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/CssProductInfo5.css" rel="stylesheet" />
    <link href="../Css/hoverButtonMain1.css" rel="stylesheet" />
    <style>

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="background-product1"></div>
    <div class="background-product2"></div>
    <div class="left">
        <h3>What we have:</h3>
        <asp:DataList ID="DataListLoaiSanPham" runat="server">
            <ItemTemplate>
                <li class="product-kind">
                    <asp:LinkButton CssClass="one-product-kind" ID="KindOfProduct" OnClick="KindOfProduct_Click" CommandArgument='<%#Eval("MALOAI") %>' runat="server"><%#Eval("TENLOAI") %></asp:LinkButton>
                </li>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="center">
        <div class="center-left">
            <asp:DataList ID="DataListProduct" runat="server">
                <ItemTemplate>
                    <asp:Image ID="Image1" CssClass="image-product" ImageUrl='<%#"~/Images/imageProduct1/"+Eval("HINHANH") %>' runat="server" />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="center-right">
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <div class="one-info name-product">
                        <asp:Label ID="lblProductName" Text='<%#Eval("TENHANG") %>' runat="server"></asp:Label>
                    </div>
                    <div class="one-info">
                        <asp:Label ID="Label2" runat="server" Text="Detail: "><%#Eval("MOTA") %></asp:Label>
                    </div>
                    <div class="one-info">
                        <asp:Label ID="Label1" runat="server" Text="Price: "></asp:Label>
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("DONGIA","{0:0,0}") %>'></asp:Label>
                    </div>
                    <div class="one-info">
                        <asp:Label ID="Label3" runat="server" Text="Status: "><%#Eval("TTH") %></asp:Label>
                    </div>
                    <div class="location-drop-down-list">
                        <span>Quantity: </span>
                        <asp:DropDownList ID="DropDownList" CssClass="drop-down-list" runat="server">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="button-detail">
                        <span class="span-btn-all hover-btn css-location-button-add">
                            <asp:Button CssClass="button button-add-size" ID="btnAddToCard" OnClick="btnAddToCard_Click" CommandArgument='<%#Eval("MAHANG") %>' runat="server" Text="Add To Card" />
                        </span>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
