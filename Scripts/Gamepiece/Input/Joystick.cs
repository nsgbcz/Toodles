using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

namespace Toodles.Gamepiece.Input
{
    using Camera;
    public class Joystick : SerializedMonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField, Required] RectTransform background;
        [SerializeField, Required] RectTransform handle;
        [SerializeField, Required] float handleRange;

        int pointerId;
        bool pressed;

        Vector2 input;
        RectTransform baseRect;
        Canvas canvas;
    new UnityEngine.Camera camera = null;

        void Start()
        {
            baseRect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                camera = GameCamera.Get;

            Vector2 center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (pressed) return;

            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);

            pressed = true;
            pointerId = eventData.pointerId;
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (pointerId != eventData.pointerId) return;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(camera, background.position);
            Vector2 radius = background.sizeDelta / 2;
            input = (eventData.position - position) / (radius * canvas.scaleFactor);

            HandleInput(input.magnitude, input.normalized, radius);

            handle.anchoredPosition = input * radius * handleRange;

            //UpdateDirection(input);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!pressed || pointerId != eventData.pointerId) return;

            background.gameObject.SetActive(false);
            pressed = false;
            //UpdateDirection(float2.zero);
        }

        void HandleInput(float magnitude, Vector2 normalized, Vector2 radius)
        {
            /*if (magnitude > handleRange)
            {
                Vector2 difference = normalized * (magnitude - handleRange) * radius;
                background.anchoredPosition += difference;
            }*/
            if (input.magnitude > 1)
                input = input.normalized;
        }

        Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, camera, out localPoint))
            {
                Vector2 pivotOffset = baseRect.pivot * baseRect.sizeDelta;
                return localPoint - (background.anchorMax * baseRect.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }
        /*void UpdateDirection(float2 direction)
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entities = this.entities.Value;

            for (int i = 0; i < entities.Count; i++)
            {
                entityManager.SetComponentData<InputDirectionData>(entities[i], direction);
            }
        }*/
    }
}
