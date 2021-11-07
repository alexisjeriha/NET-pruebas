<%@ Page Theme="Theme" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<asp:Content ID="ContentEspecialidades" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="col" style="margin-top: 50px">
        <div class="row">
            <h2>Especialidades</h2>
        </div>
        <div class="row">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descipción" />
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
                            <asp:RequiredFieldValidator ID="rqDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="* La descripción no puede estar vacía" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                        </div>
                    </asp:Panel>
                </div>
                <br />
                <div class="row">
                </div>
                <div class="row">
                    <asp:Panel ID="gridActionsPanel" runat="server">
                        <asp:Button ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" Text="Nuevo" CssClass="btn-sm btn-success" />
                        <asp:Button ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" Text="Editar" CssClass="btn-sm btn-warning" />
                        <asp:Button ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" Text="Eliminar" CssClass="btn-sm btn-danger" />
                    </asp:Panel>
                    <asp:Panel ID="gridConfirmPanel" Visible="false" runat="server">
                        <div>
                            <asp:Button ID="aceptarLinkButton" runat="server" style="margin-top:10px" OnClick="aceptarLinkButton_Click" Text="Aceptar" CssClass="btn-sm btn-lg btn-primary" />
                            <asp:Button ID="cancelarLinkButton" runat="server" style="margin-top:10px" OnClick="cancelarLinkButton_Click" CausesValidation="false" Text="Cancelar" CssClass="btn-sm btn-secondary btn-lg" />

                        </div>
                    </asp:Panel>
                </div>

            </div>

        </div>
    </div>
</asp:Content>


