using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class CollisionExit2DExecute : Collision2DExecute
    {
        private void OnCollisionExit2D(Collision2D coll)
        {
            ExitAction(coll);
        }
    }
}
