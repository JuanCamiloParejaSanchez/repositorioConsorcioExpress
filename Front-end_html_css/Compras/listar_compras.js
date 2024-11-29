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

    // Inicializar modal de Bootstrap
    const modalElement = document.getElementById("exampleModal");
    const modal = new bootstrap.Modal(modalElement);

    // Botones dentro del modal
    const confirmButton = document.getElementById("btn-confirmar");
    const cancelButton = document.getElementById("btn-cancelar");

    // Función para obtener datos de la API
    function obtenerCompras() {
        //fetch(`http://www.consorcioexpress.somee.com/api/compras`)
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
        const filterText = filterInput.value.toLowerCase().trim().replace(/\s+/g, ' '); // Normalizar la entrada del filtro
        filteredCompras = compras.filter(compra => {
            // Asegurarse de que todos los valores sean cadenas antes de aplicar el filtro
            return (
                compra.NumeroFactura?.toString().toLowerCase().includes(filterText) ||
                compra.ReferenciaProducto?.toString().toLowerCase().includes(filterText) ||
                compra.NombreArticulo?.toString().toLowerCase().includes(filterText) ||
                compra.Cantidad?.toString().toLowerCase().includes(filterText) ||  // Asegurarse de que es un número convertido a cadena
                compra.NombreProveedor?.toLowerCase().includes(filterText) ||
                compra.NitProveedor?.toString().toLowerCase().includes(filterText) ||
                compra.Direccion?.toLowerCase().includes(filterText) ||
                compra.Telefono?.toString().toLowerCase().includes(filterText) ||  // Asegurarse de que es un número convertido a cadena
                compra.Correo?.toLowerCase().includes(filterText) || 
                compra.Total?.toString().toLowerCase().includes(filterText) // Asegurarse de que es un número convertido a cadena
            );
        });
        totalPages = Math.ceil(filteredCompras.length / pageSize);
        displayPage(1);  // Mostrar la primera página después de aplicar filtro
        displayPaginationButtons();
    }
    
    // function applyFilterAndPagination() {
    //     const filterText = filterInput.value.toLowerCase();
    //     filteredCompras = compras.filter(compra =>
    //         compra.NumeroFactura.toString().includes(filterText) ||
    //         compra.ReferenciaProducto.toString().includes(filterText) ||
    //         compra.NombreArticulo.toLowerCase().includes(filterText) ||
    //         compra.Cantidad.toLowerCase().includes(filterText) ||
    //         compra.NombreProveedor.includes(filterText) ||
    //         compra.NitProveedor.toLowerCase().includes(filterText) ||
    //         compra.Direccion.toLowerCase().includes(filterText) ||
    //         compra.Telefono.includes(filterText) ||
    //         compra.Correo.toLowerCase().includes(filterText) ||            
    //         compra.Total.toLowerCase().includes(filterText)
            
    //     );
    //     totalPages = Math.ceil(filteredCompras.length / pageSize);
    //     displayPage(1);  // Mostrar la primera página después de aplicar filtro
    //     displayPaginationButtons();
    // }

    // Función para mostrar los datos en la página actual
    function displayPage(page) {
        currentPage = page;
        const startIndex = (currentPage - 1) * pageSize;
        const endIndex = Math.min(startIndex + pageSize, filteredCompras.length);
        const currentUsers = filteredCompras.slice(startIndex, endIndex);

        tabla.innerHTML = ""; // Limpiar tabla
        currentUsers.forEach(compra => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td class="text-center">${compra.NumeroFactura}</td>
                <td class="text-center">${compra.ReferenciaProducto}</td>
                <td class="text-center">${compra.NombreArticulo}</td>
                <td class="text-center">${compra.Cantidad}</td>
                <td class="text-center">${compra.NombreProveedor}</td>
                <td class="text-center">${compra.NitProveedor}</td>
                <td class="text-center">${compra.Direccion}</td>
                <td class="text-center">${compra.Telefono}</td>
                <td class="text-center">${compra.Correo}</td>                
                <td class="text-center">${compra.Total}</td>
            `;
            row.addEventListener("click", () => selectRow(row, compra));
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
    function selectRow(row, compra) {
        document.querySelectorAll("tr").forEach(tr => tr.classList.remove("selected"));
        row.classList.add("selected");
        editarBtn.disabled = false;
        borrarBtn.disabled = false;
        editarBtn.value = compra.NumeroFactura;
        borrarBtn.value = compra.NumeroFactura;
    }

    // Eventos para botones de edición y eliminación
    borrarBtn.addEventListener("click", () => {
        modal.show(); // Mostrar modal para confirmar
    });

    // Manejar confirmación en el modal
    confirmButton.addEventListener("click", () => {
        if (confirmButton) {
            modal.hide();
            //fetch(`http://www.consorcioexpress.somee.com/api/compras/${borrarBtn.value}`, {
            fetch(`https://localhost:44314/api/compras/${borrarBtn.value}`, {
                method: "DELETE",
            })
            .then((response) => {
                if (!response.ok) throw new Error("Error al eliminar la compra");
                obtenerCompras(); // Actualizar la lista después de eliminar
            })
            .catch((error) => console.error("Error al eliminar compra:", error));
        }
    });

    cancelButton.addEventListener("click", () => {
        modal.hide(); // Ocultar modal sin realizar cambios
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

    document.getElementById('btnGenerarPdf').addEventListener('click', () => {
        
        const botones = document.querySelector('.no-imprimir');
        botones.style.display = 'none';

        // Mostrar el encabezado antes de generar el PDF
        const encabezado = document.querySelector('.encabezado-pdf');
        encabezado.style.display = 'block';

        const elemento = document.getElementById('generarPdf');
        const opciones = {
          margin: 1,
          filename: 'tabla_compras.pdf',
          image: { type: 'pdf', quality: 0.98 },
          html2canvas: { scale: 2, logging: true, useCORS: true  },
          jsPDF: { unit: 'cm', format: 'a4', orientation: 'landscape' }
        };

        html2pdf()
            .set(opciones)
            .from(elemento)
            .toPdf()
            .get('pdf')
            .then(function(pdf) {
                // Ocultar el encabezado después de generar el PDF
                const newWindow = window.open(pdf.output("bloburl"), '_blank');
                encabezado.style.display = 'none';
                botones.style.display = 'block';                
            });                     
    });

    // Inicializar obtención de compras
    obtenerCompras();
});