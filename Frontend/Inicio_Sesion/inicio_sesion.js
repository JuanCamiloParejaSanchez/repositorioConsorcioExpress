document.getElementById("btnIngresar").addEventListener("click", function(event) {
    event.preventDefault();

    const documento = document.getElementById("documento").value;
    const contrasena = document.getElementById("contrasena").value;

    // const data = {
    //     documento: documento,
    //     contrasena: contrasena
    // }

    if(documento==="71387351" && contrasena==="1234")
    {
        alert("Inicio de sesión exitoso. Bienvenido.");
         window.location.href="../Menu_Principal/menu_principal.html";
    } else {
        alert("Error: Usuario incorrecto.");
    };
});

//     fetch(`https://localhost:44314/api/registrousuario`, {
//         method: "POST",
//         headers: {
//             "Content-Type": "application/json"
//         },
//         body: JSON.stringify(data)
//     })
//     .then(response => response.json())
//     .then(data => {
//         if (data.success) {
//             window.location.href = "../Menu_Principal/menu_principal.html"; // Redirige si el login es exitoso
//         } else {
//             document.getElementById("lblError").textContent = "Usuario o contraseña incorrectos.";
//         }
//     })
//     .catch(error => {
//         console.error("Error en la solicitud:", error);
//         document.getElementById("mensaje").textContent = "Ocurrió un error. Intente de nuevo.";
//     });
// });



// document.getElementById("btnIngresar").addEventListener("click", function () {
//     const documento = document.getElementById("documento").value;
//     const contrasena = document.getElementById("contrasena").value;

//     if (!documento || !contrasena) {
//         mostrarMensaje("Por favor, ingresa tu documento y contraseña.", false);
//         return;
//     }

//     try {
//         //const response = fetch('https://www.consorcioexpress.somee.com/api/registrousuario/validar', {
//         const response = fetch('https://localhost:44314/api/registrousuario', {
//             method: 'POST',
//             headers: {
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify({ Documento: documento, Contrasena: contrasena })
//         });

//         const data = response.json();
//         if (data.exito) {
//             mostrarMensaje(data.mensaje, true);
//             // Redirigir a otra página si es necesario
//             window.location.href = "../Menu_Principal/menu_principal.html";
//         } else {
//             mostrarMensaje(data.mensaje, false);
//         }
//     } catch (error) {
//         mostrarMensaje("Error al conectarse al servidor.", false);
//     }
// });

// function mostrarMensaje(mensaje, exito) {
//     const mensajeElemento = document.getElementById("mensaje");
//     mensajeElemento.textContent = mensaje;
//     mensajeElemento.style.color = exito ? "green" : "red";
// }