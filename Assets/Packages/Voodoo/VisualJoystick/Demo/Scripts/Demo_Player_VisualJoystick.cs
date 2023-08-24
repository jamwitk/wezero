using UnityEngine;

namespace Voodoo.Visual.UI
{
    public class Demo_Player_VisualJoystick : MonoBehaviour
    {
        public VisualJoystick   m_Joystick;
        public Transform        m_PositionTr;
        public Transform        m_DirectionTr;
        public float            m_Amplitude;

    	void Update ()
        {
            Vector2 joystickPosition = m_Joystick.GetJoystickPosition() * m_Amplitude;
            Vector2 joystickDirection = m_Joystick.GetJoystickDirection() * m_Amplitude;
            m_PositionTr.localPosition = new Vector3(joystickPosition.x, 0.0f, joystickPosition.y);
            m_DirectionTr.localPosition = new Vector3(joystickDirection.x, 0.0f, joystickDirection.y);
        }
    }
}
