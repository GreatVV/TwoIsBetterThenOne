using UnityEngine;

public class RotationControlAbility : IControlAbility
{
    private readonly GlobalStateContext _context;

    private Vector3 _previousPosition;
    private Vector3 _screenSize;

    public RotationControlAbility(GlobalStateContext context)
    {
        _context = context;

        _screenSize = new Vector3(Screen.width, Screen.height);
    }

    public UnitCommand Process(IController controller)
    {
        var newPosition = new Vector3(controller.Get.X, controller.Get.Y);
        var delta = newPosition - _previousPosition;
        var sensitivity = _context.Player1Config.MouseSensitivity;
        delta = sensitivity * new Vector3(delta.x / _screenSize.x, - delta.y / _screenSize.y);

        return new RotateCameraCommand(_context)
        {
            Delta = delta
        };
    }
}