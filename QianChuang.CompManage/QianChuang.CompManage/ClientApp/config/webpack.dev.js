/*
 * @Author: your name
 * @Date: 2021-02-10 09:43:15
 * @LastEditTime: 2021-02-11 15:04:23
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \ClientApp\config\webpack.dev.js
 */
const webpack = require("webpack");
const merge = require("webpack-merge");
const baseConfig = require("./webpack.base");
const { utils } = require("./webpack-util");
const HOST = "localhost";
const PORT = 8099;

module.exports = merge(baseConfig, {
  mode: "development",
  // devtool: 'inline-source-map',
  output: {
    path: utils.resolve("dist"),
    publicPath: "/",
    filename: "[name].js",
    library: "[name]_[hash]",
    chunkFilename: "[name].bundle.js"
  },
  devServer: {
    host: HOST,
    port: PORT,
    open: true,
    openPage: "index.html",
    proxy: {
      "/api": {
        target: "http://localhost:5000/",
        changeOrigin: true
      },
      "/_framework": {
        target: "http://localhost:5000/",
        changeOrigin: true
      }
    }
  },

  module: {
    rules: [
      {
        test: /\.css$/,
        use: ["vue-style-loader", "css-loader"]
      },
      {
        test: /\.styl(us)?$/,
        use: ["vue-style-loader", "css-loader", "stylus-loader"]
      },
      {
        test: /\.less$/,
        use: ["style-loader", "css-loader", "less-loader"] // 编译顺序从右往左
      }
      // {
      //     test: /\.s[ac]ss$/i,
      //     use: [
      //         // Creates `style` nodes from JS strings
      //         "style-loader",
      //         // Translates CSS into CommonJS
      //         "css-loader",
      //         // Compiles Sass to CSS
      //         "sass-loader"
      //     ]
      // }
    ]
  },

  plugins: [new webpack.HotModuleReplacementPlugin()]
});
