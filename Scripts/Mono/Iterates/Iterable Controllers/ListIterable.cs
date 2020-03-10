using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles.Delegates;
using Sirenix.OdinInspector;

namespace Toodles.Controllers
{
    public class ListIterable : IIterableController
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
            for (int i = 0, j = 0; i < Meths.Count; j++)
            {
                if (Meths[i] == null || Meths[i].Iterate()) Meths.RemoveAt(i);
                else i++;
            }
            return Meths.Count <= 0;
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
