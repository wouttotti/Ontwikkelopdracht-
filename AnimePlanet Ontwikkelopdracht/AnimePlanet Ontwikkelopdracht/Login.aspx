<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AnimePlanet_Ontwikkelopdracht.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>    
    <div id="login" style="float: left; margin-left:100px; text-align: left; width: 300px; height: 325px; font-size:medium ">
            <asp:Label ID="LbGebruikersnaam" runat="server" Text="Gebruikersnaam:"></asp:Label>
            <asp:TextBox ID="TbInGebruikersnaam" runat="server" Width="200px" style="display: block"></asp:TextBox>
            <br />
            <asp:Label ID="LbWachtwoord" runat="server" Text="Wachtwoord:"></asp:Label>  
            <asp:TextBox ID="TbInWachtwoord" runat="server" Textmode="Password" Width="200px" style="display: block"></asp:TextBox>
            <br />
            <asp:Button ID="BtnLogin" runat="server" Text="Inloggen" OnClick="BtnLogin_Click" />
            <br />
            <br />
            <asp:Label ID="LbInlogError" runat="server" Text="Error"></asp:Label>
        </div>
        <div id="Register" style="float: right; margin-right:100px; text-align: left; width: 300px; height: 400px; font-size:medium ">
            <asp:Label ID="LbNaam" runat="server" Text="Gebruikersnaam:"></asp:Label>
            <asp:TextBox ID="TbRegNaam" runat="server" Width="200px" style="display: block"></asp:TextBox>
            <br />
            <asp:Label ID="LbEmail" runat="server" Text="Email:"></asp:Label>  
            <asp:TextBox ID="TbRegEmail" runat="server" Width="200px" style="display: block"></asp:TextBox>
            <br />
            <asp:Label ID="LbRegWachtwoord" runat="server" Text="Wachtwoord:"></asp:Label>  
            <asp:TextBox ID="TbRegWachtwoord" runat="server" Width="200px" style="display: block"></asp:TextBox>
            <br />
            <asp:Button ID="BtnRegister" runat="server" Text="Registreren" />
            <br />
            <br />
            <asp:Label ID="LbRegistreerError" runat="server" Text="Error"></asp:Label>
        </div>
    </div>
</asp:Content>
