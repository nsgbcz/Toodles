
namespace Toodles.Core.Adapters.Actions
{
    public class UpdateAdapter : ActionAdapterBase<IUpdate>
    {
        protected override bool Action()
        {
            Value.OnUpdate();
            return base.Action();
        }
    }
}
