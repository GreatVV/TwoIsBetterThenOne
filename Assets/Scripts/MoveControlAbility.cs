using System;
using UnityEngine;

public class MoveControlAbility : IControlAbility
{
    private readonly GlobalStateContext _context;

    public MoveControlAbility(GlobalStateContext context)
    {
        _context = context;
    }

    public UnitCommand Process(IController Controller)
    {
        var x = Controller.Get.X;
        var y = Controller.Get.Y;
        if (Math.Abs(x) > 0.01f || Math.Abs(y) > 0.01f)
        {
            return new MoveCommand(_context)
            {
                Direction = new Vector3(x, 0, y)
            };
        }

        return null;
    }
}