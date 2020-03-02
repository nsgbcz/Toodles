using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public struct TransformGet : IGet<Vector2>, IGet<Transform>
    {
        [SerializeField]
        IGet<Transform> value;
        Vector2 IGet<Vector2>.Value => value.Value.position;
        Transform IGet<Transform>.Value => value.Value;
    }
    public struct CollisionGet : IGet<GameObject>
    {
        [SerializeField]
        IGet<Collision2D> value;
        GameObject IGet<GameObject>.Value => value.Value.gameObject;
    }
    public struct ColliderGet : IGet<GameObject>
    {
        [SerializeField]
        IGet<Collider2D> value;
        GameObject IGet<GameObject>.Value => value.Value.gameObject;
    }
    public struct SpriteRendererGet : IGet<Color>, IGet<SpriteRenderer>
    {
        [SerializeField]
        IGet<SpriteRenderer> value;
        Color IGet<Color>.Value => value.Value.color;
        SpriteRenderer IGet<SpriteRenderer>.Value => value.Value;
    }
}