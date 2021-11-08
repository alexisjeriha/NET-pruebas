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
            width: 349px;
            height: 136px;
            position: fixed;
        }
        .auto-style3 {
            width: 100%;
            height: 109px;
        }
        .auto-style4 {
            height: 624px;
        }
        .auto-style5 {
            width: 243px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" class="auto-style4">
        <div class="auto-style2" display="center" dir="ltr" style="border-style: solid; top: 15px; left: 10px;">
            <asp:Label ID="Label4" runat="server" Text="Inicio de Sesión" BackColor="#1C639C" BorderStyle="None" BorderWidth="1px" ForeColor="White" Width="100%"></asp:Label>
            <div>
                <table class="auto-style3">
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="tbUsuario" runat="server" Width="226px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="tbPasswd" runat="server" style="margin-left: 0px" Width="225px" EnableViewState="False" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="auto-style1"></td>
                        <td class="auto-style5">
                            <asp:Button ID="BtnAceptar" runat="server" Text="Ingresar" OnClick="BtnAceptar_Click" />
                        </td>
                    </tr>
                    <tr>
                           <td>
                             
                           </td>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error: usuario o contraseña incorrecto" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
