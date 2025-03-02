﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConsorcioExpress.Views.Login" %>

<!DOCTYPE html>
<html lang="es">
  <head runat="server">

    <!-- Metadatos -->
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="author" content="Camilo Pareja">
    <meta name="description" content="Software Consorcio Express">

    <!-- Titulo -->
    <title>Inicio Sesión | Consorcio Express</title>

    <!-- Favicon -->
    <link rel="icon" type="image/x-icon" href="../Views/DOR.jpg">

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
    rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"
    crossorigin="anonymous">
            
    <!-- Iconos de Bootstrap -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <!-- CSS -->
    <link rel="stylesheet" type="text/css" href="../Views/inicio_sesion.css">
    
  </head>
  <body>

    <!-- Seccion Principal -->

    <section class="container">
      <div class="left-form">
        <img src="../Views/Icono_inicio_sesion.jpg" alt="Imagen Consorcio Express" class="left-image">
      </div>
    
      <div class="right-form" id="btnInicio">
        <div class="form-container">
          <div class="d-flex justify-content-center">
            <img src="../Views/login-icon.svg" alt="login-icon" style="height: 7rem">
          </div>
    
          <h2>Iniciar Sesión</h2>
    
          <form method="post" id="registroForm" runat="server" action="Login.aspx">
           
            <asp:TextBox type="text" class="form-control" runat="server" id="txtDocumento" placeholder="Digita tu documento"></asp:TextBox>
    
            <asp:TextBox TextMode="Password" class="form-control" runat="server" id="txtContrasena" placeholder="Escribe la contraseña"></asp:TextBox>
    
            <div class="d-flex justify-content-around align-items-center mt-1">
              <div class="checkbox-container d-flex align-items-center gap-1">
                <asp:TextBox runat="server" class="checkbox-color btn-secondary form-check-input mt-3" type="checkbox"></asp:TextBox>
                <div class="pt-0.5" style="font-size: 0.9rem">Recordarme</div>
              </div>
              <div class="pt-0.8">
                <a href="http://127.0.0.1:5500/Usuarios/registrar_usuario.html" target="_blank" runat="server" rel="noopener noreferrer" class="text-decoration-none fw-semibold fst-italic" style="font-size: 0.9rem">¿No estás registrado?</a>
              </div>
            </div>            
              <p id="lblMensaje" runat="server" class="message"></p>
              <div style="text-align: center;">
                <asp:Button type="button" runat="server" CssClass="btn btn-primary mt-5" id="btnIngresar" Text="Ingresar" OnClick="BtnIniciarSesion_Click"></asp:Button>
              </div>
              
          </form>

        </div>
      </div>
    </section>
    
    <script src="../inicio_sesion.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    
  </body>
</html>
