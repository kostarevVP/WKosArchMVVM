using UnityEngine;
using WKosArch;
using WKosArch.Extentions;

public class JoystickHudModel : HudViewModel
{
   public void MoveJoystic(Vector2 vector2)
    {

        Log.PrintYellow($"MoveJoystick vector2={vector2}");
    }
}
