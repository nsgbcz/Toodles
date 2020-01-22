﻿using UnityEngine;
using Sirenix.OdinInspector;

namespace BP
{
    #region Main
    public class Value<T> : IVar<T>
    {
        public T value;
        public T Get => value;
        public T Set { set => this.value = value; }
    }
    public class Var<T> : IVar<T>
    {
        public IVar<T> Value;
        public virtual T Get => Value.Get;
        public virtual T Set { set => Value.Set = value; }
    }
    public class Getter<T> : IGet<T>
    {
        public IGet<T> Value;
        public virtual T Get => Value.Get;
    }
    public class Setter<T> : ISet<T>
    {
        public ISet<T> Value;
        public virtual T Set { set => Value.Set = value; }
    }
    public class GlobalVariable<T> : SerializedScriptableObject, IVar<T>
    {
        public IVar<T> variable;
        public virtual T Get => variable.Get;
        public virtual T Set { set => variable.Set = value; }
    }
    public struct GetComponent<T> : IGet<T>
    {
        public IGet<GameObject> Value;
        public T Get => Value.Get.GetComponent<T>();
    }
    public struct GetComponentInChildren<T> : IGet<T>
    {
        public IGet<GameObject> Value;
        public T Get => Value.Get.GetComponentInChildren<T>();
    }
    public class ChangeCheker<T> : IVar<T>
    {
        public IAction OnValueChange;
        public IVar<T> Value;

        public T Get => Value.Get;
        public T Set
        {
            set
            {
                if (Value.Get.Equals(value)) return;
                Value.Set = value;
                OnValueChange?.Action();
            }
        }
    }
    #endregion
    #region Variables
    #region Color
    public struct SpriteRendererToColor : IGet<Color>
    {
        public IGet<SpriteRenderer> Value;
        public Color Get => Value.Get.color;
    }
    #endregion
    #region Vector2
    public struct MousePosition : IGet<Vector2>
    {
        public Vector2 Get => CameraHandler.MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    public struct TransformPosition : IGet<Vector2>
    {
        public IGet<Transform> Value;
        public Vector2 Get => Value.Get.position;
    }
    #endregion
    #region GameObject
    public struct CollisionToGameObject : IGet<GameObject>
    {
        public IGet<Collision2D> Value;
        public GameObject Get => Value.Get.gameObject;
    }
    #endregion
    #region Float
    public struct MultiplyFloat : IGet<float>
    {
        public IGet<float> First, Second;
        public float Get => First.Get * Second.Get;
    }

    public struct DeltaTime : IGet<float>
    {
        public enum Type { Scaled, Unscaled, Fixed, UnscaledFixed }

        public Type DeltaType;
        public float Get
        {
            get
            {
                switch (DeltaType)
                {
                    case Type.Scaled:
                        return Time.deltaTime;
                    case Type.Unscaled:
                        return Time.unscaledDeltaTime;
                    case Type.Fixed:
                        return Time.fixedDeltaTime;
                    default:
                        return Time.fixedUnscaledDeltaTime;
                }
            }
        }
    }
    #endregion
    #endregion
}