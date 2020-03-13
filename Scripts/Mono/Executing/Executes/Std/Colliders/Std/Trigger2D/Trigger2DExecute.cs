﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public class Trigger2DExecute : ConcretCollExecute<Collider2D, ITrigger2D>, ITrigger2D
    {
        public bool OnTrigger2D(Collider2D coll)
        {
            if (filter.Filter(coll))
            {
                if(execute != null && execute.OnTrigger2D(coll))
                {
                    Destroy(this);
                    return true;
                }
            }
            return false;
        }
    }
}