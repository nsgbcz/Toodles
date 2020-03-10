using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers 
{
    public class CollisionExecute : ConcretCollExecute<Collision>, ICollisionEnter, ICollisionExit, ICollisionStay
    {
        public void EnterAction(Collision coll)
        {
            this.coll = coll;
            base.Action();
        }
        public void ExitAction(Collision coll)
        {
            this.coll = coll;
            base.Action();
        }

        public void StayAction(Collision coll)
        {
            this.coll = coll;
            base.Action();
        }

    }
}