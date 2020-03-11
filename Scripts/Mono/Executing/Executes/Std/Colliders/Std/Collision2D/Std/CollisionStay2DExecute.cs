using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionStay2DExecute : Collision2DExecute, ICollisionStay2D
    {
        private void OnCollisionStay2D(Collision2D coll)
        {
            Action(coll);
        }
    }
}
