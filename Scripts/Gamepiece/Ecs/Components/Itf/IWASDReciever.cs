using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input
{
    public interface IWASDReciever
    {
        void Apply(Vector2 vector);
    }
}
