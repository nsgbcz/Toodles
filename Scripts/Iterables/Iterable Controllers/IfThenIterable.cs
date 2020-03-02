using Sirenix.OdinInspector;
using System.Collections.Generic;
using Toodles.Iterables;

namespace Toodles.Controllers
{
    public class IfThenIteratable : IIteratable, IIterableController
    {
        public IIteratable If, Then;

        [Button("Set Action")]
        void IIterableController.SetAction()
        {
            if (If is IBuilder) If = ((IBuilder)If).GetAct();
            else if (If is IIterableController) ((IIterableController)If).SetAction();
            if (Then is IBuilder) Then = ((IBuilder)Then).GetAct();
            else if (Then is IIterableController) ((IIterableController)Then).SetAction();
        }


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
            (If as Toodles.Variables.IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Then as Toodles.Variables.IDrawGizmosSelected)?.OnDrawGizmosSelected();
        }
        public bool IsValide
        {
            get { return If != null; }
        }
    }
}