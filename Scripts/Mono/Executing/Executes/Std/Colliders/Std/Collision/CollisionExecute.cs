using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public class CollisionExecute : ConcretCollExecute<Collision, ICollision>, ICollision
    {
        public bool OnCollision(Collision coll)
        {
            if (filter.Filter(coll))
            {
                if (execute != null && execute.OnCollision(coll))
                {
                    Destroy(this);
                    return true;
                }
            }
            return false;
        }
    }
}