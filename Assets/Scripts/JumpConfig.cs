using System;

[Serializable]
public class JumpConfig
{
    public float MinJumpPower = 2f;
    public float MinJumpTime = 0.2f;
    public float JumpPowerDelta = 10f;
    public float MaxJumpTime = 1f;
}