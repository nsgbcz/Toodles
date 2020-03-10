using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct TagFilter : IFilter<string>, IFilter<GameObject>, IFilter<Collider2D>, IFilter<Collider>, IFilter<Collision2D>, IFilter<Collision>
    {
        [SerializeField]
        string[] tags;

        public bool Filter(string tag)
        {
            return tags.Contains(tag);
        }
        public bool Filter(Collider2D subject)
        {
            return Filter(subject.tag);
        }
        public bool Filter(Collider subject)
        {
            return Filter(subject.tag);
        }
        public bool Filter(Collision2D subject)
        {
            return Filter(subject.gameObject.tag);
        }
        public bool Filter(Collision subject)
        {
            return Filter(subject.gameObject.tag);
        }
        public bool Filter(GameObject subject)
        {
            return Filter(subject.tag);
        }
    }
    public struct LayerFilter : IFilter<int>, IFilter<GameObject>, IFilter<Collider2D>, IFilter<Collider>, IFilter<Collision2D>, IFilter<Collision>
    {
        [SerializeField]
        LayerMask layer;
        public bool Filter(int layer)
        {
            return this.layer.value == (this.layer.value | (1 << layer));
        }
        public bool Filter(Collider2D subject)
        {
            return Filter(subject.gameObject.layer);
        }
        public bool Filter(Collider subject)
        {
            return Filter(subject.gameObject.layer);
        }
        public bool Filter(Collision2D subject)
        {
            return Filter(subject.gameObject.layer);
        }
        public bool Filter(Collision subject)
        {
            return Filter(subject.gameObject.layer);
        }
        public bool Filter(GameObject subject)
        {
            return Filter(subject.layer);
        }
    }
}