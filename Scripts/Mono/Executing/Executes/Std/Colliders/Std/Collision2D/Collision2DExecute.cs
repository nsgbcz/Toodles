using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

namespace Toodles.Mono 
{
    public class Collision2DExecute : ConcretCollExecute<Collision2D, ICollision2D>, ICollision2D
    {
        public bool OnCollision2D(Collision2D coll)
        {
            if (filter.Filter(coll))
            {
                if (execute != null && execute.OnCollision2D(coll))
                {
                    Destroy(this);
                    return true;
                }
            }
            return false;
        }
    }
}