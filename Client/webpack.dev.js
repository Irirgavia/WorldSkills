const merge = require('webpack-merge');
const common = require('./webpack.common.js');

module.exports = merge(common, {
    mode: 'development',
    devtool: 'inline-source-map',

    devServer: {  // configuration for webpack-dev-server
        contentBase: './',  //source of static assets
        port: 7700,
        historyApiFallback: true,
    }
});