const express = require("express");

const app = express();

const PORT = 3000;

app.get("/player", (req, res) => {

    const playerData = {
        name: "Hero",
        hp: 100
    };

    res.json(playerData);
});

app.listen(PORT, () => {
    console.log("Server Start");
});