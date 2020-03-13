using System.Collections;
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
            Value.OnCollision(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.OnCollision(null);
        }

        bool IMouse.OnMouse()
        {
            return Value.OnCollision(null);
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnCollision(null);
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnCollision(coll);
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnCollision(null);
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnCollision(null);
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnCollision(null);
        }
    }

    public class CollisionEnterAdapter : BaseAdapter<ICollisionEnter>, ICollision
    {
        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnCollisionEnter(coll);
        }
    }
    public class CollisionStayAdapter : BaseAdapter<ICollisionStay>, ICollision
    {
        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnCollision(coll);
        }
    }
    public class CollisionExitAdapter : BaseAdapter<ICollisionExit>, ICollision
    {
        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnCollision(coll);
        }
    }
}
