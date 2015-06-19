<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gebruiker.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Gegevens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 100px; float:left">
        <asp:Label ID="LbInfo" runat="server" Text="Zoeken naar gebruikers" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <asp:TextBox ID="TbZoeken" runat="server" style="width: 300px" BorderStyle="None"></asp:TextBox>
        <br />
        <asp:Button ID="btnzoeken" runat="server" Text="Zoeken" Width="140px" OnClick="btnzoeken_Click"/>
        <br />
        <asp:Label ID="LbError1" runat="server" Text="Error" Font-Bold="False" Font-Size="Medium" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="GvGebruikers" runat="server" AutoGenerateColumns="False" OnRowCommand="gvGebruiker_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Email" DataField="Email"/>
                <asp:BoundField HeaderText="Naam" DataField ="Naam"/>
            </Columns>
        </asp:GridView>
    </div>
    <div style="float:right; margin-right: 100px;">
        <asp:Label ID="LbInfo2" runat="server" Text="Mensen die jij volgt" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <asp:Label ID="LbError2" runat="server" Text="Error" Font-Bold="False" Font-Size="Medium" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="GvVolgen" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Naam" DataField="Naam"/>
                <asp:BoundField HeaderText="Email" DataField="Email" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
