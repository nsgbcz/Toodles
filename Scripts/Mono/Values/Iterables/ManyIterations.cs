﻿using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Actions
{
    public struct ManyIterations : IIteratable
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return false;
        }
    }
}
