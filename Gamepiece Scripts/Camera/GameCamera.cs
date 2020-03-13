using System.Collections;
using System.Collections.Generic;
using UE = UnityEngine;
using UnityEngine;

namespace Game.Camera 
{
    public static class GameCamera
    {
        static UE.Camera _get;
        public static UE.Camera Get
        {
            get
            {
                if (_get == null)
                {
                    _get = UE.Camera.main;
                }
                return _get;
            }
        }

        public static Vector3 ScreenToWorld(Vector2 pos)
        {
            return Get.ScreenToWorldPoint(pos, UE.Camera.MonoOrStereoscopicEye.Mono);
        }
    } 
}
