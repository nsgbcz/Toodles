using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes
{
    using Iterates;
    public class MouseExecute : ConcreteExecute<IIteratable>, IMouse
    {
        public bool Action()
        {
            if (execute != null && execute.Iterate())
            {
                Destroy(this);
                return true;
            }
            return false;
        }
    }
}