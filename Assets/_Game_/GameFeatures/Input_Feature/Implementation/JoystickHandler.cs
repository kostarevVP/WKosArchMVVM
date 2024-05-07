using UnityEngine;
using UnityEngine.Events;

public class JoystickHandler : MonoBehaviour
{
    public UnityEvent<Vector2> OnJoystickMovevectorChange;

    [SerializeField]
    private VariableJoystick Joystick;

    private Vector2 previousMoveVector;

    void Update()
    {
        Vector2 currentMoveVector = Joystick.Direction;
        if (currentMoveVector != previousMoveVector)
        {
            previousMoveVector = currentMoveVector;
            OnJoystickMovevectorChange?.Invoke(currentMoveVector);
        }
    }
}
