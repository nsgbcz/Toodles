using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Toodles.Executers 
{
    public class Collision2DExecute : ConcretCollExecute<Collision2D>, ICollisionEnter2D, ICollisionExit2D, ICollisionStay2D
    {
        public void EnterAction(Collision2D coll)
        {
            base.coll = coll;
            base.Action();
        }

        public void ExitAction(Collision2D coll)
        {
            base.coll = coll;
            base.Action();
        }

        public void StayAction(Collision2D coll)
        {
            base.coll = coll;
            base.Action();
        }
    }
}