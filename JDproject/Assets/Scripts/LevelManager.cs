using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance{ set; get; }

	private int hitPoint = 3;
	private int score = 0;

	public Transform spawnPosition;
	public Transform player;

	void Start(){
		Instance = this;
	}

	private void Update(){
		if (player.position	.y < -10) {
			player.position = spawnPosition.position;
			hitPoint--;
			if (hitPoint <= 0) {
				Debug.Log ("Ohhh Hell!");
			}

		}
	}

	public void Win(){
		Debug.Log ("Victory");
	}
}
