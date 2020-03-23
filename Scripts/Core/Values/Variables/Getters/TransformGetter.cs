using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct TransformGetter : IGet<Transform>, IGet<Vector2>, IGet<Vector3>
    {
        [SerializeField, Required, HideLabel]
        IGet<Transform> value;
        Transform IGet<Transform>.Value => value.Value;
        Vector2 IGet<Vector2>.Value => value.Value.position;
        Vector3 IGet<Vector3>.Value => value.Value.position;
    }
}
