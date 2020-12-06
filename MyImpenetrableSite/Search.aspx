<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyImpenetrableSite.Search" ValidateRequest="true"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">Search for</div>
        <div class="col-lg-12">
            <asp:TextBox ID ="txtSearchTerms" runat="server" CssClass="form-control" required="true"></asp:TextBox>
        </div>
        </div>
    <div class="row">
        <div class="col-lg-12">&nbsp;</div>
        <div class="col-lg-12">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        </div>
        <div class="col-lg-12">&nbsp;</div>
        <div class="col-lg-12">
            <asp:Label ID="lblSearchTerms" runat="server" CssClass="" ></asp:Label>
        </div>
    </div>
</asp:Content>
