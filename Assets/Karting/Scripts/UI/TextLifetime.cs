using System.Collections;
using System.Diagnostics;

using TMPro;

using UnityEngine;

public class TextLifetime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMesh;
    [SerializeField] private AnimationCurve m_AlphaCurve;
    [SerializeField] private AnimationCurve m_SizeCurve;
    [SerializeField] private float m_ImpulseSize = 10f;
    private Color m_DefaultColor;
    private float m_DefaultFontSize;
    private float m_ProcessTime = 0;

    public void OnEnable()
    {
        m_DefaultColor = m_TextMesh.color;
        m_DefaultFontSize = m_TextMesh.fontSize;
    }

    public void SetText(string text)
    {
        m_TextMesh.color = m_DefaultColor;
        m_TextMesh.fontSize = m_DefaultFontSize;
        m_TextMesh.text = text;
        m_ProcessTime = 0;
    }

    private void Update()
    {
        if (m_TextMesh.color.a > 0)
        {
            m_ProcessTime += Time.deltaTime;

            float a = m_AlphaCurve.Evaluate(m_ProcessTime);
            float size = m_SizeCurve.Evaluate(m_ProcessTime);
            m_TextMesh.color = new Color(m_TextMesh.color.r, m_TextMesh.color.g, m_TextMesh.color.b, a);
            m_TextMesh.fontSize = m_DefaultFontSize - size* m_ImpulseSize;
        }
        else
        {
            gameObject.SetActive(false);
            m_TextMesh.color = m_DefaultColor;
            m_TextMesh.fontSize = m_DefaultFontSize;
        }
    }

}
