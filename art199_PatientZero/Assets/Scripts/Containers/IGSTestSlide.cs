using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSTestSlide : MonoBehaviour, Dropable {
    public bool hasWater = false;   // Step 1: add a drop of water

    // This can only take water and only if there isn't already a drop of water
    public bool TakeLiquid(Liquid liquid) {
        if (!hasWater && liquid is Water) {
            hasWater = true;
            return true;
        }

        return false;
    }
}
