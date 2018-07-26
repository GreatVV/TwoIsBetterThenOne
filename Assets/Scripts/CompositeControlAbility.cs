using System.Collections.Generic;

public class CompositeControlAbility : IControlAbility
{
    private readonly GlobalStateContext _context;

    public CompositeControlAbility(GlobalStateContext context)
    {
        _context = context;
    }

    public List<IControlAbility> Abilities = new List<IControlAbility>();
    public UnitCommand Process(IController controller)
    {
        var compositeCommand = new CompositeCommand(_context);
        foreach (var controlAbility in Abilities)
        {
            var command = controlAbility.Process(controller);
            if (command != null)
            {
                compositeCommand.Commands.Add(command);
            }
        }

        return compositeCommand;
    }
}