﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles.Iterates;
using System;

namespace Toodles.Controllers
{
    public interface IIterableController : IIteratable, IDrawGizmosSelected
    {
        void SetAction();

        void Add(IIteratable act);

        bool IsValide { get; }
    } 
}