#if UNITY_EDITOR
using UnityEngine;
using Toodles.Iterates;
using System.Linq;
using Sirenix.OdinInspector;
using System;
using System.Reflection;

namespace Toodles.Executes
{
    using Adapters;
    using Iterates;
    internal struct FactoryData : IEquatable<FactoryData>
    {
        [SerializeField]
        ExecuteType ExecuteType;
        [SerializeField, ShowIf("IsMain")]
        MainType MainType;
        [SerializeField, ShowIf("IsColl")]
        CollType CollType;
        [SerializeField, ShowIf("IsColl")]
        SubCollType SubCollType;
        [SerializeField, ShowIf("IsMouse")]
        MouseType MouseType;
        [SerializeField, ShowIf("IsPointer")]
        PointerType PointerType;

        bool IsNothing   { get => ExecuteType == ExecuteType.Nothing; }
        bool IsMain      { get => ExecuteType == ExecuteType.Main; }
        bool IsColl      { get => ExecuteType == ExecuteType.Coll; }
        bool IsMouse     { get => ExecuteType == ExecuteType.Mouse; }
        bool IsPointer   { get => ExecuteType == ExecuteType.Pointer; }

        public bool Equals(FactoryData target)
        {
            return (ExecuteType == target.ExecuteType) &&
                  ((IsNothing) ||
                   (IsMain && MainType == target.MainType) ||
                   (IsColl && CollType == target.CollType && SubCollType == target.SubCollType) ||
                   (IsMouse && MouseType == target.MouseType) ||
                   (IsPointer && PointerType == target.PointerType));
        }

        public Type BuildType()
        {
            switch (ExecuteType)
            {
                case ExecuteType.Nothing:
                    return typeof(Execute);
                case ExecuteType.Main:
                    switch (MainType)
                    {
                        case MainType.Awake:
                            return typeof(AwakeExecute);
                        case MainType.Enable:
                            return typeof(EnableExecute);
                        case MainType.Start:
                            return typeof(StartExecute);
                        case MainType.FixedUpdate:
                            return typeof(FixedUpdateExecute);
                        case MainType.Update:
                            return typeof(UpdateExecute);
                        case MainType.LateUpdate:
                            return typeof(LateUpdateExecute);
                        case MainType.Disable:
                            return typeof(DisableExecute);
                        case MainType.Destroy:
                            return typeof(DestroyExecute);
                    }
                    break;
                case ExecuteType.Coll:
                    switch (CollType)
                    {
                        case CollType.Trigger:
                            switch (SubCollType)
                            {
                                case SubCollType.Enter:
                                    return typeof(TriggerEnterExecute);
                                case SubCollType.Stay:
                                    return typeof(TriggerStayExecute);
                                case SubCollType.Exit:
                                    return typeof(TriggerExitExecute);
                            }
                            break;
                        case CollType.Collision:
                            switch (SubCollType)
                            {
                                case SubCollType.Enter:
                                    return typeof(CollisionEnterExecute);
                                case SubCollType.Stay:
                                    return typeof(CollisionStayExecute);
                                case SubCollType.Exit:
                                    return typeof(CollisionExitExecute);
                            }
                            break;
                        case CollType.Trigger2D:
                            switch (SubCollType)
                            {
                                case SubCollType.Enter:
                                    return typeof(TriggerEnter2DExecute);
                                case SubCollType.Stay:
                                    return typeof(TriggerStay2DExecute);
                                case SubCollType.Exit:
                                    return typeof(TriggerExit2DExecute);
                            }
                            break;
                        case CollType.Collision2D:
                            switch (SubCollType)
                            {
                                case SubCollType.Enter:
                                    return typeof(CollisionEnter2DExecute);
                                case SubCollType.Stay:
                                    return typeof(CollisionStay2DExecute);
                                case SubCollType.Exit:
                                    return typeof(CollisionExit2DExecute);
                            }
                            break;
                    }
                    break;
                case ExecuteType.Mouse:
                    switch (MouseType)
                    {
                        case MouseType.Down:
                            return typeof(MouseDownExecute);
                        case MouseType.Drag:
                            return typeof(MouseDragExecute);
                        case MouseType.Up:
                            return typeof(MouseUpExecute);
                        case MouseType.Enter:
                            return typeof(MouseEnterExecute);
                        case MouseType.Over:
                            return typeof(MouseOverExecute);
                        case MouseType.Exit:
                            return typeof(MouseExitExecute);
                        case MouseType.Click:
                            return typeof(MouseUpAsButtonExecute);
                    }
                    break;
                case ExecuteType.Pointer:
                    switch (PointerType)
                    {
                        case PointerType.Down:
                            return typeof(PointerDownExecute);
                        case PointerType.Drag:
                            return typeof(PointerDragExecute);
                        case PointerType.Up:
                            return typeof(PointerUpExecute);
                        case PointerType.Enter:
                            return typeof(PointerEnterExecute);
                        case PointerType.Exit:
                            return typeof(PointerExitExecute);
                        case PointerType.Click:
                            return typeof(PointerClickExecute);
                    }
                    break;
            }
            return null;
        }

