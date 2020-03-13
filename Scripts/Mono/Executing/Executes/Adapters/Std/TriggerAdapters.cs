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
            return Value.Action(null);
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            return Value.Action(null);
        }

        bool ITrigger.Action(Collider coll)
        {
            return Value.Action(coll);
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            return Value.Action(null);
        }
    }

    public class TriggerEnterAdapter : BaseAdapter<ITriggerEnter>, ITrigger
    {
        bool ITrigger.Action(Collider coll)
        {
            return Value.Action(coll);
        }
    }
    public class TriggerStayAdapter : BaseAdapter<ITriggerStay>, ITrigger
    {
        bool ITrigger.Action(Collider coll)
        {
            return Value.Action(coll);
        }
    }
    public class TriggerExitAdapter : BaseAdapter<ITriggerExit>, ITrigger
    {
        bool ITrigger.Action(Collider coll)
        {
            return Value.Action(coll);
        }
    }
}
