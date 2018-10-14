const tsfmt = require("typescript-formatter");
const resolve = require("path").resolve;
const find = require("find");

find.file(/\.[tj]sx?$/, resolve(__dirname, "../src"), function(files) {
    tsfmt
        .processFiles(files, {
            dryRun: true,
            replace: true,
            verify: false,
            tsconfig: "../config/tsconfig.json",
            tslint: "../tslint.json",
            editorconfig: "../.editorconfig",
            tsfmt: true,
            verbose: true
        })
        .then(result =>{
            
        }); 
})

