using UnityEngine;

public class MoveCommand : UnitCommand
{
    public Vector3 Direction;

    public override void Apply(Unit unit)
    {
        unit.transform.position += Direction;
    }

    public MoveCommand(GlobalStateContext context) : base(context)
    {
    }
}