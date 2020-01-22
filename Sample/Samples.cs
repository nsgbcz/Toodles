using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BP;

public static class Samples
{
    public static void MoveTowards(IGet<Transform> source, IGet<Vector2> target , IGet<float> speed)
    {
        source.Get.position = Vector2.MoveTowards(source.Get.position, target.Get, speed.Get);
    }

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

    public static void Destroy(IGet<GameObject> target)
    {
        Object.Destroy(target.Get);
    }
}
