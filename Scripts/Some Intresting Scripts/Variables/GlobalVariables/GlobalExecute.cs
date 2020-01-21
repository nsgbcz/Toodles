using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/Actions/GlobalExecute")]
public class GlobalExecute : SerializedScriptableObject, IAction
{
    public IAction action;

    [Button]
    public void Action()
    {
        action?.Action();
    }
}
