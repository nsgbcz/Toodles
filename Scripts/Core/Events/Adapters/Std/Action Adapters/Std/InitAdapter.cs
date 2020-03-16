using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Core.Adapters.Actions
{
    public class InitAdapter : ActionAdapterBase<IInit>
    {
        protected override bool Action()
        {
            Value.Init();
            return base.Action();
        }
    }
}
