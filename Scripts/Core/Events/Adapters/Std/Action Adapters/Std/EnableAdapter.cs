
namespace Toodles.Core.Adapters.Actions
{
    public class EnableAdapter : ActionAdapterBase<IEnable>
    {
        protected override bool Action()
        {
            Value.OnEnable();
            return base.Action();
        }
    }
}
