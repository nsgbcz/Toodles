using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles
{
    public interface IIterableController : IIteratable, IDrawGizmosSelected
    {
        void Add(IIteratable act);

        bool IsValide { get; }
    } 
}