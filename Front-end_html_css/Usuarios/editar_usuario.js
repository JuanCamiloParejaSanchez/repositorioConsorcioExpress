document.addEventListener("DOMContentLoaded", () => {
  const btnEditar = document.getElementById("editar");

  const urlParams = new URLSearchParams(window.location.search);
  const id = urlParams.get("id");

  const documento = document.getElementById("documento");
  const nombres = document.getElementById("nombres");
  const apellidos = document.getElementById("apellidos");
  const telefono = document.getElementById("telefono");
  const correo = document.getElementById("correo");
  const cargo = document.getElementById("cargo");
  const contrasena = document.getElementById("contrasena");

  // Inicializar modal de Bootstrap
  const modalElement = document.getElementById("exampleModal");
  const modal = new bootstrap.Modal(modalElement);

  // Botones dentro del modal
  const confirmButton = document.getElementById("btn-confirmar");
  const cancelButton = document.getElementById("btn-cancelar");

  // Obtener datos del usuario
  fetch("http://www.consorcioexpress.somee.com/api/registrousuario/" + id)
    .then((response) => response.json())
    .then((data) => {
      data.forEach((usuario) => {
        documento.value = usuario.Documento;
        nombres.value = usuario.Nombres;
        apellidos.value = usuario.Apellidos;
        telefono.value = usuario.Telefono;
        correo.value = usuario.Correo;
        cargo.value = usuario.Cargo;
        contrasena.value = usuario.contrasena.substring(0, 10);
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
      idCodigoUsuario: id,
      documento: documento.value,
      nombres: nombres.value,
      apellidos: apellidos.value,
      telefono: telefono.value,
      correo: correo.value,
      cargo: cargo.value,
      contrasena: contrasena.value
    };

    fetch("http://www.consorcioexpress.somee.com/api/registrousuario/", {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        if (response.ok) {          
          modal.hide();
          window.location.href = "listar_usuarios.html";
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