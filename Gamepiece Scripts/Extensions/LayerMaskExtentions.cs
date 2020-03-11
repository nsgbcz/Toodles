using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Extentions
{
    public static int ToLayerIndex(this LayerMask mask)
    {
        int lay = mask.value;
        int pow = 0;
        while (lay > 1)
        {
            lay = lay >> 1;
            if (++pow > 32) break;
        }
        return pow;
    }
}
