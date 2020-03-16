using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Mono
{
    public class IntOrderedHandler : OrderedHandler<int>
    {
        protected override int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}
