document.addEventListener("DOMContentLoaded", () => {

  const registrar = document.getElementById("registrar");

  registrar.addEventListener("click", (e) => {
  e.preventDefault();

    const idCodigoUsuario = document.getElementById("idCodigoUsuario").value;
    const documento = document.getElementById("documento").value;
    const nombres = document.getElementById("nombres").value;
    const apellidos = document.getElementById("apellidos").value;
    const telefono = document.getElementById("telefono").value;
    const correo = document.getElementById("correo").value;    
    const cargo = document.getElementById("cargo").value;
    const contrasena = document.getElementById("contrasena").value;

    const data = {
        idCodigoUsuario: idCodigoUsuario,
        documento: documento,
        nombres: nombres,
        apellidos: apellidos,
        telefono: telefono,
        correo: correo,
        cargo: cargo,
        contrasena: contrasena
    }

    /* fetch(`http://www.consorcioexpress.somee.com/api/registrousuario`, { */
    fetch(`https://localhost:44314/api/registrousuario/`, {
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

          window.location.href = "listar_usuarios.html"

        } else {
          console.error("Error al enviar la solicitud:", response.status);
        }
      })
      .catch((error) => {
        console.error("Error al enviar la solicitud:", error);
      });
  });
});