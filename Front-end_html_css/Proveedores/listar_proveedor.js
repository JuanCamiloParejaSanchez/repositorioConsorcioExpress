document.addEventListener("DOMContentLoaded", () => {
    const tabla = document.getElementById("cuerpoTabla");
  
    let inicioRegistros = 1;
    
    function obtenerUsuarios(inicioRegistros) {
      fetch(`http://www.consorcioexpress.somee.com/api/proveedor`)
      /* fetch(`https://localhost:44303/api/registrousuario`) */
         .then((response) => response.json())
         .then((data) => {
           tabla.innerHTML = ""; 
           data.forEach((proveedor) => {
             const row = document.createElement("tr");
             row.innerHTML = `
                    <td class="text-center" >${proveedor.IdProveedor}</td>
                    <td class="text-center" >${proveedor.NitProveedor}</td>
                    <td class="text-center" >${proveedor.NombreProveedor}</td>
                    <td class="text-center" >${proveedor.Direccion}</td>
                    <td class="text-center" >${proveedor.Telefono}</td>
                    <td class="text-center" >${proveedor.Correo}</td>                     
                    <td> <button id="editar"  value=${proveedor.IdProveedor} class="btn btn-warning" >editar</button> </td>
                    <td> <button id="borrar"  value=${proveedor.IdProveedor} class="btn btn-danger" >eliminar</button> </td>
                  `;

             tabla.appendChild(row);

          
             
           });
           console.log(data);
         })
         .catch((error) =>
           console.error("Error al obtener datos de la API:", error)
         );
     }
  
    obtenerUsuarios(inicioRegistros);
  
    tabla.addEventListener("click", (event) => {
      if (event.target.id == "borrar") {
        const confirmacion = confirm(
          "¿Estás seguro de que deseas eliminar este registro?"
        );
  
        if (confirmacion == true) {
          fetch(`http://www.consorcioexpress.somee.com/api/proveedor/${event.target.value}`, {
          /* fetch(`https://localhost:44303/api/registrousuario/${event.target.value}`, { */
            method: "DELETE",
          })
            .then((response) => {
              if (!response.ok) {
                throw new Error("Error al eliminar el proveedor");
              }
  
              event.target.closest("tr").remove();
            })
            .catch((error) => console.error("Error al eliminar proveedor:", error));
        }
      } else if (event.target.id == "editar") {
        window.location.href = "editar_proveedor.html?id=" + event.target.value; // Agrega el parámetro a la URL
      }
      
      
    });
  });