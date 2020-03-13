using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes.Adapters
{
    using Actions;
    using UnityEngine.EventSystems;

    public class ActionAdapter : BaseAdapter<IAction>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        void IAction.Action()
        {
            Value.Action(); ;
        }

        bool IIteratable.Iterate()
        {
            Value.Action();
            return true;
        }

        bool IMouse.Action()
        {
            Value.Action();
            return true;
        }

        bool IPointer.Action(PointerEventData data)
        {
            Value.Action();
            return true;
        }

        bool ICollision.Action(Collision coll)
        {
            Value.Action();
            return true;
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            Value.Action();
            return true;
        }

        bool ITrigger.Action(Collider coll)
        {
            Value.Action();
            return true;
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            Value.Action();
            return true;
        }
    }
}
