
namespace Toodles.Core.Adapters.Actions
{
    public class DisableAdapter : ActionAdapterBase<IDisable>
    {
        protected override bool Action()
        {
            Value.OnDisable();
            return base.Action();
        }
    }
}
