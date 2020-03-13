﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using Executes;
    using UnityEngine.EventSystems;

    public class CollisionAdapter : BaseAdapter<ICollision>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.Action(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.Action(null);
        }

        bool IMouse.Action()
        {
            return Value.Action(null);
        }

        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action(null);
        }

        bool ICollision.Action(Collision coll)
        {
            return Value.Action(coll);
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            return Value.Action(null);
        }

        bool ITrigger.Action(Collider coll)
        {
            return Value.Action(null);
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            return Value.Action(null);
        }
    }

    public class CollisionEnterAdapter : BaseAdapter<ICollisionEnter>, ICollision
    {
        bool ICollision.Action(Collision coll)
        {
            return Value.Action(coll);
        }
    }
    public class CollisionStayAdapter : BaseAdapter<ICollisionStay>, ICollision
    {
        bool ICollision.Action(Collision coll)
        {
            return Value.Action(coll);
        }
    }
    public class CollisionExitAdapter : BaseAdapter<ICollisionExit>, ICollision
    {
        bool ICollision.Action(Collision coll)
        {
            return Value.Action(coll);
        }
    }
}