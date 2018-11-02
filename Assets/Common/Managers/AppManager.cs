using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Manager {
    [SerializeField] private CursorLockMode cursorState;

    public override void Startup() {
        QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

        Cursor.lockState = cursorState;

		managerState = ManagerState.Started;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // bring up the menu that has the quit option?

            if (cursorState == CursorLockMode.Locked) {
                bool isLocked = Cursor.lockState == CursorLockMode.Locked;
                Cursor.lockState = isLocked ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }

	public override void Shutdown() {
        managerState = ManagerState.Shutdown;
    }
}