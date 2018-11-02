using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputManager : Manager {
    public Vector2 MouseDelta { get; private set; }

	public override void Startup() {
		managerState = ManagerState.Started;
    }

    private void Update() {
        MouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }

	public override void Shutdown() {
        managerState = ManagerState.Shutdown;
    }
}
