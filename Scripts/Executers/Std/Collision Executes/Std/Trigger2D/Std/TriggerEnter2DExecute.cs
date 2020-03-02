using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class TriggerEnter2DExecute : Trigger2DExecute
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            EnterAction(coll);
        }
    }
}
