using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles.Actions;
using System;

namespace Toodles.IterableControllers
{
    public interface IIterableController : IIteratable, IDrawGizmosSelected
    {
        void Add(IIteratable act);

        bool IsValide { get; }
    } 
}