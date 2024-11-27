document.addEventListener("DOMContentLoaded", () => {
    const registrar = document.getElementById("registrarProveedor");
    const modalElement = document.getElementById("exampleModal");

    // Inicializar modal con Bootstrap
    const modal = new bootstrap.Modal(modalElement);
  
    registrar.addEventListener("click", (e) => {
      /* e.preventDefault(); */
  
      const nitProveedor = document.getElementById("nitProveedor").value;
      const nombreProveedor = document.getElementById("nombreProveedor").value;
      const direccion = document.getElementById("direccion").value;
      const telefono = document.getElementById("telefono").value;
      const correo = document.getElementById("correo").value;
  
      const data = {
        nitProveedor: nitProveedor,
        nombreProveedor: nombreProveedor,
        direccion: direccion,
        telefono: telefono,
        correo: correo
      }
  
      fetch(`http://www.consorcioexpress.somee.com/api/proveedor`, {
      /* fetch(`https://localhost:44314/api/proveedor/`, { */
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
              window.location.href = "../Menu_Principal/menu_principal.html";
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