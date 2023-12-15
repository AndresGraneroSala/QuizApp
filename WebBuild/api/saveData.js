const fs = require('fs');

// Nombre del archivo que se creará
const nombreArchivo = 'hola-mundo.txt';

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
