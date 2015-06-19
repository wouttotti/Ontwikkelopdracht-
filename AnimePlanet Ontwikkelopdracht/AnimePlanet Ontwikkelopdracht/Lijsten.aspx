<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lijsten.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Lijsten" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">   
        <asp:Label ID="LbInfo" runat="server" Text="Selecteer Manga of Anime om je lijst te bekijken."></asp:Label>
        <br />
        <asp:Button ID="BtnAnime" runat="server" Text="Anime" width="100px" OnClick="BtnAnime_Click"/>
        <asp:Button ID="BtnManga" runat="server" Text="Manga" width="100px" OnClick="BtnManga_Click"/>
        <br />
        <asp:Label ID="LbError" runat="server" Text="Error"></asp:Label>
    </div>
    <div align="center">
        <asp:GridView ID="GvItemsLijst" runat="server" AutoGenerateColumns="false">

        </asp:GridView>
    </div>
</asp:Content>
