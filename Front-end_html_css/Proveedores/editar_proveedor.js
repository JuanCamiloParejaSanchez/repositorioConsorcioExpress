document.addEventListener("DOMContentLoaded", () => {
    const btnEditar = document.getElementById("editar");
  
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");
  
    /* const idProveedor = document.getElementById("idProveedor"); */
    const nitProveedor = document.getElementById("nitProveedor");
    const nombreProveedor = document.getElementById("nombreProveedor");
    const direccion = document.getElementById("direccion");
    const telefono = document.getElementById("telefono");
    const correo = document.getElementById("correo");
  
    fetch("http://www.consorcioexpress.somee.com/api/proveedor/" + id)
    /* fetch("https://localhost:44314/api/proveedor/" + id) */
      .then((response) => response.json())
      .then((data) => {
        data.forEach((proveedor) => {
            /* idProveedor.value = proveedor.IdProveedor; */
            nitProveedor.value = proveedor.NitProveedor;
            nombreProveedor.value = proveedor.NombreProveedor;
            direccion.value = proveedor.Direccion;
            telefono.value = proveedor.Telefono;
            correo.value = proveedor.Correo;
  
        });
      })
      .catch((error) =>
        console.error("Error al obtener datos de la API:", error)
      );
  
    btnEditar.addEventListener("click", () => {
  
      const data = {
        "idProveedor": id,
        "nitProveedor": nitProveedor.value,
        "nombreProveedor": nombreProveedor.value,
        "direccion": direccion.value,
        "telefono": telefono.value,
        "correo": correo.value
    }
  
  
      fetch("http://www.consorcioexpress.somee.com/api/proveedor/", {
      /* fetch("https://localhost:44314/api/proveedor/", { */
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => {
          
          if (response.ok) {
            console.log("Datos enviados correctamente");
            window.location.href = "listar_proveedor.html"
            
          } else {
            console.error("Error al enviar la solicitud:", response.status);
          }
        })
        .catch((error) => {
          console.error("Error al enviar la solicitud:", error);
        });
    }); 
  });