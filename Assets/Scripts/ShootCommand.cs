using UnityEngine;

public class ShootCommand : UnitCommand
{
    public Vector3 ScreenPosition = new Vector3();

    public override void Apply(Unit unit)
    {
        var ray = Camera.main.ScreenPointToRay(ScreenPosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            var position = hitInfo.point;
            var direction = position - unit.transform.position;
            var bullet = Object.Instantiate(_context.BulletPrefab, unit.transform.position, Quaternion.identity);
            direction.y = 0;
            bullet.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public ShootCommand(GlobalStateContext context) : base(context)
    {
    }
}