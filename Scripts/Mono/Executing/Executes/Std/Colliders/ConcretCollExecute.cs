using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executers 
{
    public abstract class ConcretCollExecute<T> : CollExecute, Variables.IVar<T>
    {
        protected T coll;
        public T Value { get => coll; set => coll = value; }

        public override void Action()
        {
            if (filter.Filter(coll)) base.Action();
        }

        public IFilter<T> filter = new Stamb<T>();
    }
}