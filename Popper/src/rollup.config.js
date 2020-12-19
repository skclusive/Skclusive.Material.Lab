import resolve from "rollup-plugin-node-resolve";
import commonjs from "rollup-plugin-commonjs";
import babel from "rollup-plugin-babel";
import { terser } from "rollup-plugin-terser";

process.env.INCLUDE_DEPS = "true";
process.env.NODE_ENV = "production";

module.exports = {
    input: "Script/PopperScript.js",
    output: {
        file: "artifacts/PopperScript.js",
        format: "iife",
    },
    plugins: [
        resolve(),
        commonjs(), // so Rollup can convert dependencies to an ES module
        babel({
            runtimeHelpers: true,
            extensions: [".js", ".jsx", ".es6", ".es", ".mjs"],
            plugins: ["@babel/plugin-proposal-class-properties"],
        }),
        terser(),
    ],
};
