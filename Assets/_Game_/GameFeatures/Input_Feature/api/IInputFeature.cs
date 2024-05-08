using System;
using UnityEngine;
using WKosArch.Domain.Features;

namespace Input_Feature
{
    public interface IInputFeature : IFeature
    {
        event Action<Vector2> OnJoystickVectorEvent;
        event Action<Vector2> OnMoveVectorEvent;

        void JoystickDirectionVector(Vector2 vector2);
        void MoveDirectionVector(Vector2 vector2);
    }
}