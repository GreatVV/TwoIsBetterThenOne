using System;

public class PlayerInputController : IInputController
{
    private IController Controller;
    private IControlAbility ControlAbility;

    public PlayerInputController(IController controller, IControlAbility controlAbility)
    {
        Controller = controller;
        ControlAbility = controlAbility;
    }

    public event Action<UnitCommand> Command;

    public void Update()
    {
        Controller.Update();
        var command = ControlAbility.Process(Controller);
        if (command != null)
        {
            Command?.Invoke(command);
        }
    }
}