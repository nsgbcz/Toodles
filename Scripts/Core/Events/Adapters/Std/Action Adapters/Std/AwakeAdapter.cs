
namespace Toodles.Core.Adapters.Actions
{
    public class AwakeAdapter : ActionAdapterBase<IAwake>
    {
        protected override bool Action()
        {
            Value.OnAwake();
            return base.Action();
        }
    }
}
