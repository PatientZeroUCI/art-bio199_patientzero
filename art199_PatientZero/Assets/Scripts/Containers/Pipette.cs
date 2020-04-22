using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A pipette can draw liquid from a container and drop it on dropable things
public class Pipette : MonoBehaviour {
    public Liquid contents = null;

    // Draw liquid from a container
    // Fails if the container is empty of the pipette already contains liquid
    public bool DrawLiquid(LiquidContainer container) {
        if (contents != null) {
            return false;
        }

        if (container.contents == null) {
            return false;
        }

        contents = container.contents;
        return true;
    }

    // Drops the contents onto something
    // Fails if the pipette is empty
    // If TakeLiquid returns true, it empties the pipette
    public bool DropLiquid(Dropable dropable) {
        if (contents == null) {
            return false;
        }

        if (dropable.TakeLiquid(contents)) {
            contents = null;
            return true;
        }

        return false;
    }
}
