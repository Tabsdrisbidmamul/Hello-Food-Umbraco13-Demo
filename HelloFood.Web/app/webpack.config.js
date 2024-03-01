import * as path from 'path';
import { fileURLToPath } from 'url';
const __dirname = path.dirname(fileURLToPath(import.meta.url));

export default {
    entry: [__dirname + '/src/ts/main.ts', __dirname + '/src/sass/main.scss'],
    output: {
        filename: 'main.frontend.min.js',
        path: path.resolve(__dirname, '../wwwroot/dist'),
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js'],
    },
    devtool: 'source-map',
    experiments: {
        topLevelAwait: true,
    },
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.tsx?|\.js$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
            {
                test: /\.s[ac]ss$/i,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            outputPath: '/',
                            name: '[name].frontend.min.css',
                        },
                    },
                    // Compiles Sass to CSS
                    'sass-loader',
                ],
            },
        ],
    },
};