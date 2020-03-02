using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers 
{
    public class TriggerExecute : ConcretCollExecute<Collider>, ITriggerEnter, ITriggerExit, ITriggerStay
    {
        public void EnterAction(Collider coll)
        {
            base.coll = coll;
            base.Action();
        }

        public void ExitAction(Collider coll)
        {
            base.coll = coll;
            base.Action();
        }

        public void StayAction(Collider coll)
        {
            base.coll = coll;
            base.Action();
        }
    }
}