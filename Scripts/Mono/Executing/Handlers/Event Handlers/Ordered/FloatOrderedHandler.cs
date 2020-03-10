using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Handlers
{
    public class FloatOrderedHandler : OrderedHandler<float>
    {
        protected override int Compare(float x, float y)
        {
            return x.CompareTo(y);
        }
    }
}
