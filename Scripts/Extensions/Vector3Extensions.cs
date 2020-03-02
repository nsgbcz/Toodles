using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 MoveTowards(this Vector3 A, Vector3 B, float step)
    {
        return new Vector3(Mathf.MoveTowards(A.x, B.x, step), Mathf.MoveTowards(A.y, B.y, step), Mathf.MoveTowards(A.z, B.z, step));
    }
}
