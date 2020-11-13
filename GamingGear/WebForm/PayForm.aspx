<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayForm.aspx.cs" Inherits="GamingGear.WebForm.PayForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/CssPayForm2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="intro">
            <h3 id="info" runat="server">Order Detail</h3>
        </div>
        <div class="bill">
            <asp:GridView ID="GridView" CssClass="gridview" GridLines="None" runat="server" AutoGenerateColumns="False" Width="1100px" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblMaHang" CausesValidation="false" OnClick="lblMaHang_Click" CommandArgument='<%#Eval("MAHANG") %>' Text="Change Quantity" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                            <asp:Image CssClass="imgBill" ID="Image1" ImageUrl='<%#"~/Images/imageProduct1/"+Eval("HINH") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Product's Name" DataField="TENHANG" />
                    <asp:TemplateField HeaderText="Price">
                        
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("DONGIA","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="TextBox3" runat="server" Text='<%# Eval("SOLUONG") %>' CssClass="tbBill"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Total" DataField="THANHTIEN" DataFormatString="{0:0,0}" />
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div>
                <div class="btnReturn" id="btnReturnDiv" runat="server">
                    <span class="span-btn-all hover-btn css-location-button-return">
                        <asp:Button CssClass="button button-return-size" ID="btnReturn" CausesValidation="false" OnClick="btnReturn_Click" runat="server" Text="Return Product" />
                    </span>
                </div>

            </div>
            <div>
                <asp:Label CssClass="lbl2" ID="lbl" runat="server"></asp:Label>
            </div>
        </div>
        <div class="payform" id="payFormDiv" runat="server">
            <h3>Info deliver</h3>
            <div class="form1">
                <div class="rowone">
                    <h5>Address:</h5>
                    <asp:TextBox CssClass="textbox" ID="tbAddress"  runat="server"></asp:TextBox>
                </div>
                <div class="rowtow">
                    <h5>Phone Number:</h5>
                    <asp:TextBox CssClass="textbox" ID="tbPhoneNumber"  Width="445px"  runat="server"></asp:TextBox>
                </div>
                <div class="rowthree">
                    <h5 style="text-align: left">Note:</h5>
                    <asp:TextBox CssClass="textbox" ID="tbNote" runat="server"></asp:TextBox>
                </div>
                <div class="validator">
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the address" ControlToValidate="tbAddress"></asp:RequiredFieldValidator><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the phone number" ControlToValidate="tbPhoneNumber"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblSDT" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="btn">
                    <span class="span-btn-all hover-btn css-location css-location-button-buy-now">
                        <asp:Button CssClass="button button-buy-now-size" ID="btnBuyNow" OnClick="btnBuyNow_Click" runat="server" Text="Buy Now" />
                    </span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
