using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Input
{
    public struct JoystickData
    {
        [SerializeField]
        Transform m_Background;
        [SerializeField]
        Transform m_Stick;

        [SerializeField]
        float m_BackgroundSize;
        [SerializeField]
        float m_StickSize;
    }
}
