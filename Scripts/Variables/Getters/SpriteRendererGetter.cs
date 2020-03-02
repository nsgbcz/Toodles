using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public struct SpriteRendererGet : IGet<Color>, IGet<SpriteRenderer>
    {
        [SerializeField, Required, HideLabel]
        IGet<SpriteRenderer> value;
        Color IGet<Color>.Value => value.Value.color;
        SpriteRenderer IGet<SpriteRenderer>.Value => value.Value;
    }
}
