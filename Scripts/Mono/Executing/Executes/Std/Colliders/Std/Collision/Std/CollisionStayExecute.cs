﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionStayExecute : CollisionExecute, ICollisionStay
    {
        private void OnCollisionStay(Collision coll)
        {
            Action(coll);
        }
    }
}
