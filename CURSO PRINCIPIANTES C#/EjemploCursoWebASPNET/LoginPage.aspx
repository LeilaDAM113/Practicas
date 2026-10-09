<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EjemploCursoWebASPNET.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LOGIN PAGE</title>
    <link href="css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="frmalg">
    <div class="container">
        <center>
            <h3>Acceder al servicio </h3>
        </center>
        <label for="uname"><b>Usuario</b></label>
        <asp:TextBox runat="server" ID="txt_Username" placeholder="Introduce el usuario"></asp:TextBox>
        
        <label for="psw"><b>Contraseña</b></label>
        <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Introduce la contraseña"></asp:TextBox>
        
        <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" Text="Acceder"  OnClick="btn_Login_Click"/>
        <asp:Button runat="server" ID="btn_cancel" Text="Cancelar" class="cnbtn" />
    </div>
</form>
</body>
</html>
