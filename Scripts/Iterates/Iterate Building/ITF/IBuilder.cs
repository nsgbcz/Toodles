using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Toodles.Delegates
{
    interface IBuilder
    {
        IIteratable GetAct();
    }
}