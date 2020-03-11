using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes.Adapters
{
    using Iterates;
    using UnityEngine.EventSystems;

    public class IteratableAdapter : BaseAdapter<IIteratable>, IExecute, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D, IExecuteAdapter
    {
        void IAction.Action()
        {
            Value.Iterate();
        }

        bool IIteratable.Iterate()
        {
            return Value.Iterate();
        }

        bool IMouse.Action()
        {
            return Value.Iterate();
        }

        bool IPointer.Action(PointerEventData data)
        {
            return Value.Iterate();
        }

        bool ICollision.Action(Collision coll)
        {
            return Value.Iterate();
        }

        bool ICollision2D.Action(Collision2D coll)
        {
            return Value.Iterate();
        }

        bool ITrigger.Action(Collider coll)
        {
            return Value.Iterate();
        }

        bool ITrigger2D.Action(Collider2D coll)
        {
            return Value.Iterate();
        }
    }
}
