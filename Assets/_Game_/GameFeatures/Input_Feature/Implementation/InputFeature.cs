using System;
using UnityEngine;

namespace Input_Feature
{
    public class InputFeature : IInputFeature
    {
        private InputHandler _inputHandler;

        public InputFeature()
        {
            _inputHandler = InputHandler.CreateInstance();
            _inputHandler.Inject(this);
        }

        public event Action<Vector2> OnJoystickVectorEvent;
        public event Action<Vector2> OnMoveVectorEvent;


        public void MoveDirectionVector(Vector2 vector2)
        {
            OnMoveVectorEvent?.Invoke(vector2);
        }

        public void JoystickDirectionVector(Vector2 vector2)
        {
            OnJoystickVectorEvent?.Invoke(vector2);
        }
    }
}