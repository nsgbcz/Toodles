using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles.Iterables;
using System;

namespace Toodles.Controllers
{
    using Variables;
    public interface IIterableController : IIteratable, Toodles.Variables.IDrawGizmosSelected
    {
        void SetAction();

        void Add(IIteratable act);

        bool IsValide { get; }
    } 
}