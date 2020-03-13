using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using Executes;
    using UnityEngine.EventSystems;

    public class Trigger2DAdapter : BaseAdapter<ITrigger2D>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.OnTrigger2D(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.OnTrigger2D(null);
        }

        bool IMouse.OnMouse()
        {
            return Value.OnTrigger2D(null);
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnTrigger2D(null);
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnTrigger2D(null);
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnTrigger2D(null);
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnTrigger2D(null);
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnTrigger2D(coll);
        }
    }

    public class TriggerEnter2DAdapter : BaseAdapter<ITriggerEnter2D>, ITrigger2D
    {
        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnTrigger2D(coll);
        }
    }
    public class TriggerStay2DAdapter : BaseAdapter<ITriggerStay2D>, ITrigger2D
    {
        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnTrigger2D(coll);
        }
    }
    public class TriggerExit2DAdapter : BaseAdapter<ITriggerExit2D>, ITrigger2D
    {
        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnTrigger2D(coll);
        }
    }
}
