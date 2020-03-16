﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece.Debugs
{
    public class StepPauser : MonoBehaviour
    {
        public int CurrentStep;
        public int PauseStep;

        void Update()
        {
            if (++CurrentStep == PauseStep)
            {
                Debug.Break();
            }
        }
    }
}
