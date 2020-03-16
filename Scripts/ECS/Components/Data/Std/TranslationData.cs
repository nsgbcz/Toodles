using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Ecs
{
    public class TranslationData : ConcreteData<Vector3, TranslationData>
    {
        public static implicit operator Vector3(TranslationData data)
        {
            return data.Value;
        }
    }
}
