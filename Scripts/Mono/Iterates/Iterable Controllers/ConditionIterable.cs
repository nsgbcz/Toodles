using Sirenix.OdinInspector;
using System.Collections.Generic;
using Toodles.Iterates;

namespace Toodles.Controllers
{
    [TypeInfoBox("Returns true when all Meths have returned true. Doesn't remove Meths if they true. Doesn't stop if some Meth has returned false.")]
    public class ConditionIterable : IIteratable, IIterableController
    {
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
            bool done = true;
            for (int i = 0; i < Meths.Count;)
            {
                if (Meths[i] == null) { Meths.RemoveAt(i); continue; }
                done = Meths[i++].Iterate() && done;
            }
            return done;
        }

        public void Add(IIteratable act)
        {
            Meths.Add(act);
        }
        public void OnDrawGizmosSelected()
        {
            foreach (var meth in Meths)
            {
                (meth as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }
        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }
}