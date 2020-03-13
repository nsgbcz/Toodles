using Sirenix.OdinInspector;
using System.Collections.Generic;
using Toodles.Actions;

namespace Toodles.IterableControllers
{
    [TypeInfoBox("Returns true when all Meths have returned true. Doesn't remove Meths if they true. Stops if some Meth has returned false")]
    public class ConditionSequenceIteratable : IIteratable, IIterableController
    {
        public bool oneInvocation;
        public List<IIteratable> Meths = new List<IIteratable>();

        public bool Iterate()
        {
            for (int i = 0; i < Meths.Count;)
            {
                if (Meths[i] == null) { Meths.RemoveAt(i); continue; }
                if (!Meths[i++].Iterate()) return oneInvocation;
            }
            return true;
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