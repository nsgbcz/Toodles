using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct CollisionGetter : IGet<GameObject>
    {
        [SerializeField, Required, HideLabel]
        IGet<Collision2D> value;
        GameObject IGet<GameObject>.Value => value.Value.gameObject;
    }
}
