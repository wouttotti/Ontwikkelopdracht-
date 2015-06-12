<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gebruiker.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Gegevens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 100px">
        <asp:TextBox ID="TbZoeken" runat="server" style="width: 300px" BorderStyle="None"></asp:TextBox>
        <br />
        <asp:Button ID="btnzoeken" runat="server" Text="Zoeken" Width="140px"/>
    </div>
    <div style="float:right; margin-right: 100px;">

    </div>
</asp:Content>
