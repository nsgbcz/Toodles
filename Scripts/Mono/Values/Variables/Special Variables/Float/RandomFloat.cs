﻿using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Variables
{
    public struct RandomFloat : IGet<float>
    {
        [SerializeField, Required]
        IGet<float> Min, Max;
        public float Value => UnityEngine.Random.Range(Min.Value, Max.Value);
    }
}
