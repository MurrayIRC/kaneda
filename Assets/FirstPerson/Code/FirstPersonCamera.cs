using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {
	// TODO: surface these in a settings menu somehow. they'll probably need to be taken out of this class.
	private const float CLAMP_H = 360f;
	private const float CLAMP_V = 180f;
	private const float SENSITIVITY_H = 2.0f;
	private const float SENSITIVITY_V = 2.0f;
	private const float SMOOTHING_H = 3.0f;
	private const float SMOOTHING_V = 3.0f;

	private Vector2 targetDirection;
	private Vector2 smoothMouse;
	private Vector2 mouseAbsolute;

	private void Awake() {
		// Set target direction to the camera's initial orientation.
		targetDirection = transform.localRotation.eulerAngles;
	}

	void LateUpdate() {
		Vector2 mouseDelta = Managers.Input.MouseDelta; // Poll input.
		
		Quaternion targetOrientation = Quaternion.Euler(targetDirection);
		
		// Scale input against the sensitivity setting and multiply that against the smoothing value.
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(SENSITIVITY_H * SMOOTHING_H, SENSITIVITY_V * SMOOTHING_V));
		
		// Interpolate mouse movement over time to apply smoothing delta.
		smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / SMOOTHING_H);
		smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / SMOOTHING_V);
		
		// Find the absolute mouse movement value from point zero.
		mouseAbsolute += smoothMouse;
		
		// Clamp and apply the local x value first, so as not to be affected by world transforms.
		if (CLAMP_H < 360f)
			mouseAbsolute.x = Mathf.Clamp(mouseAbsolute.x, -CLAMP_H * 0.5f, CLAMP_H * 0.5f);
		
		var xRotation = Quaternion.AngleAxis(-mouseAbsolute.y, targetOrientation * Vector3.right);
		transform.localRotation = xRotation;
		
		// Then clamp and apply the global y value.
		if (CLAMP_V < 360)
			mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -CLAMP_V * 0.5f, CLAMP_V * 0.5f);
		
		transform.localRotation *= targetOrientation;
		
		var yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
		transform.localRotation *= yRotation;
	}
}
