using UnityEngine;

public class KeyBoardController : IController
{
    public ControllerState Get { get; private set; }
    private float _jumpDownButtonTime;

    public void Update()
    {
        var state = new ControllerState();

        state.X = Input.GetAxis("Horizontal");
        state.Y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            _jumpDownButtonTime = Time.realtimeSinceStartup;
        }
        else
        {
            if (Input.GetButtonUp("Jump"))
            {
                state.WantJump = true;
                state.JumpPressTime = Time.realtimeSinceStartup - _jumpDownButtonTime;
                Debug.Log("Jump Press time: " + state.JumpPressTime);
            }
        }

        Get = state;
    }
}