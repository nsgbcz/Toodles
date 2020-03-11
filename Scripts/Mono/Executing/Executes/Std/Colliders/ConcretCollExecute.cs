using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public abstract class ConcretCollExecute<T, IT> : ConcreteExecute<IT>
    {
        public IFilter<T> filter = new Stamb<T>();
    }
}