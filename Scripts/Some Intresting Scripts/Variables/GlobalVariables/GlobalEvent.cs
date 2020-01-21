using Sirenix.OdinInspector;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/Actions/GlobalEvent")]
public class GlobalEvent : ScriptableObject, IAction, ISigner
{
    event Action acts;

    public void Subscribe(params Action[] acts)
    {
        foreach (var act in acts) this.acts += act;
    }

    public void Unsubscribe(params Action[] acts)
    {
        foreach (var act in acts) this.acts -= act;
    }
    [Button]
    public void Action()
    {
        acts?.Invoke();
    }
}
