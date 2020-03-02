using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Toodles.Iterables
{
    interface IBuilder
    {
        IIteratable GetAct();
    }
}