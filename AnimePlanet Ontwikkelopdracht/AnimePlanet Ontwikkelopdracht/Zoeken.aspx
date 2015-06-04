<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zoeken.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Zoeken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Stylesheet.css" rel="stylesheet" type="text/css" />
    <div id="Zoeken" style="margin-left: 100px">
    <asp:TextBox ID="TbZoeken" runat="server" style="width: 300px"></asp:TextBox>
    <asp:DropDownList ID="DdlSoort"  runat="server">
        <asp:ListItem>Anime</asp:ListItem>
        <asp:ListItem>Manga</asp:ListItem>
        <asp:ListItem>Personage</asp:ListItem>
    </asp:DropDownList>
    </div>
</asp:Content>

