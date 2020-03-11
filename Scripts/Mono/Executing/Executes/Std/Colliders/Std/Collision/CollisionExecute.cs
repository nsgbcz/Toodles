using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public class CollisionExecute : ConcretCollExecute<Collision, ICollision>, ICollision
    {
        public bool Action(Collision coll)
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