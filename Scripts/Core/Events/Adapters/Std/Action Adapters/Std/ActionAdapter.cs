
namespace Toodles.Core.Adapters.Actions
{
    using UnityEngine.EventSystems;

    public class ActionAdapter : ActionAdapterBase<IAction>
    {
        protected override bool Action()
        {
            Value.Action();
            return base.Action();
        }
    }
}
