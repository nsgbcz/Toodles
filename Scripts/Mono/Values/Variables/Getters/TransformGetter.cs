using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public struct TransformGetter : IGet<Vector2>, IGet<Transform>
    {
        [SerializeField, Required, HideLabel]
        IGet<Transform> value;
        Vector2 IGet<Vector2>.Value => value.Value.position;
        Transform IGet<Transform>.Value => value.Value;
    }
}
