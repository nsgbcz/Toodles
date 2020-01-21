using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public abstract class Switcher : SerializedMonoBehaviour, IAction
{
    public enum AccountEvent { All, Enter, Exit }

    public Framework.Type targetFramework;

    public AccountEvent accountEvent = AccountEvent.All;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (UseEnter())
        {
            if (targetFramework == Framework.Type.Nothing) OnIn();
            else
            {
                var framework = coll.GetComponent<Framework>();
                if (framework != null && framework.type == targetFramework) OnIn();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (UseExit())
        {
            if (targetFramework == Framework.Type.Nothing) OnOut();
            else
            {
                var framework = coll.GetComponent<Framework>();
                if (framework != null && framework.type == targetFramework) OnOut();
            }
        }
    }

    public virtual void OnIn() { Action(); }

    public virtual void OnOut() { Action(); }

    public virtual void Action() { }

    public bool UseEnter()
    {
        return accountEvent != AccountEvent.Exit;
    }
    public bool UseExit()
    {
        return accountEvent != AccountEvent.Enter;
    }

#if UNITY_EDITOR
    [ContextMenu("ReloadComponent")]
    public void ReloadComponent()
    {
        var comp = gameObject.AddComponent(GetType());
        EditorUtility.CopySerialized(this, comp);
        DestroyImmediate(this, true);
    }
#endif
}
