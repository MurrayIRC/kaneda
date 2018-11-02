using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class InputManager : Manager {
    public Vector2 MouseLook { get; private set; }

	public override void Startup() {
		managerState = ManagerState.Started;
    }

    private void Update() {
        //MouseLook = new Vector2(, Mouse.current.delta.y.);
    }

	public override void Shutdown() {
        managerState = ManagerState.Shutdown;
    }
}
