using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Toodles.Iterables
{
    #region delegates
    #region Acts
    public delegate void RefAction<T>(ref T value);
    public delegate void RefAction<T1, in T2>(ref T1 arg1, T2 arg2);
    public delegate void RefAction<T1, in T2, in T3>(ref T1 arg1, T2 arg2, T3 arg3);
    public delegate void RefAction<T1, in T2, in T3, in T4>(ref T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate void RefAction<T1, in T2, in T3, in T4, in T5>(ref T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    public delegate void Ref2Action<T1, T2>(ref T1 arg1, ref T2 arg2);
    public delegate void Ref2Action<T1, T2, in T3>(ref T1 arg1, ref T2 arg2, T3 arg3);
    public delegate void Ref2Action<T1, T2, in T3, in T4>(ref T1 arg1, ref T2 arg2, T3 arg3, T4 arg4);
    public delegate void Ref2Action<T1, T2, in T3, in T4, in T5>(ref T1 arg1, ref T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    public delegate void Ref3Action<T1, T2, T3>(ref T1 arg1, ref T2 arg2, ref T3 arg3);
    public delegate void Ref3Action<T1, T2, T3, in T4>(ref T1 arg1, ref T2 arg2, ref T3 arg3, T4 arg4);
    public delegate void Ref3Action<T1, T2, T3, in T4, in T5>(ref T1 arg1, ref T2 arg2, ref T3 arg3, T4 arg4, T5 arg5);

    public delegate void Ref4Action<T1, T2, T3, T4>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4);
    public delegate void Ref4Action<T1, T2, T3, T4, in T5>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4, T5 arg5);
    public delegate void Ref5Action<T1, T2, T3, T4, T5>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4, ref T5 arg5);
    #endregion
    #region Funcs
    public delegate TResult RefFunc<T, out TResult>(ref T value);
    public delegate TResult RefFunc<T1, in T2, out TResult>(ref T1 arg1, T2 arg2);
    public delegate TResult RefFunc<T1, in T2, in T3, out TResult>(ref T1 arg1, T2 arg2, T3 arg3);
    public delegate TResult RefFunc<T1, in T2, in T3, in T4, out TResult>(ref T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate TResult RefFunc<T1, in T2, in T3, in T4, in T5, out TResult>(ref T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    public delegate TResult Ref2Func<T1, T2, out TResult>(ref T1 arg1, ref T2 arg2);
    public delegate TResult Ref2Func<T1, T2, in T3, out TResult>(ref T1 arg1, ref T2 arg2, T3 arg3);
    public delegate TResult Ref2Func<T1, T2, in T3, in T4, out TResult>(ref T1 arg1, ref T2 arg2, T3 arg3, T4 arg4);
    public delegate TResult Ref2Func<T1, T2, in T3, in T4, in T5, out TResult>(ref T1 arg1, ref T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    public delegate TResult Ref3Func<T1, T2, T3, out TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3);
    public delegate TResult Ref3Func<T1, T2, T3, in T4, out TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3, T4 arg4);
    public delegate TResult Ref3Func<T1, T2, T3, in T4, in T5, out TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3, T4 arg4, T5 arg5);

    public delegate TResult Ref4Func<T1, T2, T3, T4, out TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4);
    public delegate TResult Ref4Func<T1, T2, T3, T4, in T5, out TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4, T5 arg5);

    public delegate TResult Ref5Func<T1, T2, T3, T4, T5, out TResult>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4, ref T5 arg5);
    #endregion
    #endregion

    #region Delegats
    #region Abstract
    public abstract class Delegate : IIteratable
    {
        //public object continuator = new object();
        public bool oneInvocation = true;
        /// <summary>
        /// Returns true if has been done, and you mustn't invoke this method again, else you can continue invoke this method
        /// </summary>
        public abstract bool Iterate();

        protected bool ActInvoke(object del)
        {
            if (del == null) return true;
            act();
            return oneInvocation;
        }
        protected bool ActInvoke<T>(ref List<T> dels)
        {
            //if (continuator == null) return true;
            for (int i = 0; i < dels.Count;)
            {
                if (dels[i] == null) dels.RemoveAt(i);
                else act(i++);
            }
            return oneInvocation || dels.Count <= 0;
        }

        protected bool FunInvoke(object del)
        {
            return del == null || fun() || oneInvocation;
        }

        protected bool FunInvoke<T>(ref List<T> dels)
        {
            //if (continuator == null) return true;
            for (int i = 0; i < dels.Count;)
            {
                if (dels[i] == null && fun(i)) dels.RemoveAt(i);
                else i++;
            }
            return oneInvocation || dels.Count <= 0;
        }

        protected virtual void act() { }
        protected virtual void act(int i) { }
        protected virtual bool fun() { return true; }
        protected virtual bool fun(int i) { return true; }
    }
    public abstract class Delegate<T> : Delegate//, IDrawGizmosSelected
    {
        public T value1 = default;

        /*public virtual void OnDrawGizmosSelected()
        {
            TryDraw(value1);
        }*/

        /*protected static void TryDraw<T>(T value)
        {
            var v = (value as IDrawGizmosSelected);
            if (v != null)
            {
                v.OnDrawGizmosSelected();
                return;
            }

            var ms = value as IEnumerable<IDrawGizmosSelected>;
            if (ms == null) return;
            foreach (var m in ms) m?.OnDrawGizmosSelected();
        }*/
    }
    public abstract class Delegate<T1, T2> : Delegate<T1>
    {
        public T2 value2 = default;
        /*public override void OnDrawGizmosSelected()
        {
            TryDraw(value2);
        }*/
    }
    public abstract class Delegate<T1, T2, T3> : Delegate<T1, T2>
    {
        public T3 value3 = default;
        /*public override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            TryDraw(value3);
        }*/
    }
    public abstract class Delegate<T1, T2, T3, T4> : Delegate<T1, T2, T3>
    {
        public T4 value4 = default;
        /*public override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            TryDraw(value4);
        }*/
    }
    public abstract class Delegate<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4>
    {
        public T5 value5 = default;
        /*public override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            TryDraw(value5);
        }*/
    }
    #endregion

    #region Simple
    public class Act : Delegate
    {
        public Action del;
        public Act() : base() { }
        public Act(IAction act)
        {
            del = act.Action;
        }
        public Act(IAction act, bool oneInvocation = true) : this(act)
        {
            this.oneInvocation = oneInvocation;
        }

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke();
    }
    public class Fun : Delegate
    {
        public Func<bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke();
    }

    public class Act<T> : Delegate<T>
    {
        public Action<T> del;

        public override bool Iterate() => ActInvoke(del);

        protected override void act() => del.Invoke(value1);
    }
    public class Fun<T> : Delegate<T>
    {
        public Func<T, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(value1);
    }
    public class ArrayAct<T> : Delegate<T>
    {
        public List<Action<T>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(value1);
    }
    public class ArrayFun<T> : Delegate<T>
    {
        public List<Func<T, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(value1);
    }

    public class Act<T1, T2> : Delegate<T1, T2>
    {
        public Action<T1, T2> del;

        public override bool Iterate() => ActInvoke(del);

        protected override void act() => del.Invoke(value1, value2);
    }
    public class Fun<T1, T2> : Delegate<T1, T2>
    {
        public Func<T1, T2, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(value1, value2);
    }
    public class ArrayAct<T1, T2> : Delegate<T1, T2>
    {
        public List<Action<T1, T2>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(value1, value2);
    }
    public class ArrayFun<T1, T2> : Delegate<T1, T2>
    {
        public List<Func<T1, T2, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(value1, value2);
    }

    public class Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public Action<T1, T2, T3> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(value1, value2, value3);
    }
    public class Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public Func<T1, T2, T3, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(value1, value2, value3);
    }
    public class ArrayAct<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<Action<T1, T2, T3>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(value1, value2, value3);
    }
    public class ArrayFun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<Func<T1, T2, T3, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(value1, value2, value3);
    }

    public class Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Action<T1, T2, T3, T4> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(value1, value2, value3, value4);
    }
    public class Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Func<T1, T2, T3, T4, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(value1, value2, value3, value4);
    }
    public class ArrayAct<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Action<T1, T2, T3, T4>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(value1, value2, value3, value4);
    }
    public class ArrayFun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Func<T1, T2, T3, T4, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(value1, value2, value3, value4);
    }

    public class Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Action<T1, T2, T3, T4, T5> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(value1, value2, value3, value4, value5);
    }
    public class Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Func<T1, T2, T3, T4, T5, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(value1, value2, value3, value4, value5);
    }
    public class ArrayAct<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Action<T1, T2, T3, T4, T5>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(value1, value2, value3, value4, value5);
    }
    public class ArrayFun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Func<T1, T2, T3, T4, T5, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(value1, value2, value3, value4, value5);
    }
    #endregion

    #region RefMyDelegats
    #region OneValue
    public class Ref1Act<T> : Delegate<T>
    {
        public RefAction<T> del;

        public override bool Iterate()
        {
            //if (continuator == null || del == null) return true;
            del.Invoke(ref value1);
            //act();
            return false;
        }
        // => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1);
    }
    public class Ref1Fun<T> : Delegate<T>
    {
        public RefFunc<T, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1);
    }
    public class ArrayRef1Act<T> : Delegate<T>
    {
        public List<RefAction<T>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1);
    }
    public class ArrayRef1Fun<T> : Delegate<T>
    {
        public List<RefFunc<T, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1);
    }
    #endregion
    #region TwoValue
    public class Ref1Act<T1, T2> : Delegate<T1, T2>
    {
        public RefAction<T1, T2> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, value2);
    }
    public class Ref2Act<T1, T2> : Delegate<T1, T2>
    {
        public Ref2Action<T1, T2> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2);
    }

    public class Ref1Fun<T1, T2> : Delegate<T1, T2>
    {
        public RefFunc<T1, T2, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, value2);
    }
    public class Ref2Fun<T1, T2> : Delegate<T1, T2>
    {
        public Ref2Func<T1, T2, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2);
    }

    public class ArrayRef1Act<T1, T2> : Delegate<T1, T2>
    {
        public List<RefAction<T1, T2>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, value2);
    }
    public class ArrayRef2Act<T1, T2> : Delegate<T1, T2>
    {
        public List<Ref2Action<T1, T2>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2);
    }

    public class ArrayRef1Fun<T1, T2> : Delegate<T1, T2>
    {
        public List<RefFunc<T1, T2, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, value2);
    }
    public class ArrayRef2Fun<T1, T2> : Delegate<T1, T2>
    {
        public List<Ref2Func<T1, T2, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2);
    }
    #endregion
    #region ThreeValue
    public class Ref1Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public RefAction<T1, T2, T3> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, value2, value3);
    }
    public class Ref2Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public Ref2Action<T1, T2, T3> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, value3);
    }
    public class Ref3Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public Ref3Action<T1, T2, T3> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, ref value3);
    }

    public class Ref1Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public RefFunc<T1, T2, T3, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, value2, value3);
    }
    public class Ref2Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public Ref2Func<T1, T2, T3, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, value3);
    }
    public class Ref3Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public Ref3Func<T1, T2, T3, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, ref value3);
    }

    public class ArrayRef1Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<RefAction<T1, T2, T3>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, value2, value3);
    }
    public class ArrayRef2Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<Ref2Action<T1, T2, T3>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, value3);
    }
    public class ArrayRef3Act<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<Ref3Action<T1, T2, T3>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, ref value3);
    }

    public class ArrayRef1Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<RefFunc<T1, T2, T3, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, value2, value3);
    }
    public class ArrayRef2Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<Ref2Func<T1, T2, T3, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, value3);
    }
    public class ArrayRef3Fun<T1, T2, T3> : Delegate<T1, T2, T3>
    {
        public List<Ref3Func<T1, T2, T3, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, ref value3);
    }
    #endregion
    #region FourValue
    public class Ref1Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public RefAction<T1, T2, T3, T4> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, value2, value3, value4);
    }
    public class Ref2Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Ref2Action<T1, T2, T3, T4> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, value3, value4);
    }
    public class Ref3Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Ref3Action<T1, T2, T3, T4> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, ref value3, value4);
    }
    public class Ref4Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Ref4Action<T1, T2, T3, T4> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, ref value3, ref value4);
    }

    public class Ref1Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public RefFunc<T1, T2, T3, T4, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, value2, value3, value4);
    }
    public class Ref2Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Ref2Func<T1, T2, T3, T4, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, value3, value4);
    }
    public class Ref3Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Ref3Func<T1, T2, T3, T4, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, ref value3, value4);
    }
    public class Ref4Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public Ref4Func<T1, T2, T3, T4, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, ref value3, ref value4);
    }

    public class ArrayRef1Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<RefAction<T1, T2, T3, T4>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, value2, value3, value4);
    }
    public class ArrayRef2Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Ref2Action<T1, T2, T3, T4>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, value3, value4);
    }
    public class ArrayRef3Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Ref3Action<T1, T2, T3, T4>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, value4);
    }
    public class ArrayRef4Act<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Ref4Action<T1, T2, T3, T4>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, ref value4);
    }

    public class ArrayRef1Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<RefFunc<T1, T2, T3, T4, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, value2, value3, value4);
    }
    public class ArrayRef2Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Ref2Func<T1, T2, T3, T4, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, value3, value4);
    }
    public class ArrayRef3Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Ref3Func<T1, T2, T3, T4, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, value4);
    }
    public class ArrayRef4Fun<T1, T2, T3, T4> : Delegate<T1, T2, T3, T4>
    {
        public List<Ref4Func<T1, T2, T3, T4, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, ref value4);
    }
    #endregion
    #region FiveValue
    public class Ref1Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public RefAction<T1, T2, T3, T4, T5> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, value2, value3, value4, value5);
    }
    public class Ref2Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref2Action<T1, T2, T3, T4, T5> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, value3, value4, value5);
    }
    public class Ref3Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref3Action<T1, T2, T3, T4, T5> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, ref value3, value4, value5);
    }
    public class Ref4Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref4Action<T1, T2, T3, T4, T5> del;

        public override bool Iterate() => ActInvoke(del);
        protected override void act() => del.Invoke(ref value1, ref value2, ref value3, ref value4, value5);
    }
    public class Ref5Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref5Action<T1, T2, T3, T4, T5> del;

        public override bool Iterate() => ActInvoke(del);

        protected override void act() => del.Invoke(ref value1, ref value2, ref value3, ref value4, ref value5);
    }

    public class Ref1Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public RefFunc<T1, T2, T3, T4, T5, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, value2, value3, value4, value5);
    }
    public class Ref2Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref2Func<T1, T2, T3, T4, T5, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, value3, value4, value5);
    }
    public class Ref3Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref3Func<T1, T2, T3, T4, T5, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, ref value3, value4, value5);
    }
    public class Ref4Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref4Func<T1, T2, T3, T4, T5, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, ref value3, ref value4, value5);
    }
    public class Ref5Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public Ref5Func<T1, T2, T3, T4, T5, bool> del;

        public override bool Iterate() => FunInvoke(del);
        protected override bool fun() => del.Invoke(ref value1, ref value2, ref value3, ref value4, ref value5);
    }

    public class ArrayRef1Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<RefAction<T1, T2, T3, T4, T5>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, value2, value3, value4, value5);
    }
    public class ArrayRef2Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref2Action<T1, T2, T3, T4, T5>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, value3, value4, value5);
    }
    public class ArrayRef3Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref3Action<T1, T2, T3, T4, T5>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, value4, value5);
    }
    public class ArrayRef4Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref4Action<T1, T2, T3, T4, T5>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, ref value4, value5);
    }
    public class ArrayRef5Act<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref5Action<T1, T2, T3, T4, T5>> dels;

        public override bool Iterate() => ActInvoke(ref dels);
        protected override void act(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, ref value4, ref value5);
    }

    public class ArrayRef1Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<RefFunc<T1, T2, T3, T4, T5, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, value2, value3, value4, value5);
    }
    public class ArrayRef2Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref2Func<T1, T2, T3, T4, T5, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, value3, value4, value5);
    }
    public class ArrayRef3Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref3Func<T1, T2, T3, T4, T5, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, value4, value5);
    }
    public class ArrayRef4Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref4Func<T1, T2, T3, T4, T5, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, ref value4, value5);
    }
    public class ArrayRef5Fun<T1, T2, T3, T4, T5> : Delegate<T1, T2, T3, T4, T5>
    {
        public List<Ref5Func<T1, T2, T3, T4, T5, bool>> dels;

        public override bool Iterate() => FunInvoke(ref dels);
        protected override bool fun(int i) => dels[i].Invoke(ref value1, ref value2, ref value3, ref value4, ref value5);
    }
    #endregion
    #endregion
    #endregion

}
