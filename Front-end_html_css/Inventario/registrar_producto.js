document.addEventListener("DOMContentLoaded", () => {
    const registrar = document.getElementById("registrar");
    const modalElement = document.getElementById("exampleModal");

    // Inicializar modal con Bootstrap
    const modal = new bootstrap.Modal(modalElement);
  
    registrar.addEventListener("click", (e) => {
      /* e.preventDefault(); */
  
      const referenciaProducto = document.getElementById("referenciaProducto").value;
      const nombreProducto = document.getElementById("nombreProducto").value;
      const precio = document.getElementById("precio").value;
      const cantidad = document.getElementById("cantidad").value;      
  
      const data = {
        referenciaProducto: referenciaProducto,
        nombreProducto: nombreProducto,
        precio: precio,
        cantidad: cantidad    
      };

  
      //fetch(`http://www.consorcioexpress.somee.com/api/inventario`, {
      fetch(`https://localhost:44314/api/inventario/`, {
          method: "POST",
          headers:{
              "Content-Type": "application/json"
          },
          body: JSON.stringify(data)
      })
        .then((response) => {
          // Verificar si la respuesta es exitosa (código de estado 200)
          if (response.ok) {
            // Mostrar modal al enviar datos correctamente
            modal.show();

            // Opcional: Redirigir después de cerrar el modal
            const closeModalButton = document.getElementById("btn-cerrar-modal");
            closeModalButton.addEventListener("click", ()=>{
              window.location.href = "../Inventario/listar_producto.html";
            });            
  
          } else {
            console.error("Error al enviar la solicitud:", response.status);
          }
        })
        .catch((error) => {
          console.error("Error al enviar la solicitud:", error);
        });

        fetch("https://localhost:44314/api/ActualizarInventarioSalida", {
          method: "POST",
          headers: {
              "Content-Type": "application/json",
          },
          body: JSON.stringify({
              nombreArticulo: nombreArticulo,
              cantidad: cantidad,
          }),
        })
          .then(response => {
              if (response.ok) {
                  console.log("Inventario actualizado correctamente.");
              } else {
                  console.error("Error al actualizar el inventario.");
              }
        })
        .catch(error => console.error("Error en la solicitud:", error));
      
    });
  });