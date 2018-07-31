﻿public class MockFactory : IControllerFactory
{
    private readonly GlobalStateContext _context;

    public MockFactory(GlobalStateContext context)
    {
        _context = context;
    }

    public IInputController GetFirstPlayer()
    {
        var contoller =  new CompositeControlAbility(_context);
        contoller.Abilities.Add(new MoveControlAbility(_context));
        contoller.Abilities.Add(new JumpControlAbility(_context, _context.Player1Config.JumpConfig));

        return new CompositeController(new[]
        {
            new PlayerInputController(new KeyBoardController(), contoller),
            new PlayerInputController(new MouseController(),new RotationControlAbility(_context) ),
        });

    }

    public IInputController GetSecondPlayer()
    {
        return new PlayerInputController(new MouseController(), new ShootAbility(_context));
    }
}