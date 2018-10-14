const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const CleanWebpackPlugin = require("clean-webpack-plugin");
const webpack = require("webpack");
const distPath = path.resolve(__dirname, "../", "dist");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const StatsPlugin = require("stats-webpack-plugin")

// loader configuration for typescript
const compileTypeScript = {
    loader: "awesome-typescript-loader",
    options: {
        configFileName: "config/tsconfig.json",
        useCache: true,
        useBabel: true,
        cacheDirectory: ".cache",
        babelOptions: {
            babelrc: false,
            presets: [
                [
                    "@babel/preset-env", {
                        targets: {
                            browsers: ["last 2 versions"]
                        },
                        modules: false
                    }
                ]
            ]
        },
        babelCore: "@babel/core"
    }
};

// rule for compiling sass
const stylesRule = {
    test: /\.scss$/,
    use: [
        "style-loader",
        "css-loader",
        "sass-loader"
    ]
};

// rule to transpile regular javascript files
const regularJavaScriptRule = {
    test: /\.js$/,
    exclude: /(node_modules)/,
    use: [{
        loader: "babel-loader",
        options: {
            cacheDirectory: path.resolve(__dirname, "../", ".cache"),
            presets: ["@babel/preset-env"]
        }
    }]
};

// rule to compile most typescript files
const regularTypeScriptRule = {
    test: /\.tsx?$/,
    exclude: /(node_modules)/,
    use: [compileTypeScript]
};

// rule to copy web workers to the dist folder
const workerPlugin = new CopyWebpackPlugin([{
    from: "**/*.worker.js",
    to: "",
    ignore: "node_modules/**/*.*",
    context: "src"
}]);

// plugin for hot module replacement
// this enables changes in code to be immediately reflected in the browser
const hmrPlugin = new webpack.HotModuleReplacementPlugin();

// plugin to clean the output folder
const cleanPlugin = new CleanWebpackPlugin([distPath]);

// plugin to generate the index.html file
const htmlPlugin = new HtmlWebpackPlugin({
    title: "react-starter",
    template: "src/index.html"
});

// plugin to generate statistics 
const statsPlugin = new StatsPlugin("stats.json", {
    chunkModules: true,
    exclude: [/node_modules[\\\/]react/]
});

const common = {
    entry: [
        "./src/index.ts",
    ],
    output: {
        path: distPath,
        publicPath: "/",
    },
    resolve: {
        extensions: [".ts", ".tsx", ".js", ".jsx", ".scss"]
    },
    devtool: "inline-source-map",
    optimization: {
        splitChunks: {
            chunks: "async",
            minSize: 30000,
            maxSize: 0,
            minChunks: 1,
            maxAsyncRequests: 5,
            maxInitialRequests: 3,
            automaticNameDelimiter: "~",
            name: true,
            cacheGroups: {
                vendors: {
                    test: /[\\/]node_modules[\\/]/,
                    priority: -10
                },
                default: {
                    minChunks: 2,
                    priority: -20,
                    reuseExistingChunk: true
                }
            }
        }
    },
    plugins: [
        workerPlugin,
        cleanPlugin,
        htmlPlugin,
        statsPlugin
    ],
    module: {
        rules: [
            stylesRule, regularJavaScriptRule, regularTypeScriptRule
        ]
    }
}

module.exports = (env, argv) => {
    if (env.mode == "development") {
        return {
            name: "dev",
            mode: "development",
            entry: [...common.entry,
                "react-hot-loader/patch",
                "webpack-hot-middleware/client?path=/__webpack_hmr&timeout=20000&reload=true"
            ],
            plugins: [
                workerPlugin,
                hmrPlugin,
                cleanPlugin,
                htmlPlugin,
                statsPlugin
            ],
            ...common
        };
    } else if (env.mode == "production") {
        return {
            name: "prod",
            mode: "production",
            ...common
        };
    }
    return common;
}