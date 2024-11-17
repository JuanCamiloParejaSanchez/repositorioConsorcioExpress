document.addEventListener("DOMContentLoaded", () => {
    const tabla = document.getElementById("cuerpoTabla");
    const editarBtn = document.getElementById("editarBtn");
    const borrarBtn = document.getElementById("borrarBtn");
    const tableSizeSelect = document.getElementById("table_size");
    const filterInput = document.getElementById("tab_filter_text");
    const filterButton = document.getElementById("tab_filter_btn");
    const paginationContainer = document.querySelector(".index_buttons");
    const prevPageButton = document.getElementById("prevPage");
    const nextPageButton = document.getElementById("nextPage");
    const footerInfo = document.querySelector(".footer");

    let usuarios = [];
    let filteredUsuarios = [];
    let currentPage = 1;
    let pageSize = parseInt(tableSizeSelect.value);
    let totalPages = 0;

    // Inicializar modal de Bootstrap
    const modalElement = document.getElementById("exampleModal");
    const modal = new bootstrap.Modal(modalElement);

    // Botones dentro del modal
    const confirmButton = document.getElementById("btn-confirmar");
    const cancelButton = document.getElementById("btn-cancelar");

    // Función para obtener datos de la API
    function obtenerUsuarios() {
        //fetch(`http://www.consorcioexpress.somee.com/api/registrousuario`)
        fetch(`https://localhost:44314/api/registrousuario`)
            .then((response) => {
                console.log("Respuesta de la API:", response);
                if (!response.ok) {
                    throw new Error('Error en la respuesta de la API');
                }
                return response.json();
            })
            .then((data) => {
                console.log("Datos recibidos:", data);
                usuarios = data;
                applyFilterAndPagination();
            })
            .catch((error) => {
                console.error('Error al obtener datos de la API:', error);
                alert('Hubo un problema al obtener los datos. Por favor, intenta nuevamente.');
            });
    }
});