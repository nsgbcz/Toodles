
namespace Toodles.Core.Adapters.Actions
{
    public class DestroyAdapter : ActionAdapterBase<IDestroy>
    {
        protected override bool Action()
        {
            Value.OnDestroy();
            return base.Action();
        }
    }
}
