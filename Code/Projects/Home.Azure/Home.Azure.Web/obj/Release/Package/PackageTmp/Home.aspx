<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Home.Azure.Web.Home" %>

<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <div class="w3-container" style="width:100%;">
        <label class="w3-label w3-text-blue"><b>Upload Pin Codes</b></label>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" 
             CssClass="w3-btn w3-blue"/>
        <br /><br />
        <asp:Label ID="lblMessage" runat="server">
            <br />
        </asp:Label>
        <br />
        <div style="overflow:scroll;height:500px;">
        <asp:GridView ID="grdTable" runat="server" CssClass="w3-table w3-striped" AutoGenerateColumns="false"
            Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="GUID" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("GUID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pin Code" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Pin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <%--<asp:GridView ID="grdBlob" runat="server" CssClass="w3-table w3-striped" AutoGenerateColumns="false"
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
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Length") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ContentType" HeaderStyle-Width="25%" ItemStyle-Width="25%">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("ContentType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
    </div>
</asp:Content>
