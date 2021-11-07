<%@ Page Theme="Theme" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="ContentMaterias" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<div class="col" style="margin-top: 50px">
        <div class="row">
            <h2>Materias</h2>
        </div>
        <div class="row">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" />
                            <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                            <asp:BoundField DataField="IDPlan" HeaderText="Plan" />
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
                            <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
                            <asp:TextBox ID="descripcionTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="* La descripción no puede estar vacía" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                            <div class="row">
                            <asp:Label ID="hssemanalesLabel" runat="server" Text="Horas Semanales: "></asp:Label>
                            <asp:TextBox ID="hssemanalesTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqHSSemanales" runat="server" ControlToValidate="hssemanalesTextBox" ErrorMessage="* La cantidad de horas a la semana no puede ser nula" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                            <div class="row">
                            <asp:Label ID="hstotalesLabel" runat="server" Text="Horas Totales: "></asp:Label>
                            <asp:TextBox ID="hstotalesTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqHSTotales" runat="server" ControlToValidate="hstotalesTextBox" ErrorMessage="* La cantidad de horas totales no puede ser nula" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:Label ID="planLabel" runat="server" Text="Plan ID: "></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="DropDownListPlanes" runat="server" DataValueField="Id" DataTextField="Descripcion">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqPlan" runat="server" ControlToValidate="DropDownListPlanes" ErrorMessage="* Seleccione el Plan" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
