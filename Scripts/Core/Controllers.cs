using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Toodles.Delegates;

namespace Toodles.Controllers
{
    #region Interfaces
    public interface IController : IIterate, IDrawGizmosSelected
    {
        void SetAction();

        void Add(IIterate act);

        bool IsValide { get; }
    }
    #endregion

    #region IContainers
    public class List : IController
    {
        public List<IIterate> Meths = new List<IIterate>();

        [Button("Set Action")]
        void IController.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IController) ((IController)Meths[i]).SetAction();
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

        public void Add(IIterate act)
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
    [TypeInfoBox("Return true when all Meths returned true. Removes Meths if they true. Stops if some Meth has returned false.")]
    public class Sequence : IIterate, IController
    {
        public bool oneInvocation;
        public List<IIterate> Meths = new List<IIterate>();

        [Button("Set Action")]
        void IController.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IController) ((IController)Meths[i]).SetAction();
            }
        }

        public bool Iterate()
        {
            while (Meths.Count > 0 && Meths[0].Iterate())
                Meths.RemoveAt(0);
            return Meths.Count <= 0 || oneInvocation;
        }

        public void Add(IIterate act)
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
    [TypeInfoBox("Returns true when all Meths have returned true. Doesn't remove Meths if they true. Doesn't stop if some Meth has returned false.")]
    public class Condition : IIterate, IController
    {
        public List<IIterate> Meths = new List<IIterate>();

        [Button("Set Action")]
        void IController.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IController) ((IController)Meths[i]).SetAction();
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

        public void Add(IIterate act)
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

    [TypeInfoBox("Returns true when all Meths have returned true. Doesn't remove Meths if they true. Stops if some Meth has returned false")]
    public class ConditionSequence : IIterate, IController
    {
        public bool oneInvocation;
        public List<IIterate> Meths = new List<IIterate>();

        [Button("Set Action")]
        void IController.SetAction()
        {
            for (int i = 0; i < Meths.Count; i++)
            {
                if (Meths[i] is IBuilder) Meths[i] = ((IBuilder)Meths[i]).GetAct();
                else if (Meths[i] is IController) ((IController)Meths[i]).SetAction();
            }
        }


        public bool Iterate()
        {
            for (int i = 0; i < Meths.Count;)
            {
                if (Meths[i] == null) { Meths.RemoveAt(i); continue; }
                if (!Meths[i++].Iterate()) return oneInvocation;
            }
            return true;
        }

        public void Add(IIterate act)
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
    public class IfElse : IIterate, IController
    {
        public IIterate If, Then, Else;

        [Button("Set Action")]
        void IController.SetAction()
        {
            if (If is IBuilder) If = ((IBuilder)If).GetAct();
            else if (If is IController) ((IController)If).SetAction();
            if (Then is IBuilder) Then = ((IBuilder)Then).GetAct();
            else if (Then is IController) ((IController)Then).SetAction();
            if (Else is IBuilder) Else = ((IBuilder)Else).GetAct();
            else if (Else is IController) ((IController)Else).SetAction();
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

        public void Add(IIterate act)
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
    public class IfThen : IIterate, IController
    {
        public IIterate If, Then;

        [Button("Set Action")]
        void IController.SetAction()
        {
            if (If is IBuilder) If = ((IBuilder)If).GetAct();
            else if (If is IController) ((IController)If).SetAction();
            if (Then is IBuilder) Then = ((IBuilder)Then).GetAct();
            else if (Then is IController) ((IController)Then).SetAction();
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

        public void Add(IIterate act)
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
    #endregion


}
