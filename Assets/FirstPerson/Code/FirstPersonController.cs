using UnityEngine;

public class FirstPersonController : MonoBehaviour {
	[Header("Camera")]
	[SerializeField] private Camera camera;
	[SerializeField] private Vector2 clamp = new Vector2(360f, 180f);
	[SerializeField] private Vector2 sensitivity = new Vector2(2f, 2f);
	[SerializeField] private Vector2 smoothing = new Vector2(3f, 3f);

	[Header("Movement")]
	[SerializeField] private float moveSpeed;

	// Private camera values.
	private Vector2 targetDirection;
	private Vector2 smoothMouse;
	private Vector2 mouseAbsolute;

	// Private movement values

	private void Awake() {
		// Set target direction to the camera's initial orientation.
		targetDirection = transform.localRotation.eulerAngles;
	}

	// Movement Code
	private void Update() {
		
	}

	// Camera Code
	private void LateUpdate() {
		Vector2 mouseDelta = Managers.Input.MouseDelta; // Poll input.
		
		Quaternion targetOrientation = Quaternion.Euler(targetDirection);
		
		// Scale input against the sensitivity setting and multiply that against the smoothing value.
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));
		
		// Interpolate mouse movement over time to apply smoothing delta.
		smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
		smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / smoothing.y);
		
		// Find the absolute mouse movement value from point zero.
		mouseAbsolute += smoothMouse;
		
		// Clamp and apply the local x value first, so as not to be affected by world transforms.
		if (clamp.x < 360f)
			mouseAbsolute.x = Mathf.Clamp(mouseAbsolute.x, -clamp.x * 0.5f, clamp.x * 0.5f);
		
		var xRotation = Quaternion.AngleAxis(-mouseAbsolute.y, targetOrientation * Vector3.right);
		transform.localRotation = xRotation;
		
		// Then clamp and apply the global y value.
		if (clamp.y < 360)
			mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -clamp.y * 0.5f, clamp.y * 0.5f);
		
		transform.localRotation *= targetOrientation;
		
		var yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
		transform.localRotation *= yRotation;
	}
}
