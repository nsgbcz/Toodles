using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BP.Delegates
{
    #region Interfaces
    //public interface IDrawGizmosSelected
    //{
    //    void OnDrawGizmosSelected();
    //}
    public interface IListContainer
    {
        IContainer GetContainer { get; }
    }

    interface IBuilder
    {
        IInvoke<bool> GetAct();
    }
    //interface IBuilder<T>
    //{
    //    ISetValue<T> GetAct();
    //}
    public interface IContainer : IInvoke<bool>//, IDrawGizmosSelected
    {
        void SetAction();

        void Add(IInvoke<bool> act);

        bool IsValide { get; }
    }
    #endregion

    #region IContainers
    public class ListContainer : IContainer
    {
        public List<IInvoke<bool>> Meths = new List<IInvoke<bool>>();

        [Button("Set Action")]
        void IContainer.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IContainer) ((IContainer)Meths[i]).SetAction();
            }
        }

        public bool Invoke()
        {
            for (int i = 0, j = 0; i < Meths.Count; j++)
            {
                if (Meths[i] == null || Meths[i].Invoke()) Meths.RemoveAt(i);
                else i++;
            }
            return Meths.Count <= 0;
        }

        public void Add(IInvoke<bool> act)
        {
            Meths.Add(act);
        }

        /*public void OnDrawGizmosSelected()
        {
            foreach (var meth in Meths)
            {
                (meth as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }*/

        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }
    [TypeInfoBox("Return true when all Meths returned true. Removes Meths if they true. Stops if some Meth has returned false.")]
    public class Sequence : IInvoke<bool>, IContainer
    {
        public bool oneInvocation;
        public List<IInvoke<bool>> Meths = new List<IInvoke<bool>>();

        [Button("Set Action")]
        void IContainer.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IContainer) ((IContainer)Meths[i]).SetAction();
            }
        }

        public bool Invoke()
        {
            while (Meths.Count > 0 && Meths[0].Invoke())
                Meths.RemoveAt(0);
            return Meths.Count <= 0 || oneInvocation;
        }

        public void Add(IInvoke<bool> act)
        {
            Meths.Add(act);
        }
        /*public void OnDrawGizmosSelected()
        {
            foreach (var meth in Meths)
            {
                (meth as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }*/
        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }
    [TypeInfoBox("Returns true when all Meths have returned true. Doesn't remove Meths if they true. Doesn't stop if some Meth has returned false.")]
    public class Condition : IInvoke<bool>, IContainer
    {
        public List<IInvoke<bool>> Meths = new List<IInvoke<bool>>();

        [Button("Set Action")]
        void IContainer.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IContainer) ((IContainer)Meths[i]).SetAction();
            }
        }


        public bool Invoke()
        {
            bool done = true;
            for (int i = 0; i < Meths.Count;)
            {
                if (Meths[i] == null) { Meths.RemoveAt(i); continue; }
                done = Meths[i++].Invoke() && done;
            }
            return done;
        }

        public void Add(IInvoke<bool> act)
        {
            Meths.Add(act);
        }
        /*public void OnDrawGizmosSelected()
        {
            foreach (var meth in Meths)
            {
                (meth as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }*/
        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }

    [TypeInfoBox("Returns true when all Meths have returned true. Doesn't remove Meths if they true. Stops if some Meth has returned false")]
    public class ConditionSequence : IInvoke<bool>, IContainer
    {
        public bool oneInvocation;
        public List<IInvoke<bool>> Meths = new List<IInvoke<bool>>();

        [Button("Set Action")]
        void IContainer.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IContainer) ((IContainer)Meths[i]).SetAction();
            }
        }


        public bool Invoke()
        {
            for (int i = 0; i < Meths.Count;)
            {
                if (Meths[i] == null) { Meths.RemoveAt(i); continue; }
                if (!Meths[i++].Invoke()) return oneInvocation;
            }
            return true;
        }

        public void Add(IInvoke<bool> act)
        {
            Meths.Add(act);
        }
        /*public void OnDrawGizmosSelected()
        {
            foreach (var meth in Meths)
            {
                (meth as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }*/
        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }
    public class IfElse : IInvoke<bool>, IContainer
    {
        public IInvoke<bool> If, Then, Else;

        [Button("Set Action")]
        void IContainer.SetAction()
        {
            if (If is IBuilder) If = ((IBuilder)If).GetAct();
            else if (If is IContainer) ((IContainer)If).SetAction();
            if (Then is IBuilder) Then = ((IBuilder)Then).GetAct();
            else if (Then is IContainer) ((IContainer)Then).SetAction();
            if (Else is IBuilder) Else = ((IBuilder)Else).GetAct();
            else if (Else is IContainer) ((IContainer)Else).SetAction();
        }


        public bool Invoke()
        {
            if (If != null && If.Invoke())
            {
                if (Then == null) return Else == null;
                return Then.Invoke();
            }
            else if (Else == null) return Then == null;
            return Else.Invoke();
        }

        public void Add(IInvoke<bool> act)
        {
            Then = act;
        }
        /*public void OnDrawGizmosSelected()
        {
            (If as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Then as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Else as IDrawGizmosSelected)?.OnDrawGizmosSelected();
        }*/
        public bool IsValide
        {
            get { return If != null; }
        }
    }
    public class IfThen : IInvoke<bool>, IContainer
    {
        public IInvoke<bool> If, Then;

        [Button("Set Action")]
        void IContainer.SetAction()
        {
            if (If is IBuilder) If = ((IBuilder)If).GetAct();
            else if (If is IContainer) ((IContainer)If).SetAction();
            if (Then is IBuilder) Then = ((IBuilder)Then).GetAct();
            else if (Then is IContainer) ((IContainer)Then).SetAction();
        }


        public bool Invoke()
        {
            if (If == null) return true;
            if (If.Invoke())
            {
                if (Then == null) return true;
                return Then.Invoke();
            }
            return false;
        }

        public void Add(IInvoke<bool> act)
        {
            Then = act;
        }

        /*public void OnDrawGizmosSelected()
        {
            (If as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Then as IDrawGizmosSelected)?.OnDrawGizmosSelected();
        }*/
        public bool IsValide
        {
            get { return If != null; }
        }
    }
    #endregion

    #region Builders

    public class ReferenceMethodBuilder : IInvoke<bool>, IBuilder
    {
        public ReferenceMethodBuilder()
        {
            //target = new MyMeths();
            FreshType();
        }

        public bool IsStatic = true;
        [OnValueChanged("FreshType"), HideIf("IsStatic")]
        public object target;
        [OnValueChanged("FreshType"), ShowIf("IsStatic")]
        public TypeInfo Target;
        //public bool array;
        [OnValueChanged("FreshType")]
        [ValueDropdown("_methsNames", DropdownWidth = 1000)]
        public string meth;
        List<string> _methsNames = new List<string>();
        int _methIndex;

        [OnValueChanged("FreshType")]
        [ValueDropdown("_types"), HideIf("IsStatic")]
        public Type type;
        List<Type> _types = new List<Type>();
        int _typeIndex;

        List<MethodInfo> _meths = new List<MethodInfo>();
        [Button]
        void FreshType()
        {
            if (!IsStatic)
            {
                if (this.target == null) return;
                var target = this.target.GetType();
                Target = target.GetTypeInfo();

                _types = new List<Type>();

                do _types.Add(target);
                while ((target = target.BaseType) != null);

                if (_types.IndexOf(type) >= 0) _typeIndex = _types.IndexOf(type);
                else
                {
                    if (_types.Count <= _typeIndex) _typeIndex = _types.Count - 1;
                    type = _types[_typeIndex];
                }
            }
            else if (Target == null) return;

            TypeFilter();
        }

        void TypeFilter()
        {
            _meths = new List<MethodInfo>();
            foreach (var meth in Target.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | (IsStatic ? BindingFlags.Static : BindingFlags.Instance | BindingFlags.Static)))// | BindingFlags.DeclaredOnly))
            {
                if ((meth.DeclaringType != type && !IsStatic) || (meth.ReturnType != typeof(void) && meth.ReturnType != typeof(bool)) || meth.IsGenericMethod) continue;
                var param = meth.GetParameters();
                if (param.Length > 5 || !RefValidate(param)) continue;

                _meths.Add(meth);
            }
            SetMeths();
        }

        void SetMeths()
        {
            _methsNames = new List<string>();
            for (int i = 0; i < _meths.Count;)
            {
                StringBuilder name = new StringBuilder();
                if(!IsStatic && _meths[i].IsStatic) name.Append("s_");
                var temp = _meths[i].ReturnType.ToString();
                name.Append(temp.Substring(temp.LastIndexOf('.') + 1) + " ");
                name.Append(_meths[i].Name + " ");

                name.Append("(");
                var param = _meths[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (j != 0) name.Append(", ");
                    temp = param[j].ParameterType.Name;
                    name.Append(temp.Substring(temp.LastIndexOf('.') + 1) + " " + param[j].Name);
                }
                name.Append(")");

                _methsNames.Add(name.ToString());// _meths[i].ToString());
                i++;
            }
            FreshTargetMeth();
        }

        void FreshTargetMeth()
        {
            if (_methsNames.IndexOf(meth) >= 0) _methIndex = _methsNames.IndexOf(meth);
            else
            {
                if (_methsNames.Count <= _methIndex) 
                {
                    if(_methsNames.Count == 0)
                    {
                        meth = "";
                        return;
                    }
                    _methIndex = _methsNames.Count - 1; 
                }
                meth = _methsNames[_methIndex];
            }
        }

        bool RefValidate(ParameterInfo[] paramsInfo)
        {
            bool rf = true;
            foreach (var item in paramsInfo)
            {
                if (item.ParameterType.ToString().Contains('&'))
                {
                    if (!rf) return false;
                }
                else rf = false;
            }
            return true;
        }

        int RefCount(ParameterInfo[] paramsInfo)
        {
            int i = 0;
            foreach (var item in paramsInfo)
            {
                if (item.ParameterType.ToString().Contains('&')) i++;
            }
            return i;
        }

        public bool Invoke()
        {
            return GetAct().Invoke();
        }

        public IInvoke<bool> GetAct()
        {
            if (_meths == null) FreshType();
            if (_meths.Count == 0) throw new Exception("Meths is empty");

            var meth = _meths[_methIndex];
            StringBuilder path = new StringBuilder();
            path.Append("BP.Delegates.");

            //if (array) path.Append("Array");

            var parms = meth.GetParameters();
            var refs = RefCount(meth.GetParameters());
            if (refs > 0) path.Append("Ref" + refs);

            if (meth.ReturnType == typeof(bool)) path.Append("Fun");
            else path.Append("Act");

            if (parms.Length > 0)
            {
                path.Append("`" + parms.Length);
                var type = typeof(ReferenceMethodBuilder).Assembly.GetType(path.ToString());
                var types = new Type[parms.Length];
                for (int i = 0; i < parms.Length; i++)
                {
                    if (parms[i].ParameterType.IsByRef) types[i] = parms[i].ParameterType.GetElementType();
                    else types[i] = parms[i].ParameterType;
                }
                type = type.MakeGenericType(types);
                var obj = Activator.CreateInstance(type);
                //if (!array)
                {
                    var field = type.GetField("del");
                    Delegate del = meth.IsStatic ? meth.CreateDelegate(field.FieldType) : meth.CreateDelegate(field.FieldType, target);
                    field.SetValue(obj, del);
                }
                return obj as IInvoke<bool>;
            }
            else
            {
                var type = typeof(ReferenceMethodBuilder).Assembly.GetType(path.ToString());
                var obj = Activator.CreateInstance(type);
                //if (!array)
                {
                    var field = type.GetField("del");
                    Delegate del = meth.IsStatic ? meth.CreateDelegate(field.FieldType) : meth.CreateDelegate(field.FieldType, target);
                    field.SetValue(obj, del);
                }
                return obj as IInvoke<bool>;
            }
        }
    }
    #endregion

}
