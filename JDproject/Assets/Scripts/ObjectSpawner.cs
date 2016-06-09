using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	public GameObject powerUp;
	public Transform[] objects;
	public Transform spwaner;
	public float maxPos = 12f;

	public float delayTimer = 1f;
	float timer;

	void Start () {

		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0 && PlayerScript.PlayerInstance.canPlay) {
			Vector3 objPos = new Vector3 (Random.Range(-3.6f, 3.6f), spwaner.position.y, 0);
			int ramIndx = Random.Range (0, objects.Length);
			for(int i =0; i < objects.Length; i++)
				Instantiate (objects[ramIndx], objPos, transform.rotation);
			timer = delayTimer;
		}
	}

}
