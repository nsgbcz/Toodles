using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class CollisionExitExecute : CollisionExecute
    {
        private void OnCollisionExit(Collision coll)
        {
            ExitAction(coll);
        }
    }
}
