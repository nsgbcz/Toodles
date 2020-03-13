using Sirenix.OdinInspector;
using System.Collections.Generic;
using Toodles.Actions;

namespace Toodles.IterableControllers
{
    public class IfThenIteratable : IIteratable, IIterableController
    {
        public IIteratable If, Then;

        public bool Iterate()
        {
            if (If == null) return true;
            if (If.Iterate())
            {
                if (Then == null) return true;
                return Then.Iterate();
            }
            return false;
        }

        public void Add(IIteratable act)
        {
            Then = act;
        }

        public void OnDrawGizmosSelected()
        {
            (If as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Then as IDrawGizmosSelected)?.OnDrawGizmosSelected();
        }
        public bool IsValide
        {
            get { return If != null; }
        }
    }
}