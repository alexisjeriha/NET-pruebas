<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>

<asp:Content ID="ContentInscripciones" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row mx-auto">
            <h2>Inscripciones</h2>
        </div>
        <div class="row mx-auto">
            <div class="col">
                <asp:Panel ID="gridPanel" runat="server">

                    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                            <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                            <asp:BoundField DataField="AnioCurso" HeaderText="Año de Cursado" />
                            <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                            <asp:BoundField DataField="Nota" HeaderText="Nota" />
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
                            <asp:Label ID="lblMaterias" Font-Size="Medium" Font-Bold="true" runat="server">Materias:</asp:Label>
                            <asp:GridView ID="GridViewMaterias" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ID"
                                OnSelectedIndexChanged="GridViewMaterias_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Materia" />
                                    <asp:BoundField DataField="HsSemanales" HeaderText="Hs Semanales" />
                                    <asp:BoundField DataField="HsTotales" HeaderText="Hs Totales" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
                                <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
                            </asp:GridView>

                        </div>
                        <div class="row">
                            <asp:Label ID="lblCom" Font-Size="Medium" Font-Bold="true" runat="server" Visible="false">Comisiones:</asp:Label>
                            <asp:GridView ID="GridViewComisiones" runat="server"
                                AutoGenerateColumns="False" DataKeyNames="ID"
                                OnSelectedIndexChanged="GridViewComisiones_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Comision" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
                                <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
                            </asp:GridView>

                        </div>
                        <div class="row">
                            <asp:Label ID="anioCursoLabel" runat="server" Text="Año de Cursado: "></asp:Label>
                            <asp:TextBox ID="anioCursoTextBox" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqAnioCurso" runat="server" ControlToValidate="anioCursoTextBox" ErrorMessage="* El año de cursado no puede estar vacío" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
                            <asp:TextBox ID="notaTextBox" runat="server" Width="300px"></asp:TextBox>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <div class="row">
                </div>
                <div class="row">
                    <asp:Panel ID="gridActionsPanel" runat="server">
                        <asp:Button ID="nuevoLinkButton" runat="server" Style="margin-right: 5px" OnClick="nuevoLinkButton_Click" Text="Nuevo" CssClass="btn-sm btn-success" />
                        
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
