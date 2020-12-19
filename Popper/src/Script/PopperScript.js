// @ts-check

import { PopperHelper } from "../PopperHelper/PopperHelper";

// @ts-ignore
window.Skclusive = {
    // @ts-ignore
    ...window.Skclusive,
    Material: {
        // @ts-ignore
        ...(window.Skclusive || {}).Material,
        Popper: {
            PopperHelper,
        },
    },
};
