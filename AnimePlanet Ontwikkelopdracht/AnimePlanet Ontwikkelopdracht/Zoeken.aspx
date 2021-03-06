﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zoeken.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Zoeken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    

<div id="Zoeken" style="margin-left: 100px">
    <asp:Label ID="LlInfo" runat="server" Text="Zoeken naar anime, manga of personage's." Font-Bold="True" Font-Size="Large"></asp:Label>
    <br />
    <asp:TextBox ID="TbZoeken" runat="server" style="width: 300px" BorderStyle="None"></asp:TextBox>
    <asp:DropDownList ID="DdlSoort"  runat="server">
        <asp:ListItem>Anime</asp:ListItem>
        <asp:ListItem>Manga</asp:ListItem>
        <asp:ListItem>Personage</asp:ListItem>
    </asp:DropDownList>

    <br />
    <asp:Button ID="btnzoeken" runat="server" Text="Zoeken" Width="140px" OnClick="btnzoeken_Click" />
    <asp:Label ID="LbError" runat="server" Text="Error" Visible="False"></asp:Label>
    <asp:GridView ID="GvItems" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand">
       
    </asp:GridView>
    
    <br />
    </div>
</asp:Content>