using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers 
{
    public class Trigger2DExecute : ConcretCollExecute<Collider2D>, ITriggerEnter2D, ITriggerExit2D, ITriggerStay2D
    {
        public void EnterAction(Collider2D coll)
        {
            base.coll = coll;
            base.Action();
        }
        public void ExitAction(Collider2D coll)
        {
            base.coll = coll;
            base.Action();
        }

        public void StayAction(Collider2D coll)
        {
            base.coll = coll;
            base.Action();
        }
    }
}