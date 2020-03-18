using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Ecs;
    public class TransformComponent : ConcreteComponent<Transform, TransformComponent>, ITransformComponent
    {
        public Transform Transform { get => Data; set => Data = value; }
    }
}
