using MyDelegates;
using System.Collections.Generic;
using UnityEngine.UI;

public class ValueExecute : Execute
{
    public List<object> SetObj = new List<object>();
    //public List<ISetValue<IFloat>> SetIFloat = new List<ISetValue<IFloat>>();
    //public List<ISetValue<IInt>> SetIInt = new List<ISetValue<IInt>>();

    public void Action<T>(T value)
    {
        SetValue(value);
        Action();
    }

    public void Action(Slider value)
    {
        Action(value.value);
    }
    public void Action(bool value)
    {
        Action((object)value);
    }

    public void Action(IVar<float> value)
    {
        Action((object)value);
    }

    public void Action(float value)
    {
        Action((object)(MyFloat)value);
    }

    public void Action(IVar<int> value)
    {
        Action((object)value);
    }
    public void Action(int value)
    {
        Action((object)(MyInt)value);
    }

    public void Action(object value)
    {
        var valueType = value.GetType();
        foreach (var obj in SetObj)
        {
            foreach (var item in obj.GetType().GetInterfaces())
            {
                if (item.IsGenericType && item.GetGenericTypeDefinition() == typeof(ISetValue<>))
                {
                    var gen = item.GetGenericArguments()[0];
                    if (valueType == gen || gen.IsInstanceOfType(value)) item.GetMethod("SetValue").Invoke(obj, new object[] { value });
                    break;
                }
            }
        }
        Action();
    }
}

