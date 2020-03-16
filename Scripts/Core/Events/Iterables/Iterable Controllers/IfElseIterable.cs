using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Toodles
{
    public class IfElseIteratable : IIteratable, IIterableController
    {
        public IIteratable If, Then, Else;
        public bool Iterate()
        {
            if (If != null && If.Iterate())
            {
                if (Then == null) return Else == null;
                return Then.Iterate();
            }
            else if (Else == null) return Then == null;
            return Else.Iterate();
        }

        public void Add(IIteratable act)
        {
            Then = act;
        }
        public void OnDrawGizmosSelected()
        {
            (If as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Then as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Else as IDrawGizmosSelected)?.OnDrawGizmosSelected();
        }
        public bool IsValide
        {
            get { return If != null; }
        }
    }
}