using UnityEngine;

public static class ControlHelpers
{
    public static Vector3 RotationAngle(Vector3 screenCoordinatesDelta, Vector3 screenSize, float mouseSensivity)
    {
        var rr = new Vector3(screenCoordinatesDelta.x / screenSize.x, screenCoordinatesDelta.y / screenSize.y, 0);

        return 360 * rr * mouseSensivity;
    }
}