using KartGame.KartSystems;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DeviceInput : BaseInput
{
    [SerializeField] private Joystick m_Joystick;
    public override InputData GenerateInput()
    {
        return new InputData
        {
            Accelerate = m_Joystick.direction.y >= 0 && m_Joystick.isInput,
            Brake = m_Joystick.direction.y < 0,
            TurnInput = m_Joystick.direction.x
        };
    }
}
