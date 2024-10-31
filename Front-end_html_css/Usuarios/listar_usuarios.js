document.addEventListener("DOMContentLoaded", () => {
  const tabla = document.getElementById("cuerpoTabla");
  const editarBtn = document.getElementById("editarBtn");
  const borrarBtn = document.getElementById("borrarBtn");
  let filaSeleccionada = null; // Variable para almacenar la fila seleccionada

  function obtenerUsuarios() {
      fetch(`https://localhost:44314/api/registrousuario`)
          .then((response) => response.json())
          .then((data) => {
              tabla.innerHTML = ""; 
              data.forEach((usuario) => {
                  const row = document.createElement("tr");
                  row.innerHTML = `
                      <td class="text-center">${usuario.IdCodigoUsuario}</td>
                      <td class="text-center">${usuario.Documento}</td>
                      <td class="text-center">${usuario.Nombres}</td>
                      <td class="text-center">${usuario.Apellidos}</td>
                      <td class="text-center">${usuario.Telefono}</td>
                      <td class="text-center">${usuario.Correo}</td>
                      <td class="text-center">${usuario.Cargo}</td>
                      <td class="text-center">${usuario.Contrasena}</td>
                  `;
                  
                  // Agregar evento de clic a la fila
                  row.addEventListener("click", () => {
                      // Si ya hay una fila seleccionada, quitar la clase
                      if (filaSeleccionada) {
                          filaSeleccionada.classList.remove("selected");
                      }
                      // Agregar la clase a la fila actual y almacenar la referencia
                      filaSeleccionada = row;
                      filaSeleccionada.classList.add("selected");

                      // Habilitar los botones de editar y eliminar
                      editarBtn.disabled = false;
                      borrarBtn.disabled = false;

                      // Guardar el valor del ID para usar en las acciones
                      editarBtn.value = usuario.IdCodigoUsuario;
                      borrarBtn.value = usuario.IdCodigoUsuario;
                  });

                  tabla.appendChild(row);
              });
              console.log(data);
          })
          .catch((error) =>
              console.error("Error al obtener datos de la API:", error)
          );
  }

  obtenerUsuarios();

  borrarBtn.addEventListener("click", () => {
      const confirmacion = confirm("¿Estás seguro de que deseas eliminar este registro?");
      if (confirmacion === true && filaSeleccionada) {
          fetch(`https://localhost:44314/api/registrousuario/${borrarBtn.value}`, {
              method: "DELETE",
          })
          .then((response) => {
              if (!response.ok) {
                  throw new Error("Error al eliminar el usuario");
              }
              filaSeleccionada.remove(); // Eliminar la fila de la tabla
              filaSeleccionada = null; // Reiniciar la fila seleccionada
              editarBtn.disabled = true; // Deshabilitar botones
              borrarBtn.disabled = true;
          })
          .catch((error) => console.error("Error al eliminar usuario:", error));
      }
  });

  editarBtn.addEventListener("click", () => {
      if (filaSeleccionada) {
          window.location.href = "editar_usuario.html?id=" + editarBtn.value; // Redirigir a editar
      }
  });
});