<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>
        <ul class="navbar-nav navbar-right">
            <li><asp:TextBox id="message" runat="server" Text="Message Here" /></li>
            <li><asp:LinkButton Text="Send Mail" runat="server" CssClass="nav-item" OnClick="SendMail_Click" /></li>
        </ul>
    </main>
</asp:Content>
