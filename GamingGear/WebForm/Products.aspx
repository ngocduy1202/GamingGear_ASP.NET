<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="GamingGear.WebForm.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/CssProducts8.css" rel="stylesheet" />
    <link href="../Css/CssButtonHome1.css" rel="stylesheet" />
    <link href="../Css/hoverButtonMain1.css" rel="stylesheet" />
    <link href="../Css/CssSearchBar3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <div class="search-form">
            <asp:TextBox ID="TextBox1" runat="server" class="textbox-search" placeholder="What are you finding..."></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="linkbutton-search"><i class="fas fa-search"></i></asp:LinkButton>
        </div>
        <div class="product">
            <asp:DataList ID="DataListProduct" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                <ItemTemplate>
                    <div class="product-size">
                        <div class="one-product">
                            <asp:Image ID="Image1" CssClass="image-product" ImageUrl='<%#"~/Images/imageProduct1/"+Eval("HINHANH") %>' runat="server" />
                            <div class="some-info-product">
                                <span class="some-info">
                                    <asp:Label ID="Label1" runat="server" Text='Name:'></asp:Label>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("TENHANG") %>'></asp:Label><br />
                                </span>
                                <span class="some-info">
                                    <asp:Label ID="Label3" runat="server" Text='Price:'></asp:Label>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("DONGIA","{0:0,0}") %>'></asp:Label>
                                </span>
                                <div class="button-in-product">
                                    <span class="span-btn-all hover-btn border-btn">
                                        <asp:Button CssClass="button button-size" OnClick="btnAddToCard_Click" ID="btnAddToCard" CommandArgument='<%#Eval("MAHANG") %>' runat="server" Text="Add to card" />
                                    </span>
                                    <span class="span-btn-all hover-btn border-btn">
                                        <asp:Button CssClass="button button-size" OnClick="btnMoreDetail_Click" ID="btnMoreDetail" CommandArgument='<%#Eval("MAHANG") %>' runat="server" Text="More detail" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
