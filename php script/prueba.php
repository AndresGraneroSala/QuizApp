<?php
// Nombre del archivo a crear
$nombreArchivo = 'archivo_prueba.txt';

// Contenido del archivo
$contenido = '¡Este es un archivo de prueba creado con PHP!';

// Intenta abrir o crear el archivo en modo escritura
if ($archivo = fopen($nombreArchivo, 'w')) {
    // Escribe el contenido en el archivo
    fwrite($archivo, $contenido);
    
    // Cierra el archivo
    fclose($archivo);
    
    echo "El archivo $nombreArchivo se ha creado con éxito.";
} else {
    echo "No se pudo abrir o crear el archivo $nombreArchivo.";
}
?>