var sqlite3 = require('sqlite3').verbose()

const DBSOURCE = "db.sqlite"

let db = new sqlite3.Database(DBSOURCE, (err) => {
    if (err) {
      // Cannot open database
      console.error(err.message)
      throw err
    }else{
        console.log('Connected to the SQLite database.')
        db.run(`CREATE TABLE Video (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            firm text,
            model text,
            name text UNIQUE,
            CONSTRAINT name_unique UNIQUE (name)
            )`,
            (err) => {
                if (err) {
                    // Error or Table already created
                    console.error(err.message)
                    var del = 'Drop Table Video'
                    db.run(del)
                    console.log('Table rimossa')
                } else {
                    // Table just created, creating some rows
                    var insert = 'INSERT INTO Video (id, firm, model, name) VALUES (?,?,?,?)'
                    db.run(insert, [1, "Brother", "MFC-7360N", "Accensione.mp4"])
                    db.run(insert, [2, "Brother", "MFC-7360N", "AperturaCarrello.mp4"])
                    db.run(insert, [3, "Brother", "MFC-7360N", "AperturaCoperchio.mp4"])
                    db.run(insert, [4, "Brother", "MFC-7360N", "AperturaSportello.mp4"])
                    db.run(insert, [5, "Brother", "MFC-7360N", "ChiusuraCarrello.mp4"])
                    db.run(insert, [6, "Brother", "MFC-7360N", "ChiusuraSportello.mp4"])
                    db.run(insert, [7, "Brother", "MFC-7360N", "EstrazioneCarta.mp4"])
                    db.run(insert, [8, "Brother", "MFC-7360N", "InserimentoCarta.mp4"])
                    db.run(insert, [9, "Brother", "MFC-7360N", "InserimentoUSB.mp4"])
                }
            });
        db.run(`CREATE TABLE Image (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            firm text,
            model text,
            name text UNIQUE,
            CONSTRAINT name_unique UNIQUE (name)
            )`,
        (err) => {
            if (err) {
                // Error or Table already created
                console.error(err.message)
                var del = 'Drop Table Image'
                db.run(del)
                console.log('Table rimossa')
            } else {
                // Table just created, creating some rows
                var insert = 'INSERT INTO Image (id, firm, model, name) VALUES (?,?,?,?)'
                db.run(insert, [1, "Brother", "MFC-7360N", "PulsanteCopia.jpg"])
                db.run(insert, [2, "Brother", "MFC-7360N", "PulsanteFax.jpg"])
                db.run(insert, [3, "Brother", "MFC-7360N", "PulsanteScan.jpg"])
                db.run(insert, [4, "Brother", "MFC-7360N", "Pulsanti.jpg"])
                db.run(insert, [5, "Brother", "MFC-7360N", "TastierinoNumerico.jpg"])
            }
        });
    }
});


module.exports = db