using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Toodles.Iterates
{
    interface IBuilder
    {
        IIteratable GetAct();
    }
}