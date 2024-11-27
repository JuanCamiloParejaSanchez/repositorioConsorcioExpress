document.addEventListener("DOMContentLoaded", () => {
  const registrar = document.getElementById("registrarUsuario");
  const modalElement = document.getElementById("exampleModal");

  // Inicializar modal con Bootstrap
  const modal = new bootstrap.Modal(modalElement);

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
    };

    fetch(`https://localhost:44314/api/registrousuario`, {
    //fetch(`http://www.consorcioexpress.somee.com/api/registrousuario`, {
      method: "POST",
      headers: {
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
            window.location.href = "https://localhost:44314/Views/Login.aspx";
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