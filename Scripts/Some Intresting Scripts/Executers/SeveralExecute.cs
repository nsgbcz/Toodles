using MyDelegates;
using Sirenix.OdinInspector;
using UnityEngine;
public class SeveralExecute : SerializedMonoBehaviour
{
    [Header("Maximum is 10 actions")]
    public IInvoke<bool>[] actions;

    [Button("Set Action")]
    void SetAction()
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i] is IBuilder) actions[i] = ((IBuilder)actions[i]).GetAct();
            else if (actions[i] is IContainer) ((IContainer)actions[i]).SetAction();
        }
    }

    public void Action0()
    {
        if (0 < actions.Length) actions[0]?.Invoke();
    }
    public void Action1()
    {
        if (1 < actions.Length) actions[1]?.Invoke();
    }
    public void Action2()
    {
        if (2 < actions.Length) actions[2]?.Invoke();
    }
    public void Action3()
    {
        if (3 < actions.Length) actions[3]?.Invoke();
    }
    public void Action4()
    {
        if (4 < actions.Length) actions[4]?.Invoke();
    }
    public void Action5()
    {
        if (5 < actions.Length) actions[5]?.Invoke();
    }
    public void Action6()
    {
        if (6 < actions.Length) actions[6]?.Invoke();
    }
    public void Action7()
    {
        if (7 < actions.Length) actions[7]?.Invoke();
    }
    public void Action8()
    {
        if (8 < actions.Length) actions[8]?.Invoke();
    }
    public void Action9()
    {
        if (9 < actions.Length) actions[9]?.Invoke();
    }
}
