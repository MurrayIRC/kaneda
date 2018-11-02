using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Manager {
	public override void Startup() {
		managerState = ManagerState.Started;
    }

	public override void Shutdown() {
        managerState = ManagerState.Shutdown;
    }
}
