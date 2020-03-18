using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    public struct MovementData
    {
        public Vector3     translation;
        public IGet<float> speed;
    }
}
