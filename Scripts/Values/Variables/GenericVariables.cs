using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    using Delegates;
    using Containers;

    public interface IGet<T>
    {
        T Value { get; }
    }
    public interface ISet<T>
    {
        T Value { set; }
    }
    public interface IVar<T> : IGet<T>, ISet<T>
    {
        new T Value { get; set; }
    }

    public class Value<T> : IVar<T>
    {
        [SerializeField, HideLabel]
        T value;

        public Value(T value)// : this()
        {
            this.value = value;
        }

        T IVar<T>.Value { get => value; set => this.value = value; }
        T IGet<T>.Value { get => value; }
        T ISet<T>.Value { set => this.value = value; }
    }
    public class Var<T> : IVar<T>
    {
        [SerializeField]
        IVar<T> value;

        public Var(IVar<T> value)// : this()
        {
            this.value = value;
        }

        public T Value { get => value.Value;  set => this.value.Value = value; }
    }
    public class Get<T> : IVar<T>
    {
        public IGet<T> value;
        public T Value { get => value.Value; set => throw new System.NotImplementedException(); }
    }
    public class GlobalVariable<T> : SerializedScriptableObject, IVar<T>
    {
        [SerializeField]
        IVar<T> value;
        public T Value { get => value.Value; set => this.value.Value = value; }
    }

    public class CachedValue<T> : IVar<T>
    {
        [SerializeField]
        IVar<T> value;

        IVar<T> cache;  //Replace with bool, save cached value to "value" variable. Reset when application quit (in otherwise ScriptableObjects will crush this behaviour after calling in the Unity).
        public T Value
        {
            get
            {
                if (cache == null)
                    cache = new Value<T>(value.Value);
                return cache.Value;
            }
            set => cache.Value = value;
        }
    }
    public class Container<T> : IVar<T> where T : IContainable
    {
        [AssetSelector]
        [SerializeField] IGet<string>  key;
        [AssetSelector]
        [SerializeField] Containers.IContainer container;

        public T Value 
        {
            get
            {
                T result;
                var key = this.key.Value;
                if (container.TryGetValue<T>(key, out result)) return result;

                throw new System.Exception("Key is invalid or Type missing");
            }
            set => container.SetValue(key.Value, value);
        }
    }

    public class GetComponent<T> : IGet<T>
    {
        [SerializeField]
        IGet<GameObject> value;
        public T Value => value.Value.GetComponent<T>();
    }
    public class GetComponentInChildren<T> : IGet<T>
    {
        [SerializeField]
        IGet<GameObject> value;
        public T Value => value.Value.GetComponentInChildren<T>();
    }
    public class ChangeCheker<T> : IVar<T>
    {
        [AssetSelector]
        [SerializeField]
        IAction OnValueChange;
        [SerializeField]
        IVar<T> value;

        public T Value 
        { 
            get => value.Value; 
            set
            {
                if (this.value.Value.Equals(value)) return;
                this.value.Value = value;
                OnValueChange?.Action();
            }
        }
    }
    public struct Stamb<T> : IVar<T>
    {
        public T Value
        {
            get => default;
            set { }
        }
    }
}