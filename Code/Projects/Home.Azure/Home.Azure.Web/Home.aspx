<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Home.Azure.Web.Home" %>

<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="w3-container" style="width:100%;">
        <label class="w3-label w3-text-blue"><b>Browse File</b></label><br />
        <asp:FileUpload ID="flupld" runat="server" CssClass="w3-btn w3-grey" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" 
             CssClass="w3-btn w3-blue"/>
        <br /><br /><br />
        <asp:GridView ID="grdBlob" runat="server" CssClass="w3-table w3-striped" AutoGenerateColumns="false"
            Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Uri" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Uri") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Length" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Properties.Length") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ContentType" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("Properties.ContentType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
