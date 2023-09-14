const webpack = require("webpack");
const path = require("path");

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

            test: /\.(css)$/,
            use: ['style-loader', 'css-loader'],
        },],
    },
}

module.exports = config;
