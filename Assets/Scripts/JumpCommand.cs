using UnityEngine;

public class JumpCommand : UnitCommand
{
    public float JumpPower;

    public JumpCommand(GlobalStateContext context) : base(context)
    {
    }

    public override void Apply(Unit unit)
    {
        RaycastHit hitInfo;
        if (!unit.Rigidbody.SweepTest(Vector3.down, out hitInfo))
        {
            Debug.Log("Jump power: "+JumpPower);
            unit.Rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }
}