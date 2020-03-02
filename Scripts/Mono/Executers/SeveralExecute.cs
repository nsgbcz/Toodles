using Toodles.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using Toodles.Delegates;

namespace Toodles.Executers
{
    /// <summary>
    /// Was made to be executed from an animation
    /// </summary>
    public class SeveralExecute : SerializedMonoBehaviour
    {
        [Header("Maximum is 10 actions")]
        public IIterate[] iteretes;

        [Button("Set Action")]
        void SetAction()
        {
            for (int i = 0; i < iteretes.Length; i++)
            {
                if (iteretes[i] is IBuilder) iteretes[i] = ((IBuilder)iteretes[i]).GetAct();
                else if (iteretes[i] is IController) ((IController)iteretes[i]).SetAction();
            }
        }

        public void Action0()
        {
            if (0 < iteretes.Length) iteretes[0]?.Iterate();
        }
        public void Action1()
        {
            if (1 < iteretes.Length) iteretes[1]?.Iterate();
        }
        public void Action2()
        {
            if (2 < iteretes.Length) iteretes[2]?.Iterate();
        }
        public void Action3()
        {
            if (3 < iteretes.Length) iteretes[3]?.Iterate();
        }
        public void Action4()
        {
            if (4 < iteretes.Length) iteretes[4]?.Iterate();
        }
        public void Action5()
        {
            if (5 < iteretes.Length) iteretes[5]?.Iterate();
        }
        public void Action6()
        {
            if (6 < iteretes.Length) iteretes[6]?.Iterate();
        }
        public void Action7()
        {
            if (7 < iteretes.Length) iteretes[7]?.Iterate();
        }
        public void Action8()
        {
            if (8 < iteretes.Length) iteretes[8]?.Iterate();
        }
        public void Action9()
        {
            if (9 < iteretes.Length) iteretes[9]?.Iterate();
        }
    }
}
