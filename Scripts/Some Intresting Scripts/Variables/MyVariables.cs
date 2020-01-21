using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

#region Main
public class Var<T> : IVar<T>
{
    public T Value;
    public virtual T Get => Value;
    public virtual T Set { set => Value = value; }
}
public class Getter<T> : IGet<T>
{
    public T Value;
    public virtual T Get => Value;
}
public class Setter<T> : ISet<T>
{
    public T Value;
    public virtual T Set { set => Value = value; }
}
public class GlobalVariable<T> : SerializedScriptableObject, IVar<T>
{
    public IVar<T> variable;
    public virtual T Get => variable.Get;
    public virtual T Set { set => variable.Set = value; }
    public override string ToString()
    {
        return variable.ToString();
    }
}
public struct GetComponent<T> : IGet<T>
{
    public IGet<GameObject> Value;
    public T Get => Value.Get.GetComponent<T>();
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

public override string ToString()
    {
        return Value.ToString();
    }
}

public class MyValue<T> : IVar<T>
{
    public IVar<T> Value;

    public T Get => Value.Get;

    public T Set { set => Value.Set = value; }

    public override string ToString()
    {
        return Value.ToString();
    }
}
#endregion
#region Variables
#region Vector2
public struct MousePosition : IGet<Vector2>
{
    public Vector2 Get => CameraHandler.MainCamera.ScreenToWorldPoint(Input.mousePosition);
}
#endregion
#region GameObject
public struct CollisionToGameObject : IGet<GameObject>
{
    public IGet<Collision2D> Value;
    public GameObject Get => Value.Get.gameObject;
}
#endregion
#region Int
public struct MyInt : IVar<int>
{
    public int Value;

    public MyInt(int value)
    {
        Value = value;
    }

    public int Get => Value;
    public int Set { set => Value = value; }

    public static implicit operator int(MyInt obj)
    {
        return obj.Get;
    }
    public static implicit operator MyInt(int value)
    {
        return new MyInt(value);
    }
    public static implicit operator MyFloat(MyInt obj)
    {
        return new MyFloat(obj.Get);
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
#endregion
#region Float
public struct MyFloat : IVar<float>
{
    public float Value;

    public MyFloat(float value)
    {
        Value = value;
    }

    public float Get => Value;
    public float Set { set => Value = value; }

    public static implicit operator float(MyFloat obj)
    {
        return obj.Get;
    }

    public static implicit operator MyFloat(float value)
    {
        return new MyFloat(value);
    }
    public static implicit operator MyInt(MyFloat obj)
    {
        return new MyInt((int)obj.Get);
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}

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