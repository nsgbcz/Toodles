using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Core.Adapters.Actions
{
    public class RunAdapter : ActionAdapterBase<IRun>
    {
        protected override bool Action()
        {
            Value.Run();
            return base.Action();
        }
    }
}