        public void InjectData<T>(BaseExecute target, ConcreteExecute<T> old)
        {
            if(IsMain || IsMouse || IsNothing)
            {
                Inject<IIteratable>();
            }
            else if (IsColl)
            {
                switch (CollType)
                {
                    case CollType.Trigger:
                        Inject<ITrigger>();
                        break;
                    case CollType.Collision:
                        Inject<ICollision>();
                        break;
                    case CollType.Trigger2D:
                        Inject<ITrigger2D>();
                        break;
                    case CollType.Collision2D:
                        Inject<ICollision2D>();
                        break;
                }
            }
            else if(IsPointer)
            {
                Inject<IPointer>();
            }

            target.Description = old.Description;
            target.ExecuteType = this;
            target._executeType = this;

            void Inject<TI>() where TI : class
            {
                object execute = old.execute;
                TI potential = null;
                while (true)
                {
                    if (execute is TI) potential = (TI)execute;
                    if (execute is IExecuteAdapter)
                    {
                        var fieldInfo = execute.GetType().GetField("Value");
                        object value = fieldInfo.GetValue(execute);

                        if (value == null) break;
                        if (value.GetType().GetInterfaces().Contains(typeof(IExecuteAdapter)))
                        {
                            execute = value;
                            continue;
                        }
                        else if (fieldInfo.FieldType == typeof(TI))
                        {
                            potential = (TI)value;
                        }
                    }
                    break;
                }
                if (potential != null)
                    (target as ConcreteExecute<TI>).execute = potential;
                else
                {
                    (target as ConcreteExecute<TI>).execute = (TI)GetAdapter();
                }
            }

            IExecuteAdapter GetAdapter()
            {
                IExecuteAdapter adapter = null;

                if (old.execute is IExecuteAdapter) adapter = old.execute as IExecuteAdapter;
                else if (old.execute is IIteratable)
                    adapter = new IteratableAdapter() { Value = old.execute as IIteratable };
                else if (old.execute is ICollision)
                    adapter = new CollisionAdapter() { Value = old.execute as ICollision };
                else if (old.execute is ICollision2D)
                    adapter = new Collision2DAdapter() { Value = old.execute as ICollision2D };
                else if (old.execute is ITrigger)
                    adapter = new TriggerAdapter() { Value = old.execute as ITrigger };
                else if (old.execute is ITrigger2D)
                    adapter = new Trigger2DAdapter() { Value = old.execute as ITrigger2D };
                else if (old.execute is IPointer)
                    adapter = new PointerAdapter()   { Value = old.execute as IPointer };

                return adapter;
            }
        }
    }

    internal static class ExecuteFactory
    {
        public static void Replace<T>(FactoryData data, ConcreteExecute<T> old)
        {
            BaseExecute target = (BaseExecute)old.gameObject.AddComponent(data.BuildType());

            data.InjectData(target, old);

            Terminate(target, old);
        }
        public static void Build(GameObject gameObject, FactoryData data)
        {
            gameObject.AddComponent(data.BuildType());
        }

        static void Terminate<T>(T target, T old) where T : Component
        {
            if (old == null) return;

            var comps = old.gameObject.GetComponents<Component>();

            for (int i = comps.Length - 1; comps[i] != old; i--)
            {
                UnityEditorInternal.ComponentUtility.MoveComponentUp(target);
            }

            GameObject.DestroyImmediate(old, true);
        }
    }
    internal enum ExecuteType
    {
        Nothing, Main, Coll, Mouse, Pointer
    }
    internal enum MainType
    {
        Awake, Enable, Start, FixedUpdate, Update, LateUpdate, Disable, Destroy
    }

    internal enum CollType
    {
        Trigger, Collision, Trigger2D, Collision2D
    }
    internal enum SubCollType
    {
        Enter, Stay, Exit
    }

    internal enum MouseType
    {
        Down, Drag, Up, Enter, Over, Exit, Click
    }

    internal enum PointerType
    {
        Down, Drag, Up, Enter, Exit, Click
    }
}
#endif
