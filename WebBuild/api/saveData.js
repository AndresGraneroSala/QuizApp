// saveData.js
const fs = require('fs');

module.exports = (req, res) => {
    const data = req.body.data;
    fs.writeFileSync('data.txt', JSON.stringify(data));
    res.status(200).send('Datos guardados correctamente en data.txt');

};
