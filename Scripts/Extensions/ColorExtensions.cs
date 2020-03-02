using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions 
{
    public static Color MoveToward(this Color current, Color target, float step)
    {
        return new Color(Mathf.MoveTowards(current.r, target.r, step),
                   Mathf.MoveTowards(current.g, target.g, step),
                   Mathf.MoveTowards(current.b, target.b, step),
                   Mathf.MoveTowards(current.a, target.a, step));
    }
}
