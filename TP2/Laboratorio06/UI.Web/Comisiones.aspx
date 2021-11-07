<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="ContentComisiones" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="col">
        <div class="row">
            <h2>Comisiones</h2>
        </div>
        <div class="row">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="IdComision" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="IdComision" HeaderText="ID" />
                            <asp:BoundField DataField="DescComision" HeaderText="Descripción" />
                            <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" />
                            <asp:BoundField DataField="IdPlan" HeaderText="ID Plan" />
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
                            <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
                            <asp:TextBox ID="descripcionTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="* El nombre no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>
                        <div class="row">
                            <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año Especialidad: "></asp:Label>
                            <asp:TextBox ID="anioEspecialidadTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqAnioEspecialidad" runat="server" ControlToValidate="anioEspecialidadTextBox" ErrorMessage="* El apellido no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:DropDownList ID="DropDownListPlanes" runat="server" DataValueField="Id" DataTextField="Descripcion">
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID"  runat="server" ControlToValidate="DropDownListPlanes" ErrorMessage="* Debe seleccionar un plan" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
