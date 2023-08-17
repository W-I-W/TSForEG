
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public UnityAction<PointerEventData> OnDragHandle;

    [SerializeField] private bool m_VisibleAtStartup = false;
    [SerializeField] private float m_HandleMaxDistance = 64;
    [SerializeField, Space] private RectTransform m_Background;
    [SerializeField] private RectTransform m_Handle;

    private RectTransform m_Joysick;
    private Camera m_Camera;


    public Vector2 direction { get; private set; }
    public bool isInput { get; private set; }

    private void Start()
    {
        m_Background.gameObject.SetActive(m_VisibleAtStartup);
        m_Camera = Camera.main;
        m_Joysick = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 position = ToLocalPointInRectangle(m_Joysick, eventData.position);
        m_Background.anchoredPosition = position;
        isInput = true;
        m_Background.gameObject.SetActive(isInput);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragHandle?.Invoke(eventData);
        Vector2 position = ToLocalPointInRectangle(m_Background, eventData.position);
        Vector2 distance = position.sqrMagnitude < m_HandleMaxDistance * m_HandleMaxDistance
            ? position
            : position.normalized * m_HandleMaxDistance;
        m_Handle.anchoredPosition = distance;
        direction = distance / m_HandleMaxDistance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isInput = false;
        m_Background.gameObject.SetActive(isInput);
        m_Handle.anchoredPosition = Vector2.zero;
        direction = Vector2.zero;
    }

    private Vector2 ToLocalPointInRectangle(RectTransform parentRect, Vector2 screenPoint)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, screenPoint, m_Camera, out Vector2 position);
        return position;
    }
}
