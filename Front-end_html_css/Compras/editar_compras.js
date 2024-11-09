document.addEventListener("DOMContentLoaded", () => {
    const btnEditar = document.getElementById("editar");
  
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");
  
    const numeroFactura = document.getElementById("numeroFactura");
    const nombreProveedor = document.getElementById("nombreProveedor");
    const nitProveedor = document.getElementById("nitProveedor");
    const direccion = document.getElementById("direccion");
    const telefono = document.getElementById("telefono");
    const correo = document.getElementById("correo");
    const nombreArticulo = document.getElementById("nombreArticulo");
    const cantidad = document.getElementById("cantidad");
    const total = document.getElementById("total");
  
    // Inicializar modal de Bootstrap
    const modalElement = document.getElementById("exampleModal");
    const modal = new bootstrap.Modal(modalElement);
  
    // Botones dentro del modal
    const confirmButton = document.getElementById("btn-confirmar");
    const cancelButton = document.getElementById("btn-cancelar");
  
    // Obtener datos del usuario
    fetch("http://www.consorcioexpress.somee.com/api/compras/" + id)
      .then((response) => response.json())
      .then((data) => {
        data.forEach((usuario) => {
            numeroFactura.value = usuario.numeroFactura;
            nombreProveedor.value = usuario.nombreProveedor;
            nitProveedor.value = usuario.nitProveedor;
            direccion.value = usuario.direccion;
            telefono.value = usuario.telefono;
            correo.value = usuario.correo;
            nombreArticulo.value = usuario.nombreArticulo;
            cantidad.value = usuario.cantidad;
            total.value = usuario.total;
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
        numeroFactura: id,
        nombreProveedor: nombreProveedor.value,
        nitProveedor: nitProveedor.value,
        direccion: direccion.value,
        telefono: telefono.value,
        correo: correo.value,
        nombreArticulo: nombreArticulo.value,
        cantidad: cantidad.value,
        total: total.value
      };
  
      fetch("http://www.consorcioexpress.somee.com/api/compras/", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => {
          if (response) {          
            modal.hide();
            window.location.href = "listar_compras.html";
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