document.addEventListener("DOMContentLoaded", () => {

    const registrar = document.getElementById("registrar");
  
    registrar.addEventListener("click", (e) => {
    e.preventDefault();
  
      const NumeroFactura = document.getElementById("NumeroFactura").value;
      const NombreProveedor = document.getElementById("NombreProveedor").value;
      const NitProveedor = document.getElementById("NitProveedor").value;
      const Dirección = document.getElementById("Dirección").value;
      const Telefono = document.getElementById("Telefono").value;
      const Correo = document.getElementById("Correo").value;    
      const NombreArticulo = document.getElementById("NombreArticulo").value;
      const Cantidad = document.getElementById("Cantidad").value;
      const Total = document.getElementById("Total").value;
      const Fecha = document.getElementById("Fecha").value;
  
      const data = {
        NumeroFactura: NumeroFactura,
        NombreProveedor: NombreProveedor,
        NitProveedor: NitProveedor,
        Dirección: Dirección,
        Telefono: Telefono,
        Correo: Correo,
        NombreArticulo: NombreArticulo,
        Cantidad: Cantidad,
        Total: Total,
        Fecha: Fecha
      }
  
      /* fetch(`http://www.consorcioexpress.somee.com/api/compras`, { */
      fetch(`https://localhost:44314/api/compras/`, {
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
  
            window.location.href = "listar_compras.js"
  
          } else {
            console.error("Error al enviar la solicitud:", response.status);
          }
        })
        .catch((error) => {
          console.error("Error al enviar la solicitud:", error);
        });
    });
  });