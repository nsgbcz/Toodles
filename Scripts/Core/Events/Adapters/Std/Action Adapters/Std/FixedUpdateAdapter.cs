
namespace Toodles.Core.Adapters.Actions
{
    public class FixedUpdateAdapter : ActionAdapterBase<IFixedUpdate>
    {
        protected override bool Action()
        {
            Value.OnFixedUpdate();
            return base.Action();
        }
    }
}
