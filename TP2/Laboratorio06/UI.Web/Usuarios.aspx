<%@ Page Theme="Theme" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="ContentUsuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="col" style="margin-top: 50px">
        <div class="row">
            <h2>Usuarios</h2>
        </div>
        <div class="row">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
                        <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
                    </asp:GridView>
                </asp:Panel>
            </div>
            <div class="col">
                <div class="row">
                    <asp:Panel ID="formPanel" Visible="false" runat="server">
                        <div class="row">
                            <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>

                            <asp:TextBox ID="nombreTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqNombre" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="* El nombre no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>
                        <div class="row">
                            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                            <asp:TextBox ID="apellidoTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqApellido" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="* El apellido no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>
                        <div class="row">
                            <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
                            <asp:TextBox ID="emailTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regExValMail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="* El email no tiene formato válido" ForeColor="#CC3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="row">
                            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
                            <asp:CheckBox ID="habilitadoCheckBox" runat="server" />

                        </div>
                        <div class="row">
                            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
                            <asp:TextBox ID="nombreUsuarioTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqNombreUsuario" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="* El nombre de usuario no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>
                        <div class="row">
                            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
                            <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexValClave" runat="server" ControlToValidate="claveTextBox" ErrorMessage="* La contraseña debe tener un minimo de 8 caracteres" ForeColor="#CC3300" ValidationExpression="^[\s\S]{6,}$"></asp:RegularExpressionValidator>
                        </div>


                        <div class="row">
                            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
                            <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                            <asp:CompareValidator ID="compareClave" runat="server" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox" ErrorMessage=" * La confirmacion de la clave no coincide con la version original" ForeColor="#CC3300"></asp:CompareValidator>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <div class="row">
                </div>
                <div class="row">
                    <asp:Panel ID="gridActionsPanel" runat="server">
                        <asp:Button ID="nuevoLinkButton" runat="server" style="margin-right:5px" OnClick="nuevoLinkButton_Click" Text="Nuevo" CssClass="btn-sm btn-success" />
                        <asp:Button ID="editarLinkButton" runat="server" style="margin-right:5px" OnClick="editarLinkButton_Click" Text="Editar" CssClass="btn-sm btn-warning" />
                        <asp:Button ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" Text="Eliminar" CssClass="btn-sm btn-danger" />
                    </asp:Panel>
                    <asp:Panel ID="gridConfirmPanel" Visible="false" runat="server">
                        <div>
                            <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" style="margin-top:10px" Text="Aceptar" CssClass="btn-sm btn-lg btn-primary" />
                            <asp:Button ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" style="margin-top:10px" CausesValidation="false" Text="Cancelar" CssClass="btn-sm btn-secondary btn-lg" />

                        </div>
                    </asp:Panel>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
