public abstract class UnitCommand
{
    public readonly GlobalStateContext _context;

    public UnitCommand(GlobalStateContext context)
    {
        _context = context;
    }

    public abstract void Apply(Unit unit);
}