using UnityEngine;

namespace BP
{
    public static class CameraHandler
    {
        static Camera _mainCamera;
        public static Camera MainCamera
        {
            get
            {
                if (_mainCamera == null) _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
        public static Vector2 ScreenToWorldPoint(Vector2 pos)
        {
            return _mainCamera.ScreenToWorldPoint(pos);
        }
    }
}
