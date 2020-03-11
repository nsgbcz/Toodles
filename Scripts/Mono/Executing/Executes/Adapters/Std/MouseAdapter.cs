using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Iterates;
    using UnityEngine.EventSystems;

    public class MouseAdapter : BaseAdapter<IMouse>, IExecute, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D, IExecuteAdapter
    {
        void IAction.Action()
        {
            Value.Action(); ;
        }

        bool IIteratable.Iterate()
        {
            return Value.Action();
        }

        bool IMouse.Action()
        {
            return Value.Action();
        }

        bool IPointer.Action(PointerEventData data)
        {
            return Value.Action();
        }

        bool ICollision.Action(Collision coll)
        {
            return Value.Action();
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            return Value.Action();
        }

        bool ITrigger.Action(Collider coll)
        {
            return Value.Action();
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            return Value.Action();
        }
    }
}
