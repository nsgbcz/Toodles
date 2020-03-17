using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using System.Collections;

namespace Toodles.Gamepiece.Input
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

        [BoxGroup("System data"), SerializeField, Required]
        IGet<int> Index = new Value<int>();

        [BoxGroup("Joystick Settings"), SerializeField]
        JoystickType Type;
        [BoxGroup("Joystick Settings"), SerializeField]
        bool ResetPositionWhenUp;

        [SerializeField, Required] RectTransform Background;
        [SerializeField, Required] RectTransform Handle;
        [SerializeField, Required] float HandleRange;

        int pointerId;
        bool pressed;

        Vector2 _input;

        Vector2 _startPos;
        Vector2 _radius;
        int _index;
        RectTransform _baseRect;
        Canvas _canvas;
        UnityEngine.Camera _camera = null;

        void SetData(Vector2 value)
        {
            data[_index] = value;
        }

        void Start()
        {
            _baseRect = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            if (_canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
                _camera = GameCamera.Get;

            Vector2 center = new Vector2(0.5f, 0.5f);

            var midAnch = Vector2.zero;
            var anch = Background.anchorMin;
            midAnch.x = (anch.x + anch.y) / 2f;
            anch = Background.anchorMax;
            midAnch.y = (anch.x + anch.y) / 2f;
            anch = center - anch;
            
            Background.anchorMin = center;
            Background.anchorMax = center;
            Background.pivot = center;
            _startPos = Background.anchoredPosition -= anch * _baseRect.rect.size;

            Handle.anchorMin = center;
            Handle.anchorMax = center;
            Handle.pivot = center;
            Handle.anchoredPosition = Vector2.zero;

            _radius = Background.sizeDelta / 2;
            _index = Index.Value;
            if(!data.ContainsKey(_index)) data.Add(_index, Vector2.zero);

            if(Type == JoystickType.Static || ResetPositionWhenUp)
                Background.gameObject.SetActive(true);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (pressed) return;

            if (Type != JoystickType.Static)
            {
                Background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            }

            Background.gameObject.SetActive(true);
            pressed = true;
            pointerId = eventData.pointerId;
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (pointerId != eventData.pointerId) return;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(_camera, Background.position);
            
            _input = (eventData.position - position) / (_radius * _canvas.scaleFactor);

            HandleInput(_input.magnitude, _input.normalized, _radius);

            Handle.anchoredPosition = _input * _radius * HandleRange;
            SetData(_input);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!pressed || pointerId != eventData.pointerId) return;
            if (Type == JoystickType.Static)
                Handle.anchoredPosition = Vector2.zero;
            else if (ResetPositionWhenUp)
            {
                Background.anchoredPosition = _startPos;
                Handle.anchoredPosition = Vector2.zero;
            }
            else
                Background.gameObject.SetActive(false);

            pressed = false;
            SetData(Vector2.zero);
        }

        void HandleInput(float magnitude, Vector2 normalized, Vector2 radius)
        {
            if (Type == JoystickType.Floating && magnitude > HandleRange)
            {
                Vector2 difference = normalized * (magnitude - HandleRange) * radius;
                Background.anchoredPosition += difference;
            }
            if (magnitude > 1)
                _input = normalized;
        }

        Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _camera, out Vector2 localPoint))
            {
                Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
                return localPoint - (Background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }
    }
}
