document.addEventListener("DOMContentLoaded", () => {
    const btnEditar = document.getElementById("editar");
  
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");
  
    const referenciaProducto = document.getElementById("referenciaProducto");
    const nombreProducto = document.getElementById("nombreProducto");
    const precio = document.getElementById("precio");
    const cantidad = document.getElementById("cantidad");

    // Inicializar modal de Bootstrap
    const modalElement = document.getElementById("exampleModal");
    const modal = new bootstrap.Modal(modalElement);

    // Botones dentro del modal
    const confirmButton = document.getElementById("btn-confirmar");
    const cancelButton = document.getElementById("btn-cancelar");
  
    //fetch("http://www.consorcioexpress.somee.com/api/inventario/" + id)
    fetch("https://localhost:44314/api/inventario/" + id)
      .then((response) => response.json())
      .then((data) => {
        data.forEach((producto) => {
            /* idProveedor.value = proveedor.IdProveedor; */
            referenciaProducto.value = producto.ReferenciaProducto;
            nombreProducto.value = producto.NombreProducto;
            precio.value = producto.Precio;
            cantidad.value = producto.Cantidad;  
        });
      })
      .catch((error) =>
        console.error("Error al obtener datos de la API:", error)
      );
  
    // Mostrar modal al hacer clic en "Editar"
    btnEditar.addEventListener("click", () => {
      modal.show(); // Mostrar modal para confirmar
    });

    // Manejar confirmación en el modal
    confirmButton.addEventListener("click", () => {  
      const data = {
        "referenciaProducto": id,
        "nombreProducto": nombreProducto.value,
        "precio": precio.value,
        "cantidad": cantidad.value
      }
  
  
      //fetch("http://www.consorcioexpress.somee.com/api/inventario/", {
      fetch("https://localhost:44314/api/inventario/", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => {
          
          if (response.ok) {
            modal.hide();
            window.location.href = "../Inventario/listar_producto.html"
            
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