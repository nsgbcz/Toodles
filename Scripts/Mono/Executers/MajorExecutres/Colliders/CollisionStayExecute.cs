using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class CollisionStayExecute : CollisionExecute
    {
        private void OnCollisionStay(Collision coll)
        {
            StayAction(coll);
        }
    }
}
