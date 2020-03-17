using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Ecs
{
    public class TranslationComponent : ConcreteComponent<Vector3, TranslationComponent>
    {
        public static implicit operator Vector3(TranslationComponent data)
        {
            return data.Data;
        }
    }
}
