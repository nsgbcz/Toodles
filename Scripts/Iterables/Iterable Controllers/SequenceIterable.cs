using Sirenix.OdinInspector;
using System.Collections.Generic;
using Toodles.Iterables;

namespace Toodles.Controllers
{
    [TypeInfoBox("Return true when all Meths returned true. Removes Meths if they true. Stops if some Meth has returned false.")]
    public class SequenceIterable : IIteratable, IIterableController
    {
        public bool oneInvocation;
        public List<IIteratable> Meths = new List<IIteratable>();

        [Button("Set Action")]
        void IIterableController.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IIterableController) ((IIterableController)Meths[i]).SetAction();
            }
        }

        public bool Iterate()
        {
            while (Meths.Count > 0 && Meths[0].Iterate())
                Meths.RemoveAt(0);
            return Meths.Count <= 0 || oneInvocation;
        }

        public void Add(IIteratable act)
        {
            Meths.Add(act);
        }
        public void OnDrawGizmosSelected()
        {
            foreach (var meth in Meths)
            {
                (meth as Toodles.Variables.IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }
        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }
}