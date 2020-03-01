/*
using UnityEngine;
using UnityEngine.Monetization;

namespace BP
{
    public class ADSExecute : Execute
    {
        public MyEnumMask eventMask = new MyEnumMask(typeof(ShowResult));

        public void Action(ShowResult result)
        {
            Debug.Log(result);
            if (eventMask.IsExecuteAble(result)) Action();
        }
    }
}*/