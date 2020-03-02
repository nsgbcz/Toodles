using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class CollisionEnterExecute : CollisionExecute
    {
        private void OnCollisionEnter(Collision coll)
        {
            EnterAction(coll);
        }
    }
}
