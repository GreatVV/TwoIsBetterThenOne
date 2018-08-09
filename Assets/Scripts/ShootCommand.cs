using UnityEngine;

public class ShootCommand : UnitCommand
{
    public Vector3 ScreenPosition = new Vector3();

    public override void Apply(Unit unit)
    {
        var direction = unit.Weapon.Direction;
        var bullet = Object.Instantiate(_context.BulletPrefab, unit.Weapon.SpawnBulletPosition, Quaternion.identity);
        direction.y = 0;
        bullet.transform.rotation = Quaternion.LookRotation(direction);
    }

    public ShootCommand(GlobalStateContext context) : base(context)
    {
    }
}