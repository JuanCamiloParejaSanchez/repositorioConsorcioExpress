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

    let compras = [];
    let filteredCompras = [];
    let currentPage = 1;
    let pageSize = parseInt(tableSizeSelect.value);
    let totalPages = 0;

    // Función para obtener datos de la API
    function obtenerCompras() {
        fetch(`https://localhost:44314/api/compras`)
            .then((response) => {
                console.log("Respuesta de la API:", response);
                if (!response.ok) {
                    throw new Error('Error en la respuesta de la API');
                }
                return response.json();
            })
            .then((data) => {
                console.log("Datos recibidos:", data);
                compras = data;
                applyFilterAndPagination();
            })
            .catch((error) => {
                console.error('Error al obtener datos de la API:', error);
                alert('Hubo un problema al obtener los datos. Por favor, intenta nuevamente.');
            });
    }

    // Función para filtrar y paginar los datos
    function applyFilterAndPagination() {
        const filterText = filterInput.value.toLowerCase();
        filteredCompras = compras.filter(compras =>
            compras.NumeroFactura.toString().includes(filterText) ||
            compras.NombreProveedor.includes(filterText) ||
            compras.NitProveedor.toLowerCase().includes(filterText) ||
            compras.Dirección.toLowerCase().includes(filterText) ||
            compras.Telefono.includes(filterText) ||
            compras.Correo.toLowerCase().includes(filterText) ||
            compras.NombreArticulo.toLowerCase().includes(filterText) ||
            compras.Cantidad.toLowerCase().includes(filterText) ||
            compras.Total.toLowerCase().includes(filterText) ||
            compras.Fecha.toLowerCase().includes(filterText)
        );
        totalPages = Math.ceil(filteredCompras.length / pageSize);
        displayPage(1);  // Mostrar la primera página después de aplicar filtro
        displayPaginationButtons();
    }

    // Función para mostrar los datos en la página actual
    function displayPage(page) {
        currentPage = page;
        const startIndex = (currentPage - 1) * pageSize;
        const endIndex = Math.min(startIndex + pageSize, filteredCompras.length);
        const currentUsers = filteredCompras.slice(startIndex, endIndex);

        tabla.innerHTML = ""; // Limpiar tabla
        currentUsers.forEach(compras => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td class="text-center">${compras.NumeroFactura}</td>
                <td class="text-center">${compras.NombreProveedor}</td>
                <td class="text-center">${compras.NitProveedor}</td>
                <td class="text-center">${compras.Dirección}</td>
                <td class="text-center">${compras.Telefono}</td>
                <td class="text-center">${compras.Correo}</td>
                <td class="text-center">${compras.NombreArticulo}</td>
                <td class="text-center">${compras.Cantidad}</td>
                <td class="text-center">${compras.Total}</td>
                <td class="text-center">${compras.Fecha}</td>
            `;
            row.addEventListener("click", () => selectRow(row, compras));
            tabla.appendChild(row);
        });

        // Mostrar información en el pie de página
        footerInfo.textContent = `Mostrando ${startIndex + 1} a ${endIndex} de ${filteredCompras.length} entradas`;
    }

    // Función para mostrar los botones de paginación
    function displayPaginationButtons() {
        paginationContainer.innerHTML = "";
        const prevButton = document.createElement("button");
        prevButton.textContent = "Anterior";
        prevButton.onclick = () => displayPage(currentPage > 1 ? currentPage - 1 : 1);
        paginationContainer.appendChild(prevButton);

        for (let i = 1; i <= totalPages; i++) {
            const pageButton = document.createElement("button");
            pageButton.textContent = i;
            pageButton.classList.toggle("active", i === currentPage);
            pageButton.onclick = () => displayPage(i);
            paginationContainer.appendChild(pageButton);
        }
        
        const nextButton = document.createElement("button");
        nextButton.textContent = "Siguiente";
        nextButton.onclick = () => displayPage(currentPage < totalPages ? currentPage + 1 : totalPages);
        paginationContainer.appendChild(nextButton);
    }

    // Función para seleccionar una fila y habilitar botones
    function selectRow(row, compras) {
        document.querySelectorAll("tr").forEach(tr => tr.classList.remove("selected"));
        row.classList.add("selected");
        editarBtn.disabled = false;
        borrarBtn.disabled = false;
        editarBtn.value = compras.NumeroFactura;
        borrarBtn.value = compras.NumeroFactura;
    }

    // Eventos para botones de edición y eliminación
    borrarBtn.addEventListener("click", () => {
        const confirmacion = confirm("¿Estás seguro de que deseas eliminar este registro?");
        if (confirmacion) {
            fetch(`https://localhost:44314/api/compras/${borrarBtn.value}`, {
                method: "DELETE",
            })
            .then((response) => {
                if (!response.ok) throw new Error("Error al eliminar la compra");
                obtenerUsuarios(); // Actualizar la lista después de eliminar
            })
            .catch((error) => console.error("Error al eliminar compra:", error));
        }
    });

    editarBtn.addEventListener("click", () => {
        if (editarBtn.value) {
            window.location.href = `editar_compras.html?id=${editarBtn.value}`;
        }
    });

    // Eventos de filtro y cambio de tamaño de página
    filterButton.addEventListener("click", applyFilterAndPagination);
    tableSizeSelect.addEventListener("change", () => {
        pageSize = parseInt(tableSizeSelect.value);
        applyFilterAndPagination();
    });

    // Inicializar obtención de usuarios
    obtenerCompras();
});