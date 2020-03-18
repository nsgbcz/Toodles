using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece
{
    public interface ITranslationComponent
    {
        Vector3 Translation { get; set; }
    }
}
