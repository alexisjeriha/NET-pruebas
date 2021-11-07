<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
 <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="IdPersona" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                            <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo Persona" />
                            <asp:BoundField DataField="IDPlan" HeaderText="ID Plan" />
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
                    <asp:Panel ID="Panel1" Visible="false" runat="server">
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
                            <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
                            <asp:TextBox ID="direccionTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqDireccion" runat="server" ControlToValidate="direccionTextBox" ErrorMessage="* La direccion no puede estar vacía" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>

                        <div class="row">
                            <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
                            <asp:TextBox ID="emailTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regExValMail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="* El email no tiene formato válido" ForeColor="#CC3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="row">
                            <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
                            <asp:TextBox ID="telefonoTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqTelefono" runat="server" ControlToValidate="telefonoTextBox" ErrorMessage="* El telefono no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>


                        <div class="row">
                            <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                            <asp:TextBox ID="legajoTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqLegajo" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="* El legajo no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                    </asp:Panel>
            </asp:Panel>
        </div>
        </div>
        <asp:DropDownList ID="iDPlanDropDownList" runat="server">
        </asp:DropDownList>
        <br />
    </form>
</body>
</html>
