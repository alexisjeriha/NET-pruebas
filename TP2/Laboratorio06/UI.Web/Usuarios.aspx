<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="ContentUsuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <!-- Panel que continer la grilla -->
    <asp:Panel ID="gridPanel" runat="server">
        <h2>Usuarios:</h2><br/>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
            SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
            <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>

    <!-- Panel para edición de usuarios-->
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:Label ID="txtNom" runat="server" ForeColor="#CC3300" Visible="False">* El nombre no puede estar vacío</asp:Label>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:Label ID="txtApe" runat="server" ForeColor="#CC3300" Visible="False">* El apellido no puede estar vacío</asp:Label>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" Width="136px"></asp:TextBox>
        <asp:Label ID="txtEm" runat="server" ForeColor="#CC3300" Visible="False">* El email no tiene formato valido</asp:Label>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server" Width="126px"></asp:TextBox>
        <asp:Label ID="txtUsu" runat="server" ForeColor="#CC3300" Visible="False">* El nombre de usuario no puede ser vacío</asp:Label>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server" Width="138px"></asp:TextBox>
        <asp:Label ID="txtClave" runat="server" ForeColor="#CC3300" Visible="False">* La contraseña debe tener un minimo de 8 caracteres</asp:Label>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:Label ID="txtCC" runat="server" ForeColor="#CC3300" Visible="False"> * La confirmacion de la clave no coincide con la version original</asp:Label>
        <br />
    </asp:Panel>

    <!-- Panel botones-->
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar </asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar </asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>

</asp:Content>
