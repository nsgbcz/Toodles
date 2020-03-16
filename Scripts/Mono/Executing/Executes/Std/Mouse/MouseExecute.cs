using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Mono
{
    public class MouseExecute : ConcreteExecute<IIteratable>, IMouse
    {
        public bool OnMouse()
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