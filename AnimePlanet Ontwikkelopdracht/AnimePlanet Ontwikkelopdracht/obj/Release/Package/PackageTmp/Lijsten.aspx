<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lijsten.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Lijsten" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">   
        <asp:Button ID="BtnAnime" runat="server" Text="Anime" width="100px" OnClick="BtnAnime_Click"/>
        <asp:Button ID="BtnManga" runat="server" Text="Manga" width="100px" OnClick="BtnManga_Click"/>
    </div>
    <div align="center">
        <asp:GridView ID="GvItemsLijst" runat="server" AutoGenerateColumns="false">

        </asp:GridView>
    </div>
</asp:Content>
