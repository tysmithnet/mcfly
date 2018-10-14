var http = require("http");
var express = require("express");
var path = require("path")

require("console-stamp")(console, "HH:MM:ss.l");

const app = express();
app.use(express.static("../dist"))
app.use(express.json());
app.use(express.urlencoded());
app.use(require("morgan")("short"));

(() => {
    // setup webpack middleware and hot module replacement
    const webpack = require("webpack");
    const webpackConfig = require("../config/webpack.config.js")({mode: "development"});
    const compiler = webpack(webpackConfig);

    app.use(require("webpack-dev-middleware")(compiler, {
        logLevel: "warn",
        publicPath: webpackConfig.output.publicPath,
    }));

    app.use(require("webpack-hot-middleware")(compiler, {
        log: console.log,
        path: "/__webpack_hmr",
        heartbeat: 10 * 1000
    }));
})();

app.post("/api/auth", (req, res) => {
    if(!req.body.id || !req.body.password) {
        res.status(400);
        res.end();
    }
    // IMPENTRABLE SECURITY
    if(req.body.id == "admin" && req.body.password == "password") {
        res.json({
            id: "1",
            name: "Admin",
            permissions: [
                "ADMIN"
            ]});
        res.status(200);
    }
    else {
        res.status(401);
    }
    res.end();
});

app.get(/admin/, function (req, res) {
    res.sendFile(path.resolve(__dirname, "../dist/index.html"));
});

app.post(/metrics/, function (req, res) {
    console.log(req.param("data"));
});

if (require.main === module) {
    var server = http.createServer(app);
    server.listen(process.env.PORT || 8080, function () {
        console.log("Listening on %j", server.address());
    });
}