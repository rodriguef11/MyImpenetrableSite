<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyImpenetrableSite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-md-3">
            Username:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-12">&nbsp;</div>
        <div class="col-md-3">
            Password: 
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <div class="col-md-12">&nbsp;</div>
        <div class="col-md-12">
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Log In" OnClick="btnLogin_Click" />
        </div>
        <div class="col-md-12">
            <asp:Label ID="lblLoginError" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
