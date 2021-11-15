<%@ Page Theme="Theme" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Notas.aspx.cs" Inherits="UI.Web.Notas" %>

<asp:Content ID="ContentMaterias" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="container" style="margin-top: 50px">
        <div class="row mx-auto">
            <h2>Carga de Notas</h2>
        </div>
        <div class="row mx-auto">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="Black" CssClass="table table-light table-stripped table-hover">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID Inscripcion" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                            <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                            <asp:BoundField DataField="Nota" HeaderText="Nota" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                        </Columns>

                    </asp:GridView>
                </asp:Panel>
            </div>
            <div class="col">
                <div class="row">
                    <asp:Panel ID="formPanel" Visible="false" runat="server">
                        <div class="row">
                            <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
                            <asp:TextBox ID="notaTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqNota" runat="server" ControlToValidate="notaTextBox" ErrorMessage="* La nota no puede estar vacía" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                    </asp:Panel>
                </div>

                <br />
                <div class="row">
                </div>
                <div class="row">
                    <asp:Panel ID="gridActionsPanel" runat="server">
                        <asp:Button ID="editarLinkButton" runat="server" Style="margin-right: 5px" OnClick="editarLinkButton_Click" Text="Cargar Nota" CssClass="btn-sm btn-warning" />
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
