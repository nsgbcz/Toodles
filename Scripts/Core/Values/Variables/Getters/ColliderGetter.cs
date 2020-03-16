﻿using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct ColliderGet : IGet<GameObject>
    {
        [SerializeField, Required, HideLabel]
        IGet<Collider2D> value;
        GameObject IGet<GameObject>.Value => value.Value.gameObject;
    }
}
