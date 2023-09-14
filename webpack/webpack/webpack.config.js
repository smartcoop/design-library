const webpack = require("webpack");
const path = require("path");
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

let config = {
    entry: ['./src/index.js', './src/joelle.js', './src/meli.js'],
    output: {
        path: path.resolve(__dirname, "./public"),
        filename: "./bundle.js"
    },
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /node_modules/, //exclude les node modules pour n utiliser que babel
            use: {  loader: "babel-loader",  },

            test: /\.((c|sa|sc)ss)$/i,
            use: [MiniCssExtractPlugin.loader, 'css-loader', 'sass-loader', 'postcss-loader'],
        },],
    },
    plugins: [
        new MiniCssExtractPlugin()

    ],
}

module.exports = config;
