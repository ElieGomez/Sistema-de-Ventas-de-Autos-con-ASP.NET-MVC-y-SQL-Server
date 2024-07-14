function cargarImagen() {
    // Obtener el valor de la URL ingresada en la caja de texto
    var url = document.getElementById("urlInput").value;

    // Obtener la etiqueta de imagen del contenedor
    var img = document.getElementById("imagenContainer");

    // Asignar la URL como atributo de origen a la etiqueta de imagen
    img.src = url;
}
