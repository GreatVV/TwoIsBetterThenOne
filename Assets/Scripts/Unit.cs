using UnityEngine;

public class Unit : MonoBehaviour
{
    public IInputController PartOne;
    public IInputController PartTwo;
    public Rigidbody Rigidbody;
    public Transform CameraTransform;
    public Weapon Weapon;
    public Health Health;
    public int UnitID;

    public void OnCommand(UnitCommand command)
    {
        command.Apply(this);
    }

    void Update()
    {
        PartOne.Update();
        PartTwo.Update();
    }
}