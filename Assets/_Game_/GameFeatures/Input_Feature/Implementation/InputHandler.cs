using UnityEngine;
using UnityEngine.InputSystem;
using WKosArch.Extentions;

namespace Input_Feature
{
    public class InputHandler : MonoBehaviour
    {
        private const string PrefabPath = "[InputHandler]";

        private Vector2 _throttleBrakeVector2;
        private Vector2 _wheelVector2;
        private IInputFeature _inputFeature;

        public static InputHandler CreateInstance()
        {
            var prefab = Resources.Load<InputHandler>(PrefabPath);
            var inputHandler = Instantiate(prefab);

            DontDestroyOnLoad(inputHandler.gameObject);

            return inputHandler;
        }

        public void Inject(IInputFeature inputFeature)
        {
            _inputFeature = inputFeature;
        }


        public void OnWheel(InputValue inputValue)
        {
            _wheelVector2 = inputValue.Get<Vector2>();

            var directionVector2 = _throttleBrakeVector2 + _wheelVector2;

            _inputFeature.MoveDirectionVector(directionVector2);
        }

        public void OnThrottleBrake(InputValue inputValue)
        {
            _throttleBrakeVector2 = inputValue.Get<Vector2>();

            var directionVector2 = _throttleBrakeVector2 + _wheelVector2;

            _inputFeature.MoveDirectionVector(directionVector2);
        }

        public void OnParkingBrake(InputValue inputValue)
        {
            var isPressed = inputValue.isPressed;

            //_inputFeature.OnParkingBrake(isPressed);
        }

        public void OnTouchStick(InputValue inputValue)
        {
            var vector2 = inputValue.Get<Vector2>();

            _inputFeature.JoystickDirectionVector(vector2);
        }
    }
}
