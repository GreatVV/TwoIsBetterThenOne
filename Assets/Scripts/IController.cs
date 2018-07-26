public interface IController
{
    ControllerState Get { get; }
    void Update();
}

public struct ControllerState
{
    public float X;
    public float Y;
    public bool NeedShoot;
    public bool WantJump;
    public float JumpPressTime;
}