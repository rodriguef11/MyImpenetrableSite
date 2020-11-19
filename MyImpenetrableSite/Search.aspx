<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyImpenetrableSite.Search" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">Search for</div>
        <div class="col-md-12">
            <asp:TextBox ID ="txtSearchTerms" runat="server" CssClass="form-control" required></asp:TextBox>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        </div>
        <div class="col-me-12">
            <asp:Label ID="lblSearchTerms" runat="server" CssClass=""></asp:Label>
        </div>
    </div>
</asp:Content>
