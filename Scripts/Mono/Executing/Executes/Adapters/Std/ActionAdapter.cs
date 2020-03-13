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

        bool IMouse.OnMouse()
        {
            Value.Action();
            return true;
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            Value.Action();
            return true;
        }

        bool ICollision.OnCollision(Collision coll)
        {
            Value.Action();
            return true;
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            Value.Action();
            return true;
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            Value.Action();
            return true;
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            Value.Action();
            return true;
        }
    }

    public class AwakeAdapter : BaseAdapter<IAwake>, IAction
    {
        void IAction.Action()
        {
            Value.OnAwake();
        }
    }
    public class StartAdapter : BaseAdapter<IStart>, IAction
    {
        void IAction.Action()
        {
            Value.OnStart();
        }
    }
    public class EnableAdapter : BaseAdapter<IEnable>, IAction
    {
        void IAction.Action()
        {
            Value.OnEnable();
        }
    }
    public class UpdateAdapter : BaseAdapter<IUpdate>, IAction
    {
        void IAction.Action()
        {
            Value.OnUpdate();
        }
    }
    public class FixedUpdateAdapter : BaseAdapter<IFixedUpdate>, IAction
    {
        void IAction.Action()
        {
            Value.OnFixedUpdate();
        }
    }
    public class LateUpdateAdapter : BaseAdapter<ILateUpdate>, IAction
    {
        void IAction.Action()
        {
            Value.OnLateUpdate();
        }
    }
    public class DisableAdapter : BaseAdapter<IDisable>, IAction
    {
        void IAction.Action()
        {
            Value.OnDisable();
        }
    }
    public class DestroyAdapter : BaseAdapter<IDestroy>, IAction
    {
        void IAction.Action()
        {
            Value.OnDestroy();
        }
    }
}
