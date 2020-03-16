using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Toodles
{
    [TypeInfoBox("Return true when all Meths returned true. Removes Meths if they true. Stops if some Meth has returned false.")]
    public class SequenceIterable : IIteratable, IIterableController
    {
        public bool oneInvocation;
        public List<IIteratable> Meths = new List<IIteratable>();

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
                (meth as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            }
        }
        public bool IsValide
        {
            get { return Meths.Count > 0; }
        }
    }
}