using MyDelegates;
using Sirenix.OdinInspector;

public class SwitchExecute : Switcher
{
#if UNITY_EDITOR
    [PropertyOrder(-1)]
    public string Description;
#endif
    [ShowIf("UseEnter")]
    public IContainer WhenIn = new ListContainer();
    [ShowIf("UseExit")]
    public IContainer WhenOut = new ListContainer();

    [ShowIf("UseEnter"), Button]
    public override void OnIn()
    {
        if (WhenIn.Invoke() && !WhenOut.IsValide) Destroy(this);
    }

    [ShowIf("UseExit"), Button]
    public override void OnOut()
    {
        if (WhenOut.Invoke() && !WhenIn.IsValide) Destroy(this);
    }

/*#if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        WhenIn.OnDrawGizmosSelected();
        WhenOut.OnDrawGizmosSelected();
    }
#endif*/
}

