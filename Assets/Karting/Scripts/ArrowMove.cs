using UnityEngine;

namespace UnityEngine.U2D
{

    public class ArrowMove : MonoBehaviour
    {
        [SerializeField] private Joystick m_Joystick;
        private ParticleSystem m_Partical;
        private void Start()
        {
            m_Partical = GetComponent<ParticleSystem>();
        }
        private void Update()
        {
            var overLifetime = m_Partical.velocityOverLifetime;
            overLifetime.orbitalZ = -m_Joystick.direction.x;
            var rotationLifetime = m_Partical.rotationOverLifetime;
            rotationLifetime.z = m_Joystick.direction.x * Mathf.PI / 2;

        }


    }
}
