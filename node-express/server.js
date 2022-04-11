// Create express app
var express = require("express")
var app = express()
app.use(express.static('Data'));
var db = require("./database.js")

// Server port
var HTTP_PORT = 8000 
// Start server
app.listen(HTTP_PORT, () => {
    console.log("Server running on port %PORT%".replace("%PORT%",HTTP_PORT))
});


// Endpoint specific video
app.get("/api/video/:id", (req, res, next) => {
    var sql = "select * from Video where id = ?"
    var params = [req.params.id]
    db.get(sql, params, (err, row) => {
        if (err) {
            res.status(400).json({ "[GetVideoId]error": err.message });
            return;
        }
        res.setHeader('Content-Type', 'video/mp4');
        res.status(200).sendFile(__dirname + "/Data/" + row.firm + "/" + row.model + "/Video/" + row.name)
    });
});


// Endpoint specific Image
app.get("/api/image/:id", (req, res, next) => {
    var sql = "select * from Image where id = ?"
    var params = [req.params.id]
    db.get(sql, params, (err, row) => {
        if (err) {
            res.status(400).json({ "[GetImageId]error": err.message });
            return;
        }
        res.status(200).sendFile(__dirname + "/Data/" + row.firm + "/" + row.model + "/Image/" + row.name)
    });
});


// Endpoint all videos
app.get("/api/video", (req, res, next) => {
    var sql = "select * from Video"
    var params = []
    db.all(sql, params, (err, rows) => {
        if (err) {
            res.status(400).json({ "error": err.message });
            return;
        }
        res.json({
            "message": "All videos:",
            "data": rows
        })
    });
});


// Endpoint all images
app.get("/api/image", (req, res, next) => {
    var sql = "select * from Image"
    var params = []
    db.all(sql, params, (err, rows) => {
        if (err) {
            res.status(400).json({ "error": err.message });
            return;
        }
        res.json({
            "message": "All images:",
            "data": rows
        })
    });
});


// Default response for any other request
app.use(function(req, res){
    res.status(404);
});