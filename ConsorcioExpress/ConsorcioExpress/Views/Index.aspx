<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ConsorcioExpress.Views.Index" %>

<!DOCTYPE html>
<html lang="es">
  <head runat="server">
    <title>Página de inicio | Consorcio Express</title>

    <!-- Metadatos -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="author" content="Camilo Pareja">
    <meta name="description" content="Software Consorcio Express">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <!-- Favicon -->
    <link rel="icon" type="image/x-icon" href="../Imagenes/DOR.jpg">

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Iconos de Bootstrap -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <!-- CSS -->
    <link rel="stylesheet" href="../Views/Index.css">

  </head>

  <body>

    <!-- Barra de navegación -->
    <form method="post" id="registroForm" runat="server" action="Index.aspx">
        <nav class="navbar navbar-expand-md navbar-light" runat="server">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img src="../Imagenes/ConsorcioExpress.jpg" width="100" alt="Logo de la página web">
                </a>
                <div class="d-flex ms-auto">
                    
                        <asp:button class="btn btn-navbar me-2" type="button" Text="Iniciar Sesión" runat="server" OnClick="BtnIniciarSesion"></asp:button>   
                    
                        <asp:button class="btn btn-navbar" type="button" Text="Registrarse" runat="server" OnClick="BtnRegistrarUsuario"></asp:button>
                    
                </div>
            </div>
        </nav>
       

  
        <!-- Menú principal -->

    
        <div class="container">
            <div class="botones-container">
                
                  <asp:button type="button" class="btn-custom" id="botonUsuarios" Text="Usuarios" runat="server"></asp:button>
                  <asp:button type="button" class="btn-custom" id="botonAdministrador" Text="Proveedores" runat="server"></asp:button>
                  <asp:button type="button" class="btn-custom" id="botonInventario" Text="Inventario" runat="server"></asp:button>
                  <asp:button type="button" class="btn-custom" id="botonCompras" Text="Compras" runat="server"></asp:button>
                  <asp:button type="button" class="btn-custom" id="botonConductores" Text="Conductores" runat="server"></asp:button>
                  <asp:button type="button" class="btn-custom" id="botonVehiculos" Text="Vehículos" runat="server"></asp:button>            
                
            </div>
            <div class="separator"></div> <!-- Línea vertical -->
    
            <div class="carrusel-container d-flex">
  
                <div class="carousel slide" id="carouselExample" data-ride="carousel" data-interval="5000">
                  <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                  </ol>
                  <div class="carousel-inner vw-100">
                    <div class="carousel-item active" data-base-interval="2000"  data-base-ride="carousel">
                      <img src="../Imagenes/anuncio-1.jpg" class="d-block w-100" alt="...">
                    </div>
                    <div class="carousel-item">
                      <img src="../Imagenes/anuncio-2.jpg" class="d-block w-100" alt="...">
                    </div>
                    <div class="carousel-item">
                      <img src="../Imagenes/anuncio-3.jpg" class="d-block w-100" alt="...">
                    </div>
                  </div>
                  
                      <asp:button class="carousel-control-prev" type="button" runat="server" data-bs-target="#carouselExample" data-bs-slide="prev"></asp:button>
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                  
                      <asp:button class="carousel-control-next" type="button" runat="server" data-bs-target="#carouselExample" data-bs-slide="next"></asp:button>
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                  
                </div>
            
            </div>
         </div>
     </form>
  
    
    <!-- Pie de página (footer) -->

    <footer id="pie-de-pagina" class="d-flex justify-content-between align-items-center">
      <!-- Contenedor de Iconos a la Izquierda -->
      <div class="iconos-redes-sociales d-flex">
          <a href="https://twitter.com/freecodecampES" target="_blank" rel="noopener noreferrer"> 
              <i class="bi bi-twitter"></i>
          </a>
          <a href="https://github.com/freeCodeCamp/freeCodeCamp" target="_blank" rel="noopener noreferrer"> 
              <i class="bi bi-github"></i>
          </a>
          <a href="https://www.instagram.com/freeCodeCamp/" target="_blank" rel="noopener noreferrer"> 
              <i class="bi bi-instagram"></i>
          </a>
          <a href="https://www.linkedin.com/" target="_blank" rel="noopener noreferrer"> 
              <i class="bi bi-linkedin"></i>
          </a>
          <a href="mailto:jeandoe@micorreo.com" target="_blank" rel="noopener noreferrer"> 
              <i class="bi bi-envelope"></i>
          </a>
      </div>
  
      <!-- Contenedor de Imagen y Texto a la Derecha -->
      <div class="footer-info d-flex align-items-center">
          <img class="footer-logo" src="../Imagenes/ConsorcioExpress.jpg" alt="Logo del portafolio">
          <div class="derechos-de-autor ms-3">Creado por Camilo Pareja (2024)</div>
      </div>
    </footer>
  

    <script src="../Index/index.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script> <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js"></script> <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js"></script> <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
  </body>
</html>
