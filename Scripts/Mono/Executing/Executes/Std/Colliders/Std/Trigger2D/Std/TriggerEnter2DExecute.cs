using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerEnter2DExecute : Trigger2DExecute, ITriggerEnter2D
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            Action(coll);
        }
    }
}
