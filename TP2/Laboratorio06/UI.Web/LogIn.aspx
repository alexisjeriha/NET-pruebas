<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.Web.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"></script>
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-family: sans-serif;
            background: linear-gradient(to right, #b92b27, #1565c0)
        }

        .card {
            margin-bottom: 20px;
            border: none
        }

        .box {
            width: 500px;
            padding: 40px;
            position: absolute;
            top: 50%;
            left: 50%;
            background: #191919;
            
            text-align: center;
            transition: 0.25s;
            margin-top: 100px
        }

            .box input[type="text"],
            .box input[type="password"] {
                border: 0;
                background: none;
                display: block;
                margin: 20px auto;
                text-align: center;
                border: 2px solid #3498db;
                padding: 10px 10px;
                width: 250px;
                outline: none;
                color: white;
                border-radius: 24px;
                transition: 0.25s
            }

            .box h1 {
                color: white;
                text-transform: uppercase;
                font-weight: 500
            }

            .box input[type="text"]:focus,
            .box input[type="password"]:focus {
                width: 300px;
                border-color: #2ecc71
            }

            .box input[type="submit"] {
                border: 0;
                background: none;
                display: block;
                margin: 20px auto;
                text-align: center;
                border: 2px solid #2ecc71;
                padding: 14px 40px;
                outline: none;
                color: white;
                border-radius: 24px;
                transition: 0.25s;
                cursor: pointer
            }

                .box input[type="submit"]:hover {
                    background: #2ecc71
                }

        .forgot {
            text-decoration: underline
        }

    </style>
</head>

<body>

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <form id="form1" runat="server" class="box">
                        <h1>Academia</h1>
                        <p class="text-muted">Por favor ingrese su usuario y contraseña</p>
                        <div>
                           <p class="text-muted">Usuario</p>

                            <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>

                            <p class="text-muted">Contraseña</p>

                            <asp:TextBox ID="tbPasswd" runat="server" TextMode="Password"></asp:TextBox>

                            <asp:Button ID="BtnAceptar" runat="server" Text="Ingresar" OnClick="BtnAceptar_Click1"/>

                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error: usuario o contraseña incorrecto" Visible="False"></asp:Label>

                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
