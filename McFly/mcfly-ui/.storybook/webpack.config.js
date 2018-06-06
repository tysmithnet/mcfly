const path = require("path");
module.exports = (baseConfig, env, config) => {
  config.output.globalObject = "this";
  console.dir(config);
  config.module.rules.push({
    test: /\.(s*)css$/,
    use: ['style-loader', 'css-loader', 'sass-loader']
  }, {
    test: /\.webworker\.(ts|tsx)$/,
    loader: require.resolve("worker-loader")
  });
  config.module.rules.push({
    test: /\.(ts|tsx)$/,
    loader: require.resolve("awesome-typescript-loader")
  });
  config.resolve.extensions.push(".ts", ".tsx");
  return config;
};