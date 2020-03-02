using System.Collections.Generic;
using Toodles.Controllers;
using Sirenix.OdinInspector;
using System;
using System.Reflection;
using System.Text;
using System.Linq;
using Toodles.Iterables;

namespace Toodles.MethodBuilders
{
    public class ReferenceMethodBuilder : IIteratable, IBuilder
    {
        public ReferenceMethodBuilder()
        {
            //target = new MyMeths();
            FreshType();
        }
        [OnValueChanged("FreshType")]
        public bool IsTargetStatic = true;
        [OnValueChanged("FreshType"), HideIf("IsTargetStatic")]
        public object targetType;
        [OnValueChanged("FreshType"), ShowIf("IsTargetStatic")]
        public TypeInfo TargetType;

        bool _showConcretType { get => !IsTargetStatic && targetType != null && _types != null && _types.Count > 0; }
        [OnValueChanged("FreshType")]
        [ValueDropdown("_types"), ShowIf("_showConcretType")]
        public Type concretType;
        List<Type> _types = new List<Type>();
        int _typeIndex;

        bool _showTargetMethod { get => _methsNames != null && _methsNames.Count > 0; }
        [OnValueChanged("FreshType")]
        [ValueDropdown("_methsNames", DrawDropdownForListElements = true), ShowIf("_showTargetMethod")]
        public string targetMethod;
        List<string> _methsNames = new List<string>();
        int _methIndex;

        List<MethodInfo> _meths = new List<MethodInfo>();
        [Button]
        void FreshType()
        {
            if (!IsTargetStatic)
            {
                if (this.targetType == null) return;
                var target = this.targetType.GetType();
                TargetType = target.GetTypeInfo();

                _types = new List<Type>();

                do
                {
                    if (target.GetMethods(methFilter).Length != 0)
                        _types.Add(target);
                }
                while ((target = target.BaseType) != null);

                if (_types.IndexOf(concretType) >= 0) _typeIndex = _types.IndexOf(concretType);
                else
                {
                    if (_types.Count <= _typeIndex) _typeIndex = _types.Count - 1;
                    concretType = _types[_typeIndex];
                }
            }
            else if (TargetType == null) return;

            TypeFilter();
        }

        BindingFlags methFilter { get => (BindingFlags.Public | BindingFlags.NonPublic | (IsTargetStatic ? BindingFlags.Static : BindingFlags.Instance | BindingFlags.Static)); }
        void TypeFilter()
        {
            _meths = new List<MethodInfo>();
            foreach (var meth in TargetType.GetMethods(methFilter))// | BindingFlags.DeclaredOnly))
            {
                if ((meth.DeclaringType != concretType && !IsTargetStatic) || (meth.ReturnType != typeof(void) && meth.ReturnType != typeof(bool)) || meth.IsGenericMethod) continue;
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
                if (!IsTargetStatic && _meths[i].IsStatic) name.Append("s_");
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
            if (_methsNames.IndexOf(targetMethod) >= 0) _methIndex = _methsNames.IndexOf(targetMethod);
            else
            {
                if (_methsNames.Count <= _methIndex)
                {
                    if (_methsNames.Count == 0)
                    {
                        targetMethod = "";
                        return;
                    }
                    _methIndex = _methsNames.Count - 1;
                }
                targetMethod = _methsNames[_methIndex];
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

        public bool Iterate()
        {
            return GetAct().Iterate();
        }

        public IIteratable GetAct()
        {
            if (_meths == null) FreshType();
            if (_meths.Count == 0) throw new Exception("Meths is empty");

            var meth = _meths[_methIndex];
            StringBuilder path = new StringBuilder();
            path.Append("Toodles.Delegates.");

            var parms = meth.GetParameters();
            var refs = RefCount(meth.GetParameters());
            if (refs > 0) path.Append("Ref" + refs);

            if (meth.ReturnType == typeof(bool)) path.Append(typeof(Fun).Name);
            else path.Append(typeof(Act).Name);

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
                    System.Delegate del = meth.IsStatic ? meth.CreateDelegate(field.FieldType) : meth.CreateDelegate(field.FieldType, targetType);
                    field.SetValue(obj, del);
                }
                return obj as IIteratable;
            }
            else
            {
                var type = typeof(ReferenceMethodBuilder).Assembly.GetType(path.ToString());
                var obj = Activator.CreateInstance(type);
                //if (!array)
                {
                    var field = type.GetField("del");
                    System.Delegate del = meth.IsStatic ? meth.CreateDelegate(field.FieldType) : meth.CreateDelegate(field.FieldType, targetType);
                    field.SetValue(obj, del);
                }
                return obj as IIteratable;
            }
        }
    }
}

