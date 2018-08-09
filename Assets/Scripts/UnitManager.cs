using System;
using System.Collections.Generic;

public class UnitManager
{
    public static UnitManager Instance;
    public Dictionary<int, Unit> Units = new Dictionary<int, Unit>();

    public Unit GetById(int unitId)
    {
        return Units[unitId];
    }

    public void AddUnit(Unit unit)
    {
        unit.UnitID = Units.Count;
        Units[unit.UnitID] = unit;
    }
}