<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GamingGear.WebForm.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/cssHome2.css" rel="stylesheet" />
    <link href="../Css/CssButtonHome1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="video">
        <video class="myVideo" muted="" loop="" autoplay="" src="../Videos/Video.mp4"
            poster="">
        </video>
    </div>
    <div class='content-introduce'>
        <div class='shop-name-home'>
            <h1>Gaming Gear</h1>
        </div>
        <div class='sologan'>
            <span class="sologan-span">What you need, we own it!</span>
        </div>
        <span class="span-btn btn-order">
            <asp:Button ID="btnOrder" CssClass="btn-order-all" runat="server" Text="Order Now"/>
        </span>
    </div>



    <div class="product">
        <ul>
            <li><h1>THE NEXT WAVE OF WIRELESS</h1></li>
            <li><p>SLIPSTREAM CORSAIR WIRELESS TECHNOLOGY provides wireless devices with hyper-fast wireless transmission speeds and an ultra-long range, unwavering signal.</p></li>
        </ul>
        <div class="image">
            <img src="https://cwsmgmt.corsair.com/landing/slipstream/v3/img/wave-panel/wave-keyboard.png" alt="">
            <img src="https://cwsmgmt.corsair.com/landing/slipstream/v3/img/wave-panel/wave-headphones.png" alt="">
            <img src="https://cwsmgmt.corsair.com/landing/slipstream/v3/img/wave-panel/wave-mousepad.png" alt="">
            <img id="img4" src="https://cwsmgmt.corsair.com/landing/slipstream/v3/img/wave-panel/wave-mouse.png" alt="" ">
        </div>
        </div>
        <div class="product-head" style="background: url(https://cwsmgmt.corsair.com/landing/slipstream/v3/img/ultra-long-range/ultra-long-range-bg.jpg);">
            <ul>
                <li><h1>ULTRA-LONG RANGE</h1></li>
                <li><p>SLIPSTREAM WIRELESS signal strength lets you play your way, whether from the desktop or the couch, with up to 60ft of wireless range.*</p></li>
                <li>
                </li>
            </ul>
                <div class="oval"></div>
            <div class="image">
                <img src="https://cwsmgmt.corsair.com/landing/slipstream/v3/img/ultra-long-range/headphones.png" alt="">
                <div class="oval-mid"></div>
                <img id="img5" src="https://cwsmgmt.corsair.com/landing/slipstream/v3/img/ultra-long-range/usb.png" alt="">

                <span class="btn-headphone" >
                    <span class="span-btn btn-order" >
                        <asp:Button ID="btnOrderHeadPhone" CssClass="btn-order-all" runat="server" Text="Order Now"/>
                    </span>
                </span>
            </div>
        </div>
    <div class="content-3">
        <img class="img-content3" src="../Images/content3.jpg" />
        <span class="btn-headphone" id="order-monitor" >
                    <span  class="span-btn btn-order" >
                        <asp:Button ID="btnOrderMonitor" CssClass="btn-order-all" runat="server" Text="Order Mornitor"/>
                    </span>
                </span>
        <span class="btn-headphone" id="order-keyboard">
                    <span  class="span-btn btn-order" >
                        <asp:Button ID="btnOrderKeyboard" CssClass="btn-order-all" runat="server" Text="Order Keyboard"/>
                    </span>
                </span>
        <span class="btn-headphone" id="order-mouse">
                    <span  class="span-btn btn-order" >
                        <asp:Button ID="btnOrderMouse" CssClass="btn-order-all" runat="server" Text="Order Mouse"/>
                    </span>
                </span>
    </div>

</asp:Content>
