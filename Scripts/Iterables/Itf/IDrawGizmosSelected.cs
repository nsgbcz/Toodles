using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Variables
{
    /// <summary>
    /// When using Executer and IIterable, use this on IIterable for Draw Gizmos.
    /// </summary>
    public interface IDrawGizmosSelected
    {
        void OnDrawGizmosSelected();
    }
}
