document.addEventListener("DOMContentLoaded", () => {
    const registrar = document.getElementById("registrar");
    const modalElement = document.getElementById("exampleModal");

    // Inicializar modal con Bootstrap
    const modal = new bootstrap.Modal(modalElement);
  
    registrar.addEventListener("click", (e) => {
      e.preventDefault();
  
      const numeroFactura = document.getElementById("numeroFactura").value;
      const nombreProveedor = document.getElementById("nombreProveedor").value;
      const nitProveedor = document.getElementById("nitProveedor").value;
      const direccion = document.getElementById("direccion").value;
      const telefono = document.getElementById("telefono").value;
      const correo = document.getElementById("correo").value;    
      const nombreArticulo = document.getElementById("nombreArticulo").value;
      const cantidad = document.getElementById("cantidad").value;
      const total = document.getElementById("total").value;
      
  
      const data = {
        numeroFactura: numeroFactura,
        nombreProveedor: nombreProveedor,
        nitProveedor: nitProveedor,
        direccion: direccion,
        telefono: telefono,
        correo: correo,
        nombreArticulo: nombreArticulo,
        cantidad: cantidad,
        total: total        
      }
  
      fetch(`http://www.consorcioexpress.somee.com/api/compras`, {
      /* fetch(`https://localhost:44314/api/compras/`, { */
          method: "POST",
          headers:{
              "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
      })
        .then((response) => {          
          if (response.ok) {
            // Mostrar modal al enviar datos correctamente
            modal.show();

          // Opcional: Redirigir después de cerrar el modal
          const closeModalButton = document.getElementById("btn-cerrar-modal");
          closeModalButton.addEventListener("click", () => {
            window.location.href = "../Compras/listar_compras.js";
          });  
          } else {
            console.error("Error al enviar la solicitud:", response.status);
          }
        })
        .catch((error) => {
          console.error("Error al enviar la solicitud:", error);
        });
    });
  });