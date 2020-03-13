using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using Executes;
    using UnityEngine.EventSystems;

    public class Collision2DAdapter : BaseAdapter<ICollision2D>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.OnCollision2D(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.OnCollision2D(null);
        }

        bool IMouse.OnMouse()
        {
            return Value.OnCollision2D(null);
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnCollision2D(null);
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnCollision2D(null);
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnCollision2D(coll);
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnCollision2D(null);
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnCollision2D(null);
        }
    }

    public class CollisionEnter2DAdapter : BaseAdapter<ICollisionEnter2D>, ICollision2D
    {
        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnCollisionEnter2D(coll);
        }
    }
    public class CollisionStay2DAdapter : BaseAdapter<ICollisionStay2D>, ICollision2D
    {
        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnCollision2D(coll);
        }
    }
    public class CollisionExit2DAdapter : BaseAdapter<ICollisionExit2D>, ICollision2D
    {
        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnCollision2D(coll);
        }
    }
}
