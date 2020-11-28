<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="MyImpenetrableSite.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row"><h3>User Profiles</h3></div>
    <div class="row">
        <div class="col-md-3">
            Username:
        </div>
        <div class="col-md-9">
            <asp:Label ID="lblUsername" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row">&nbsp;</div>
    <div class="row">
        <div class="col-md-3">
            First Name:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">&nbsp;</div>
    <div class="row">
        <div class="col-md-3">
            Last Name:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">&nbsp;</div>
    <div class="row">
        <div class="col-md-3">
            Email:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">&nbsp;</div>
    <div class="row">
        <div class="col-md-3">
            Telephone:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">&nbsp;</div>
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnUpdateProfile" runat="server" CssClass="btn btn-primary" Text="Update Profile" OnClick="btnUpdateProfile_Click" />
        </div>
    </div>
    <div class="row">&nbsp;</div>
</asp:Content>
