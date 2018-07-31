using UnityEngine;

public class MoveCommand : UnitCommand
{
    public Vector3 Direction;

    public override void Apply(Unit unit)
    {
        var camForward = Vector3.Scale(unit.CameraTransform.forward, new Vector3(1, 0, 1)).normalized;;
        var move = Direction.y*camForward + Direction.x*unit.CameraTransform.right;
        move = Vector3.ProjectOnPlane(move, Vector3.up);
        unit.transform.position += move;
    }

    public MoveCommand(GlobalStateContext context) : base(context)
    {
    }
}