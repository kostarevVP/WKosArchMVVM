using System;
using UnityEngine;
using WKosArch.Domain.Features;

namespace Input_Feature
{
    public interface IInputFeature : IFeature
    {
        event Action<Vector2> OnJoystickVectorEvent;
        event Action<Vector3> OnMoveVectorEvent;

        void JoystickVector(Vector2 vector2);
        void MoveVector(Vector2 vector2);
    }
}