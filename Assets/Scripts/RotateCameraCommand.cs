using UnityEngine;

public class RotateCameraCommand : UnitCommand
{
    public Vector3 Delta;
    private Vector3 offsetX;
    private Vector3 offsetY;

    public RotateCameraCommand(GlobalStateContext context) : base(context)
    {
        offsetX = new Vector3 (0, _context.Player1Config.CameraHeight, _context.Player1Config.CameraDistance);
        offsetY = new Vector3 (0, 0, _context.Player1Config.CameraDistance);
    }

    public override void Apply(Unit unit)
    {
        offsetX = Quaternion.AngleAxis (Delta.x, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis (Delta.y, Vector3.right) * offsetY;
        unit.CameraTransform.transform.position = unit.transform.position + offsetX + offsetY;
        unit.CameraTransform.transform.LookAt(unit.transform.position);
    }
}