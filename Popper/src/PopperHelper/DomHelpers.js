// @ts-check

function onScript(func, ...args) {
    // @ts-ignore
    const { DomHelpers } = window.Skclusive.Script;
    return DomHelpers[func].apply(null, args);
}

export function generateId(...args) {
    return onScript("generateId", ...args);
}
