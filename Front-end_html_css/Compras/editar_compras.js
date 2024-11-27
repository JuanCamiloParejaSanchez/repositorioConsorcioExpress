document.addEventListener("DOMContentLoaded", () => {
    const btnEditar = document.getElementById("editarCompras");
  
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");
  
    const numeroFactura = document.getElementById("numeroFactura");
    const referenciaProducto = document.getElementById("referenciaProducto");
    const nombreArticulo = document.getElementById("nombreArticulo");
    const cantidad = document.getElementById("cantidad");
    const nombreProveedor = document.getElementById("nombreProveedor");
    const nitProveedor = document.getElementById("nitProveedor");
    const direccion = document.getElementById("direccion");
    const telefono = document.getElementById("telefono");
    const correo = document.getElementById("correo");    
    const total = document.getElementById("total");
  
    // Inicializar modal de Bootstrap
    const modalElement = document.getElementById("exampleModal");
    const modal = new bootstrap.Modal(modalElement);
  
    // Botones dentro del modal
    const confirmButton = document.getElementById("btn-confirmar");
    const cancelButton = document.getElementById("btn-cancelar");
  
    // Obtener datos del usuario
    //fetch("http://www.consorcioexpress.somee.com/api/compras/" + id)
    fetch("https://localhost:44314/api/compras/" + id)
    
        .then((response) => {
          if (!response.ok) {
            throw new Error("Error en la respuesta de la API: " + response.statusText);
          }
          return response.json();
        })
        .then((data) => {
          numeroFactura.value = data.numeroFactura || "";
          referenciaProducto.value = data.referenciaProducto || "";
          nombreArticulo.value = data.nombreArticulo || "";
          cantidad.value = data.cantidad || "";
          nombreProveedor.value = data.nombreProveedor || "";
          nitProveedor.value = data.nitProveedor || "";
          direccion.value = data.direccion || "";
          telefono.value = data.telefono || "";
          correo.value = data.correo || "";
          total.value = data.total ? data.total.substring(0, 10) : "";
        })
        .catch((error) => console.error("Error al obtener datos de la API:", error));
  
      
  
    // Mostrar modal al hacer clic en "Editar"
    btnEditar.addEventListener("click", () => {
      modal.show(); // Mostrar modal para confirmar
    });
  
    // Manejar confirmación en el modal
    confirmButton.addEventListener("click", () => {
      const data = {
        numeroFactura: id,
        referenciaProducto: referenciaProducto.value,
        nombreArticulo: nombreArticulo.value,
        cantidad: cantidad.value,
        nombreProveedor: nombreProveedor.value,
        nitProveedor: nitProveedor.value,
        direccion: direccion.value,
        telefono: telefono.value,
        correo: correo.value,        
        total: total.value
      };
  
      //fetch("http://www.consorcioexpress.somee.com/api/compras/", {
      fetch("https://localhost:44314/api/compras/", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => {
          if (response.ok) {          
            modal.hide();
            window.location.href = "../Compras/listar_compras.html";
          } else {
            console.error("Error al enviar la solicitud:", response.status);
          }
        })
        .catch((error) => {
          console.error("Error al enviar la solicitud:", error);
        });
    });
  
    // Manejar cancelación en el modal
    cancelButton.addEventListener("click", () => {
      modal.hide(); // Ocultar modal sin realizar cambios
    });
  });


  // .then((response) => response.json())
      // .then((data) => {
      //   data.forEach((usuario) => {
      //       numeroFactura.value = usuario.numeroFactura;
      //       referenciaProducto.value = usuario.referenciaProducto;
      //       nombreArticulo.value = usuario.nombreArticulo;
      //       cantidad.value = usuario.cantidad;
      //       nombreProveedor.value = usuario.nombreProveedor;
      //       nitProveedor.value = usuario.nitProveedor;
      //       direccion.value = usuario.direccion;
      //       telefono.value = usuario.telefono;
      //       correo.value = usuario.correo;            
      //       total.value = usuario.total.substring(0, 10);
      //   });
      // })
      // .catch((error) =>
      //   console.error("Error al obtener datos de la API:", error)
      //);