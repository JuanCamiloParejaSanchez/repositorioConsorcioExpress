//BOTONES DEL MENU PRINCIPAL Y BARRA DE NAVEGACION

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