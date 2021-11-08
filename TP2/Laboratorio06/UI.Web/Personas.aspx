<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<asp:Content ID="ContentPersonas" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container" style="margin-top: 50px">
        <div class="row mx-auto">
            <h2>Personas</h2>
        </div>
        <div class="row mx-auto">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField='FechaNacimiento' HeaderText="Fecha de nacimiento" />
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
                        <div class="row">
                            <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                            <asp:TextBox ID="nombreTextBox" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqNombre" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="* El nombre no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                            <asp:TextBox ID="apellidoTextBox" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqApellido" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="* El apellido no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
                            <asp:TextBox ID="direccionTextBox" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqDireccion" runat="server" ControlToValidate="direccionTextBox" ErrorMessage="* La direccion no puede estar vacía" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
                            <asp:TextBox ID="emailTextBox" runat="server" Width="250px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regExValMail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="* El email no tiene formato válido" ForeColor="#CC3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>

                        <div class="row">
                            <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
                            <asp:TextBox ID="telefonoTextBox" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqtelefono" runat="server" ControlToValidate="telefonoTextBox" ErrorMessage="* El telefono no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <asp:Label ID="fechaNacLabel" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                            <asp:TextBox ID="fechaNacTextBox" runat="server" Width="250px" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqFechaNac" runat="server" ControlToValidate="fechaNacTextBox" ErrorMessage="* La fecha no puede estar vacía" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                            <asp:TextBox ID="legajoTextBox" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqLegajo" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="* El legajo no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>


                        <div class="row">
                            <asp:Label ID="TipoLabel" runat="server" Text="Tipo: "></asp:Label>
                        </div> 
                        <div>                        
                            <asp:DropDownList ID="tipoDropDownList" runat="server" DataValueField="IDTipo" DataTextField="Tipo">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ID="rqTipo" runat="server" ControlToValidate="TipoDropDownList" ErrorMessage="* Seleccione el tipo" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <asp:Label ID="planLabel" runat="server" Text="ID Plan: "></asp:Label>
                        </div> 
                        <div>  
                            <asp:DropDownList ID="iDPlanDropDownList" runat="server" DataValueField="Id" DataTextField="Descripcion">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ID="rqEspecialidad" runat="server" ControlToValidate="iDPlanDropDownList" ErrorMessage="* Seleccione el plan" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                </asp:Panel>
            </div>

            <br />
            <div class="row">
            </div>
            <div class="row">
                <asp:Panel ID="gridActionsPanel" runat="server">
                    <asp:Button ID="nuevoLinkButton" runat="server" Style="margin-right: 5px" OnClick="nuevoLinkButton_Click" Text="Nuevo" CssClass="btn-sm btn-success" />
                    <asp:Button ID="editarLinkButton" runat="server" Style="margin-right: 5px" OnClick="editarLinkButton_Click" Text="Editar" CssClass="btn-sm btn-warning" />
                    <asp:Button ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" Text="Eliminar" CssClass="btn-sm btn-danger" />
                </asp:Panel>
                <asp:Panel ID="gridConfirmPanel" Visible="false" runat="server">
                    <div>
                        <asp:Button ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" Style="margin-top: 10px" Text="Aceptar" CssClass="btn-sm btn-lg btn-primary" />
                        <asp:Button ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" Style="margin-top: 10px" CausesValidation="false" Text="Cancelar" CssClass="btn-sm btn-secondary btn-lg" />
                    </div>
                </asp:Panel>
            </div>

        </div>

    </div>
    </div>
</asp:Content>
