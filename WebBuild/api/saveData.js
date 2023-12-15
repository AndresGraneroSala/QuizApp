const fs = require('fs');
const path = require('path');

// Obtener el directorio actual
const directorioActual = __dirname;

// Obtener el directorio superior (padre)
const directorioSuperior = path.join(directorioActual, '..');

// Nombre del archivo que se creará en el directorio superior
const nombreArchivo = path.join(directorioSuperior, 'hola-mundo.txt');

// Contenido del archivo
const contenido = 'Hola, Mundo';

// Crear el archivo y escribir el contenido
fs.writeFile(nombreArchivo, contenido, (err) => {
  if (err) {
    console.error('Error al crear el archivo:', err);
  } else {
    console.log(`Archivo '${nombreArchivo}' creado con éxito.`);
  }
});
