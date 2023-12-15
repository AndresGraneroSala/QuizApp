// saveData.js
const fs = require('fs');

module.exports = (req, res) => {
  try {
    const data = req.body.data;
    fs.writeFileSync('ruta/del/archivo/data.txt', JSON.stringify(data));
    res.status(200).send('Datos guardados correctamente en data.txt');
  } catch (error) {
    console.error(error);
    res.status(500).send('Error al guardar los datos');
  }
};
