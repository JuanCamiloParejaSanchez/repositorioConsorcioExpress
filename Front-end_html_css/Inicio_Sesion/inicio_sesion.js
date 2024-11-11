document.getElementById("btnIngresar").addEventListener("click", function(event) {
    event.preventDefault();

    const documento = document.getElementById("documento").value;
    const contrasena = document.getElementById("contrasena").value;

    const data = {
        documento: documento,
        contrasena: contrasena
    }

    fetch(`https://http://www.consorcioexpress.somee.com/api/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            window.location.href = "../Menu_Principal/menu_principal.html"; // Redirige si el login es exitoso
        } else {
            document.getElementById("lblError").textContent = "Usuario o contraseña incorrectos.";
        }
    })
    .catch(error => {
        console.error("Error en la solicitud:", error);
        document.getElementById("mensaje").textContent = "Ocurrió un error. Intente de nuevo.";
    });
});
