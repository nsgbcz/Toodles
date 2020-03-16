
namespace Toodles.Core.Adapters.Actions
{
    public class StartAdapter : ActionAdapterBase<IStart>
    {
        protected override bool Action()
        {
            Value.OnStart();
            return base.Action();
        }
    }
}
