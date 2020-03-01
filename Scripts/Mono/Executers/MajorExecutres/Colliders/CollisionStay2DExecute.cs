using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class CollisionStay2DExecute : Collision2DExecute
    {
        private void OnCollisionStay2D(Collision2D coll)
        {
            StayAction(coll);
        }
    }
}
