using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Samples
{
    public static void SetColor(IGet<SpriteRenderer> rend,IGet<Color> color)
    {
        rend.Get.color = color.Get;
    }
    public static void SetPosition(IGet<Transform> tr, IGet<Vector2> pos)
    {
        tr.Get.position = pos.Get;
    }
    public static void SubscribeUpdateExecute(IAction act, GeneralExecuteHandler.UpdateType type)
    {
        GeneralExecuteHandler.Subscribe(act.Action, type);
    }
    public static void UnsubscribeUpdateExecute(IAction act, GeneralExecuteHandler.UpdateType type)
    {
        GeneralExecuteHandler.Unsubscribe(act.Action, type);
    }

    public static void Debug(string log)
    {
        UnityEngine.Debug.Log(log);
    }
}
