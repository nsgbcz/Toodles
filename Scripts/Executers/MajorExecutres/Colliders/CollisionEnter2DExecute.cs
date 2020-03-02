using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class CollisionEnter2DExecute : Collision2DExecute
    {
        private void OnCollisionEnter2D(Collision2D coll)
        {
            EnterAction(coll);
        }
    }
}
