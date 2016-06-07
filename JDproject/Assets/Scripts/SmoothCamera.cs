using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	public Transform target;

	private bool smooth = false;
	private float smoothSpeed = 0.125f;
	private Vector3 offset = new Vector3(0,5, -63.9f);

	private void LateUpdate () {
		
		if (target != null) {
			Vector3 desiredPosition = target.transform.position + offset;
			desiredPosition.x = 0;
			transform.position = desiredPosition;

			if (smooth) {
				transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
			} else {
				transform.position = desiredPosition;
			}
		}


	}
}
