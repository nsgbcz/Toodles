using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionEnterExecute : CollisionExecute, ICollisionEnter
    {
        private void OnCollisionEnter(Collision coll)
        {
            Action(coll);
        }
    }
}
