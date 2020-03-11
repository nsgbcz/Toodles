using Sirenix.OdinInspector;
using System.Collections.Generic;
using Toodles.Iterates;

namespace Toodles.Controllers
{
    public class IfElseIteratable : IIteratable, IIterableController
    {
        public IIteratable If, Then, Else;

        [Button("Set Action")]
        void IIterableController.SetAction()
        {
            if (If is IBuilder) If = ((IBuilder)If).GetAct();
            else if (If is IIterableController) ((IIterableController)If).SetAction();
            if (Then is IBuilder) Then = ((IBuilder)Then).GetAct();
            else if (Then is IIterableController) ((IIterableController)Then).SetAction();
            if (Else is IBuilder) Else = ((IBuilder)Else).GetAct();
            else if (Else is IIterableController) ((IIterableController)Else).SetAction();
        }


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