using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public class ListIterable : IIterableController
    {
        public List<IIteratable> Meths = new List<IIteratable>();

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
