<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.Web.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 69px;
        }
        .auto-style2 {
            width: 446px;
        }
        .auto-style3 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2" display="center">
            <asp:Label ID="Label4" runat="server" Text="Inicio de Sesión" BackColor="#1C639C" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" Width="100%"></asp:Label>
            <div>
                <table class="auto-style3">
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbUsuario" runat="server" Width="226px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbPasswd" runat="server" style="margin-left: 0px" Width="225px" EnableViewState="False" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="auto-style1"></td>
                        <td>
                            <asp:Button ID="BtnAceptar" runat="server" Text="Ingresar" OnClick="BtnAceptar_Click" />
                        </td>
                    </tr>
                    <tr>
                           <td>
                               <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Olvidé mi contraseña</asp:LinkButton>
                           </td>
                        <td class="auto-style1">&nbsp;</td>
                        <td>
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error: usuario o contraseña incorrecto" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
