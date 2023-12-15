// saveData.js
module.exports = (req, res) => {
    const fs = require('fs');
    const data = req.body.data; // Puedes enviar los datos desde Unity en el cuerpo de la solicitud POST
    fs.writeFileSync('ruta/del/archivo/datos.txt', JSON.stringify(data));
    res.status(200).send('Datos guardados correctamente');
  };
  