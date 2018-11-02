using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Decide how we wanna set up this class.
public class SettingsManager : Manager {

	public override void Startup() {
		managerState = ManagerState.Started;
    }

	public override void Shutdown() {
        managerState = ManagerState.Shutdown;
    }
}