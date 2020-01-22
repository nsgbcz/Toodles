using Sirenix.OdinInspector;
using UnityEngine;

namespace BP
{
    public class CollReference : SerializedMonoBehaviour, IColl
    {
        public IColl[] targets = new IColl[0];

        public void OnCollisionEnter2D(Collision2D coll)
        {
            foreach (var target in targets) target?.OnCollisionEnter2D(coll);
        }

        public void OnCollisionExit2D(Collision2D coll)
        {
            foreach (var target in targets) target?.OnCollisionExit2D(coll);
        }

        public void OnCollisionStay2D(Collision2D coll)
        {
            foreach (var target in targets) target?.OnCollisionStay2D(coll);
        }

        public void OnTriggerEnter2D(Collider2D coll)
        {
            foreach (var target in targets) target?.OnTriggerEnter2D(coll);
        }

        public void OnTriggerExit2D(Collider2D coll)
        {
            foreach (var target in targets) target?.OnTriggerExit2D(coll);
        }

        public void OnTriggerStay2D(Collider2D coll)
        {
            foreach (var target in targets) target?.OnTriggerStay2D(coll);
        }
    }
}
