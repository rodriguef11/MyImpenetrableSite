<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyImpenetrableSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>My Impenetrable Site</h1>
        <p class="lead">This web application was built by me to teach my students about web security.</p>
        <p>Despite of the name of the web application, this web application is full of vulnerabilities that are intentionally designed this way so students will be able to learn how to identify them and to fix them.</p>
        <p class="text-danger">Disclosure: because this web application is designed to be vulnerable for the education purpose, do NOT deploy this application to any public accessible web server. You should only run this web application on localhost. This application is provided as-is and no technical support is available, and you use this application at your own risk.</p>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>What can you do?</h2>
            <p>You can detect common web application vulnerabilities, such as Scross-Site Scripting, Information Disclosure, SQL Injection, and more.</p>
            <p>I recommend you to start with the search page <a href="Search.aspx">here</a>.</p>
        </div>        
    </div>    
    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Sign in" OnClick="btnLogin_Click" />    
</asp:Content>
