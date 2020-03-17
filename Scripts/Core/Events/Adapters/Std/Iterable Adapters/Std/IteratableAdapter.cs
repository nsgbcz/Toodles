using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Iterable
{
    using UnityEngine.EventSystems;

    public class IteratableAdapter : IteratableAdapterBase<IIteratable>
    {
        protected override bool Iterate()
        {
            return Value.Iterate();
        }
    }
}
