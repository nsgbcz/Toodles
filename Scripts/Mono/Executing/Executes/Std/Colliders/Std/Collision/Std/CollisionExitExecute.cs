using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionExitExecute : CollisionExecute, ICollisionExit
    {
        private void OnCollisionExit(Collision coll)
        {
            Action(coll);
        }
    }
}
