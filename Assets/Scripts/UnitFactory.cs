using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class UnitFactory
{
    private readonly GlobalStateContext _context;
    private readonly IControllerFactory _controllerFactory;

    public UnitFactory(GlobalStateContext context, IControllerFactory controllerFactory)
    {
        _context = context;
        _controllerFactory = controllerFactory;
    }

    public Unit CreateUnit()
    {
        var unit = Object.Instantiate(_context.UnitPrefab);
        unit.PartOne = _controllerFactory.GetFirstPlayer();
        unit.PartOne.Command += unit.OnCommand;
        unit.PartTwo = _controllerFactory.GetSecondPlayer();
        unit.PartTwo.Command += unit.OnCommand;
        unit.GetComponentInChildren<CameraController>().target = unit.transform;

        return unit;
    }
}