#if UNITY_EDITOR
using UnityEngine;
using Toodles.Delegates;
using System.Linq;

namespace Toodles.Executers
{
    public class ExecuteFactory
    {
        public enum ExecuteType
        {
            Nothing, Main, Coll, Mouse, Pointer
        }

        protected GameObject gameObject;
        protected ExecuteType   type;
        protected IIterate   iterate;
        protected string description;

        protected MonoBehaviour mustDestroyed;
        public ExecuteFactory(Execute mustReplaced)
        {
            gameObject = mustReplaced.gameObject;
            type = mustReplaced.type;
            iterate = mustReplaced.iterate;
            mustDestroyed = mustReplaced;
            description = mustReplaced.Description;
        }

        protected Execute execute;
        public void Produce()
        {
            AddExecute();
            SetValues();
            Terminate();
        }

        protected virtual void AddExecute()
        {
            switch (type)
            {
                case ExecuteType.Nothing:
                    execute = gameObject.AddComponent<Execute>();
                    break;
                case ExecuteType.Main:
                    execute = gameObject.AddComponent<MainExecute>();
                    break;
                case ExecuteType.Coll:
                    execute = gameObject.AddComponent<CollExecute>();
                    break;
                case ExecuteType.Mouse:
                    execute = gameObject.AddComponent<MouseExecute>();
                    break;
                case ExecuteType.Pointer:
                    execute = gameObject.AddComponent<PointerExecute>();
                    break;
            }
        }
        protected virtual void SetValues()
        {
            execute.iterate = iterate;
            execute.type = type;
            execute._type = type;
            execute.Description = description;
        }
        protected virtual void Terminate()
        {
            var comps = gameObject.GetComponents<Component>();

            for (int i = comps.Length - 1; comps[i] != mustDestroyed; i--)
            {
                UnityEditorInternal.ComponentUtility.MoveComponentUp(execute);
            }

            if (mustDestroyed != null)
                GameObject.DestroyImmediate(mustDestroyed, true);
        }
    }
}
#endif
