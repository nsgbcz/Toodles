using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Texture2DExtensions
{
    public static void Cut(this Texture2D first, Texture2D second)
    {
        var pixs = first.GetPixels();
        var pixsS = second.GetPixels();
        for (int i = 0; i < pixs.Length && i < pixsS.Length; i++)
        {
            pixs[i].a *= pixsS[i].a;
        }
        first.SetPixels(pixs);
        first.Apply();
    }
}
