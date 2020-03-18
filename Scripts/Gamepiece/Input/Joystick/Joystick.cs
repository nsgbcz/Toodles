using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using System.Collections;

namespace Toodles.Gamepiece.Input.Joystick
{
    using Camera;

    public class Joystick : SerializedMonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public enum JoystickType { Static, Dynamic, Floating }

        static Dictionary<int, Vector2> data = new Dictionary<int, Vector2>();
        public static Vector2 GetData(int i)
        {
            return data[i];
        }
        [SerializeField, Required]
        IGet<int> Index = new Val<int>();
        [SerializeField, Required]
        Visual Visual = new Visual();
        [SerializeField, Required]
        IGet<float> HandleRange = new Val<float>();

        [SerializeField, BoxGroup("Behaviour"), Required]
        IStartSetting[] StartSettings = new IStartSetting[0];
        [SerializeField, BoxGroup("Behaviour"), Required]
        IHandleBegin[]  HandleBegin = new IHandleBegin[0];
        [SerializeField, BoxGroup("Behaviour"), Required]
        IHandleInput[]  HandleInput = new IHandleInput[0];
        [SerializeField, BoxGroup("Behaviour"), Required]
        IHandleOutput[] HandleOutput = new IHandleOutput[0];
        [SerializeField, BoxGroup("Behaviour"), Required]
        IHandleEnd[]    HandleEnd= new IHandleEnd[0];


        InternalSettings internalSettings;

        int pointerId;
        bool pressed;

        void SetData(Vector2 value)
        {
            data[internalSettings.index] = value;
        }

        void Start()
        {
            internalSettings.canvas = GetComponentInParent<Canvas>();
            if (internalSettings.canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");
            if (internalSettings.canvas.renderMode == RenderMode.ScreenSpaceCamera)
                internalSettings.camera = GameCamera.Get;


            internalSettings.index = Index.Value;
            internalSettings.handleRange = HandleRange.Value;

            for (int i = 0; i < StartSettings.Length; i++)
            {
                StartSettings[i].Set(Visual, ref internalSettings);
            }

            internalSettings.radius = Visual.Background.sizeDelta / 2;

            if (!data.ContainsKey(internalSettings.index)) data.Add(internalSettings.index, Vector2.zero);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (pressed) return;

            var pos = eventData.position;

            for (int i = 0; i < HandleBegin.Length; i++)
            {
                HandleBegin[i].Handle(Visual, internalSettings, pos);
            }

            pressed = true;
            pointerId = eventData.pointerId;
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (pointerId != eventData.pointerId) return;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(internalSettings.camera, Visual.Background.position);
            
            var input = (eventData.position - position) / (internalSettings.radius * internalSettings.canvas.scaleFactor);

            var meta = new InputMeta(input);
            for (int i = 0; i < HandleInput.Length; i++)
            {
                HandleInput[i].Handle(Visual, internalSettings, ref meta);
            }
            var output = meta.vector;

            Visual.Handle.anchoredPosition = output * internalSettings.radius;// * internalSettings.handleRange;

            for (int i = 0; i < HandleOutput.Length; i++)
            {
                HandleOutput[i].Handle(ref output);
            }

            SetData(output);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!pressed || pointerId != eventData.pointerId) return;

            for (int i = 0; i < HandleEnd.Length; i++)
            {
                HandleEnd[i].Handle(Visual, internalSettings);
            }

            pressed = false;
            SetData(Vector2.zero);
        }
    }
}
