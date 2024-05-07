using Input_Feature;
using UnityEngine;
using WKosArch;

public class JoystickHudModel : HudViewModel
{
    private IInputFeature _inputFeature => DiContainer.Resolve<IInputFeature>();

    public void JoystickMoved(Vector2 vector2)
    {
        _inputFeature.JoystickDirectionVector(vector2);
    }
}
