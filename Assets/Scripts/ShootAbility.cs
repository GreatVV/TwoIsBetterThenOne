using UnityEngine;

public class ShootAbility : IControlAbility
{
    private readonly GlobalStateContext _context;

    public ShootAbility(GlobalStateContext context)
    {
        _context = context;
    }

    public UnitCommand Process(IController controller)
    {
        var state = controller.Get;
        if (state.NeedShoot)
        {
            var process = new ShootCommand(_context);
            process.ScreenPosition = new Vector3(state.X, state.Y);
            Debug.Log("PositioN: "+process.ScreenPosition);
            return process;
        }
        return null;
    }
}