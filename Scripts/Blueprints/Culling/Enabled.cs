using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BP
{
    public class Enabled : Switcher
    {
        public GameObject[] preys;

        public bool revert = false;

        public override void OnIn()
        {
            foreach (var prey in preys) prey?.SetActive(!revert);
        }

        public override void OnOut()
        {
            foreach (var prey in preys) prey?.SetActive(revert);
        }

        //public override void Action()
        //{
        //    foreach (var prey in preys) prey.SetActive(!prey.activeSelf);
        //}
        [Button]
        public void ReplaceWithChildren()
        {
            var temp = new List<GameObject>();
            foreach (Transform item in transform)
            {
                temp.Add(item.gameObject);
            }
            preys = temp.ToArray();
        }
        [Button]
        public void AddChildren()
        {
            var temp = new List<GameObject>();
            foreach (Transform item in transform)
            {
                temp.Add(item.gameObject);
            }
            preys = preys.Add(temp.ToArray());
        }
    }
}
