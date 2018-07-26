using UnityEngine;

public class JumpControlAbility : IControlAbility
{
    private readonly GlobalStateContext _context;
    private readonly JumpConfig _jumpConfig;

    private float MinJumpPower => _jumpConfig.MinJumpPower;
    private float MinJumpTime => _jumpConfig.MinJumpTime;
    private float JumpPowerDelta => _jumpConfig.JumpPowerDelta;
    private float MaxJumpTime => _jumpConfig.MaxJumpTime;

    public JumpControlAbility(GlobalStateContext context, JumpConfig jumpConfig)
    {
        _context = context;
        _jumpConfig = jumpConfig;
    }

    public UnitCommand Process(IController controller)
    {
        var state = controller.Get;
        if (state.WantJump)
        {
            var jumpTime = state.JumpPressTime;
            var process = new JumpCommand(_context);
            if (jumpTime < MinJumpTime)
            {
                process.JumpPower = MinJumpPower;
            }
            else
            {
                process.JumpPower = MinJumpPower + Mathf.Clamp01((jumpTime - MinJumpTime) / (MaxJumpTime - MinJumpTime)) * JumpPowerDelta;

            }
            return process;
        }

        return null;
    }
}