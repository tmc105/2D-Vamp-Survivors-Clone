using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target; // Reference to the player's Transform component.
	public float smoothSpeed = 0.125f; // How smoothly the camera follows the player.
	public Vector3 offset; // Offset between the player and the camera.

	void LateUpdate()
	{
		if (target != null)
		{
			// Calculate the desired camera position.
			Vector3 desiredPosition = target.position + offset;

			// Use SmoothDamp to gradually move the camera towards the desired position.
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

			// Set the camera's position to the smoothed position.
			transform.position = smoothedPosition;
		}
	}
}
