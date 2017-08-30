<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUpdatePinCode.aspx.cs" Inherits="Home.Azure.Web.AddUpdatePinCode" %>

<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="w3-container" style="width:100%;">
        <label class="w3-label w3-text-blue"><b>Enter City</b></label>
        <asp:TextBox ID="txtCity" runat="server" CssClass="w3-text-blue"></asp:TextBox>
        <asp:Button ID="btnAddUpdatePinCode" runat="server" Text="Get Weather" OnClick="btnAddUpdatePinCode_Click"
             CssClass="w3-btn w3-blue"/>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>