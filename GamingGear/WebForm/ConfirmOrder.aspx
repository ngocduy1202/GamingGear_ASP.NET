<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="GamingGear.WebForm.ConfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/CssPayForm.css" rel="stylesheet" />
    <link href="../Css/CssConfirmPage2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="intro">
            <h3 id="order">Order Bill</h3>
        </div>
        <div class="bill">
            <asp:GridView ID="GridView" CssClass="gridview" GridLines="None" runat="server" AutoGenerateColumns="False" Width="1100px" HorizontalAlign="Center">
                <Columns>
                    
                    
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
                    
                </Columns>
            </asp:GridView>
            <div class="info-order">
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server">
                    We will deliver your order to <%#Eval("DIACHI")%> soon. </br>
                    Please keep your phone number: <%# Eval("SDT")%> living, we will contact. Thanks for belive us.
                        </asp:Label>
                    </ItemTemplate>
                </asp:DataList>
            </div>

            <div>
                <h3>Please confirm the informations are true before order.</h3>
                
                <div class="box-button-confirm">
                    <div class="btn-confirm-order">
                        <span class="span-btn-all hover-btn box-cancel-button">
                            <asp:Button CssClass="button button-confirm-size" OnClick="btnCancel_Click" ID="btnCancel" runat="server" Text="Cancel" />
                        </span>
                    </div>
                    <div class="btn-cancel-order">
                        <span class="span-btn-all hover-btn box-confirm-button">
                            <asp:Button CssClass="button button-confirm-size"  ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
