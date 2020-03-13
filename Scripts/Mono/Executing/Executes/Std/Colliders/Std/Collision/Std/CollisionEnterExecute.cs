using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionEnterExecute : CollisionExecute, ICollisionEnter
    {
        private void OnCollisionEnter(Collision coll)
        {
            OnCollision(coll);
        }

        bool ICollisionEnter.OnCollisionEnter(Collision coll)
        {
            return OnCollision(coll);
        }
    }
}
