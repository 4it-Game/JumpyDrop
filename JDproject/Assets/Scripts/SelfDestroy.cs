using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float time = 2;

	void Update () {
		time -= Time.deltaTime;
		if (time <= 0 && PlayerScript.PlayerInstance.canPlay) {
			Destroy (gameObject);
		}
	}
}
