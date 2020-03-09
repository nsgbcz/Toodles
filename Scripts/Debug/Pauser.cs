using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
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
