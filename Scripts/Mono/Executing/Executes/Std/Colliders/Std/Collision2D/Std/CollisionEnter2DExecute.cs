using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionEnter2DExecute : Collision2DExecute, ICollisionEnter2D
    {
        private void OnCollisionEnter2D(Collision2D coll)
        {
            OnCollision2D(coll);
        }

        bool ICollisionEnter2D.OnCollisionEnter2D(Collision2D coll)
        {
            return OnCollision2D(coll);
        }
    }
}
