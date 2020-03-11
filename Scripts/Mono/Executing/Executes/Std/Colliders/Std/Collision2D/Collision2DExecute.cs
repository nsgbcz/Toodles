using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public class Collision2DExecute : ConcretCollExecute<Collision2D, ICollision2D>, ICollision2D
    {
        public bool Action(Collision2D coll)
        {
            if (filter.Filter(coll))
            {
                if (execute != null && execute.Action(coll))
                {
                    Destroy(this);
                    return true;
                }
            }
            return false;
        }
    }
}