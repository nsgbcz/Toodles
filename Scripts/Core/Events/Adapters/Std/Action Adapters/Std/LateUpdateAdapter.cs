
namespace Toodles.Core.Adapters.Actions
{
    public class LateUpdateAdapter : ActionAdapterBase<ILateUpdate>
    {
        protected override bool Action()
        {
            Value.OnLateUpdate();
            return base.Action();
        }
    }
}
