document.addEventListener("DOMContentLoaded", () => {

    const registrar = document.getElementById("registrar");
  
    registrar.addEventListener("click", (e) => {
      /* e.preventDefault(); */
  
      const idProveedor = document.getElementById("idProveedor").value;
      const nitProveedor = document.getElementById("nitProveedor").value;
      const nombreProveedor = document.getElementById("nombreProveedor").value;
      const direccion = document.getElementById("direccion").value;
      const telefono = document.getElementById("telefono").value;
      const correo = document.getElementById("correo").value;
  
      const data = {
        idProveedor: idProveedor,
        nitProveedor: nitProveedor,
        nombreProveedor: nombreProveedor,
        direccion: direccion,
        telefono: telefono,
        correo: correo
      }
  
      fetch(`http://www.consorcioexpress.somee.com/api/proveedor`, {
      /* fetch(`https://localhost:44303/api/registrousuario/`, { */
          method: "POST",
          headers:{
              "Content-Type": "application/json"
          },
          body: JSON.stringify(data)
      })
        .then((response) => {
          // Verificar si la respuesta es exitosa (código de estado 200)
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