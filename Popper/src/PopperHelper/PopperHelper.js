// @ts-check

import { createPopper } from "../node_modules/@popperjs/core/dist/esm/popper.js";

import { generateId } from "./DomHelpers";

export class PopperHelper {
    static cache = {};

    static construct(containerRef, popperRef, options) {
        const id = generateId();

        const popper = createPopper(containerRef, popperRef, options);

        PopperHelper.cache[id] = {
            id,
            popper,
        };

        setTimeout(() => popper.update());

        return id;
    }

    static dispose(id) {
        const record = PopperHelper.cache[id];
        if (record && record.popper) {
            record.popper.destroy();
        }
        delete PopperHelper.cache[id];
    }

    static update(id) {
        const record = PopperHelper.cache[id];
        if (record && record.popper) {
            record.popper.update();
        }
    }
}
