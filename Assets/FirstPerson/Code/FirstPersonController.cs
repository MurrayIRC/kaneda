using UnityEngine;

public class FirstPersonController : MonoBehaviour {
	[Header("Component References")]
	[SerializeField] private new Camera camera;
	[SerializeField] private new Rigidbody rigidbody;

	[Header("Camera")]
	[SerializeField] private Vector2 clamp = new Vector2(360f, 180f);
	[SerializeField] private Vector2 sensitivity = new Vector2(2f, 2f);
	[SerializeField] private Vector2 smoothing = new Vector2(3f, 3f);

	[Header("Movement")]
	[SerializeField] private float maxMoveSpeed;
	[SerializeField] private float moveSmoothTime;

	// Private camera values.
	private Vector2 mouseDelta;
	private Vector2 targetCameraDirection;
	private Vector2 smoothMouse;
	private Vector2 mouseAbsolute;

	// Private movement values
	private Vector3 unscaledMoveDirection;
	private Vector3 scaledMoveDirection;
	private Vector3 lastMoveDirection;
	private float moveSpeed;
	private float moveDampVelocity;

	private void Awake() {
		// Set target camera direction to the camera's initial orientation.
		targetCameraDirection = camera.transform.localRotation.eulerAngles;
	}

	#region Movement

	private void Update() {
		// Feed input values into a raw move direction vector.
		unscaledMoveDirection.x = Managers.Input.MoveDirection.x;
		unscaledMoveDirection.y = 0f;
		unscaledMoveDirection.z = Managers.Input.MoveDirection.y;
		unscaledMoveDirection = transform.TransformDirection(unscaledMoveDirection);

		// Calculate the current move speed scalar, and dampen it towards 0 or the max depending on input.
		if (Managers.Input.MoveDirection.sqrMagnitude > Mathf.Epsilon * Mathf.Epsilon) { // Acceleration
			moveSpeed = Mathf.SmoothDamp(moveSpeed, maxMoveSpeed, ref moveDampVelocity, moveSmoothTime);

			// Scale the direction by the speed scalar and via time delta.
			scaledMoveDirection = unscaledMoveDirection * moveSpeed * Time.deltaTime;
			
			// Store the latest unscaled move direction for use during deceleration.
			lastMoveDirection = unscaledMoveDirection;
		}
		else if (moveSpeed > Mathf.Epsilon) { // Deceleration
			moveSpeed = Mathf.SmoothDamp(moveSpeed, 0f, ref moveDampVelocity, moveSmoothTime);

			// Scale the direction by the speed scalar and via time delta.
			scaledMoveDirection = lastMoveDirection * moveSpeed * Time.deltaTime;
		}
	}

	private void FixedUpdate() {
		// Apply the scaled move direction to the rigidbody.
		rigidbody.MovePosition(transform.position + scaledMoveDirection);
	}

	#endregion

	#region Camera

	private void LateUpdate() {
		mouseDelta = Managers.Input.MouseDelta;
		Quaternion targetOrientation = Quaternion.Euler(targetCameraDirection);
		
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
		camera.transform.localRotation = xRotation;
		
		// Then clamp and apply the global y value.
		if (clamp.y < 360)
			mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -clamp.y * 0.5f, clamp.y * 0.5f);
		
		camera.transform.localRotation *= targetOrientation;

		// Apply rotation to the character body.
		var yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
		transform.localRotation = yRotation;
	}

	#endregion
}
