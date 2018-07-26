using System.Collections.Generic;

public class CompositeCommand : UnitCommand
{
    public List<UnitCommand> Commands = new List<UnitCommand>();

    public CompositeCommand(GlobalStateContext context) : base(context)
    {
    }

    public override void Apply(Unit unit)
    {
        foreach (var unitCommand in Commands)
        {
            unitCommand.Apply(unit);
        }
    }
}