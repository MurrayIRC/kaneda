using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputManager : Manager {
    // MoveDirection and LookDirection are names that assume a specific method of control, but
    // they are named as such mostly to make it easy to understand what sorts of input should
    // be fed into them. For example, MoveDirection should always take input coming in from
    // places like the WASD keys on a keyboard, or the Left Analog Stick on a gamepad.
    public Vector2 MoveDirection { get; private set; }
    public Vector2 LookDirection { get; private set; }

    public Vector2 MouseDelta { get; private set; }

	public override void Startup() {
		managerState = ManagerState.Started;
    }

    private void Update() {
        MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }

	public override void Shutdown() {
        managerState = ManagerState.Shutdown;
    }
}
