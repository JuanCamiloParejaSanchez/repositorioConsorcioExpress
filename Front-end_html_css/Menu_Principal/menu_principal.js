//BOTONES DEL MENU PRINCIPAL Y BARRA DE NAVEGACION

window.onload = function () {
    fetch("https://localhost:44314/Views/ObtenerNombreUsuario.aspx")
        .then(response => response.json())
        .then(data => {

            // Actualizar el texto del botón con el nombre del usuario
            const btnUsuario = document.getElementById("btnUsuario");
            btnUsuario.innerText = data.nombreUsuario || "Invitado";
        })
        .catch(error => {
            console.error("Error al cargar el nombre del usuario:", error);
        });
};


function mostrarIframe(id) {
    // Oculta todos los iframes
    const iframes = document.querySelectorAll('.iFrame');
    iframes.forEach(iframe => iframe.style.display = 'none');

    // Muestra el iframe correspondiente al id recibido
    const iframe = document.getElementById(id);
    if (iframe) {
        iframe.style.display = 'block';
    }
}
mostrarIframe();

document.addEventListener("DOMContentLoaded", ()=>{
    const cerrarSesion = document.getElementById("botonCerrarSesion");
    cerrarSesion.addEventListener("click", ()=>{
        window.location.href="../Index/index.html"
    });
});