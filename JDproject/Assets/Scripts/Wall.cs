using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public Transform target;
	private float smoothSpeed = 0.125f;
	private float positionX;

	void Awake(){
		positionX = transform.position.x;
	}

	void Update(){
		if (target != null) {
			Vector3 desiredPosition = target.transform.position;
			desiredPosition.x = positionX;
			desiredPosition.z = 0;
			transform.position = desiredPosition;
			transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		}
	}
}
