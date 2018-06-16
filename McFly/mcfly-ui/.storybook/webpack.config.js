const path = require("path");
module.exports = (baseConfig, env, config) => {
  config.output.globalObject = "this";
  console.dir(config);
  config.module.rules.push({
    test: /\.(s*)css$/,
    use: ['style-loader', 'css-loader', 'sass-loader']
  });
  config.module.rules.push({
    test: /\.(ts|tsx)$/,
    loader: require.resolve("awesome-typescript-loader")
  }, {
    enforce: "pre",
    test: /\.js$/,
    loader: "source-map-loader"
  });
  config.resolve.extensions.push(".ts", ".tsx");
  return config;
};