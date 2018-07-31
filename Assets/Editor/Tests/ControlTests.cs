using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ControlTests {

    [Test]
    public void MouseControlTurnControl()
    {
        var screenSize = new Vector3(1000, 1000);
        var screenCoordinatesDelta = new Vector3(100, 0);
        var mouseSensivity = 1f;

        var rotationAngle = ControlHelpers.RotationAngle(screenCoordinatesDelta, screenSize, mouseSensivity);

        Assert.AreEqual(new Vector3(36, 0,0), rotationAngle);

    }


}
