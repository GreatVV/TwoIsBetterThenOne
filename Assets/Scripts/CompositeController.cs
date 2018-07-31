using System;

public class CompositeController : IInputController
{
    public readonly IInputController[] Controllers;
    public event Action<UnitCommand> Command;

    public CompositeController(IInputController[] controllers)
    {
        Controllers = controllers;
        foreach (var inputController in Controllers)
        {
            inputController.Command += x=> Command?.Invoke(x);
        }
    }

    public void Update()
    {
        foreach (var inputController in Controllers)
        {
            inputController.Update();
        }
    }
}