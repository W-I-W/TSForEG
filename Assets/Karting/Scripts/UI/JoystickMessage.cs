using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMessage : MonoBehaviour
{
    [SerializeField] private Joystick m_Joystick;
    [SerializeField] private TextLifetime m_TextPrefab;

    [SerializeField, Space] private string m_IdForward;
    [SerializeField] private string m_IdBack;

    private TextLifetime m_TextGUI;

    private void OnEnable()
    {
        m_Joystick.OnDragHandle += OnDrag;
    }

    private void OnDisable()
    {
        m_Joystick.OnDragHandle -= OnDrag;
    }

    private void OnDrag(PointerEventData eventData)
    {
        float deltaY = 30; 
        if (eventData.delta.y > deltaY)
            SetMessage(m_IdForward);
        if (eventData.delta.y < -deltaY)
            SetMessage(m_IdBack);
    }

    private void SetMessage(string text)
    {
        if (m_TextGUI == null)
            m_TextGUI = Instantiate(m_TextPrefab, transform);

        m_TextGUI.gameObject.SetActive(true);
        m_TextGUI.SetText(text);

    }
}
