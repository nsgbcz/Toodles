using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece
{
    public interface ITransformComponent
    {
        Transform Transform { get; set; }
    }
}
