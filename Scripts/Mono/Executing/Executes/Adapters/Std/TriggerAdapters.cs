using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using Executes;
    using UnityEngine.EventSystems;

    public class TriggerAdapter : BaseAdapter<ITrigger>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.OnTrigger(null); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.OnTrigger(null);
        }

        bool IMouse.OnMouse()
        {
            return Value.OnTrigger(null);
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Value.OnTrigger(null);
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Value.OnTrigger(null);
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Value.OnTrigger(null);
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnTrigger(coll);
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Value.OnTrigger(null);
        }
    }

    public class TriggerEnterAdapter : BaseAdapter<ITriggerEnter>, ITrigger
    {
        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnTrigger(coll);
        }
    }
    public class TriggerStayAdapter : BaseAdapter<ITriggerStay>, ITrigger
    {
        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnTrigger(coll);
        }
    }
    public class TriggerExitAdapter : BaseAdapter<ITriggerExit>, ITrigger
    {
        bool ITrigger.OnTrigger(Collider coll)
        {
            return Value.OnTrigger(coll);
        }
    }
}
