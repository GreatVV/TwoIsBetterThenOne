using UnityEngine;

public class MouseController : IController
{
    public ControllerState Get{ get; private set; }

    public void Update()
    {
        var state = new ControllerState();
        state.X = Input.mousePosition.x;
        state.Y = Input.mousePosition.y;
        state.NeedShoot = Input.GetMouseButtonDown(0);

        Get = state;
    }
}