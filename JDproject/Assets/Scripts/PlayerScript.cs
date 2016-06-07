using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	private int inputDir = 1;
	private float verticalVelocity;
	private Vector3 moveVector; 
	private CharacterController controller;
	private Transform thisTransform = null;
	public float moveSpeed = 2;
	public float clickForce = 10;
	public float gravity = 1;
	public static PlayerScript PlayerInstance;
	public GameObject DeathPartical = null;
	public bool canPlay = false;
	private ParticleEmitter dParti;

	void Awake () {
		PlayerInstance = this;
		thisTransform = GetComponent<Transform>();
	}

	void Start () {
		PlayerInstance = this;
		controller = GetComponent<CharacterController> ();
	}

	void Update() {
		if (canPlay) {
			if (Input.GetMouseButtonDown(0)) {
				inputDir = InputDirection (inputDir);
			}
			moveVector = new Vector3 (InputDirection (inputDir) * clickForce,gravity,0);
			controller.Move(moveVector * moveSpeed * Time.deltaTime);
		}

	}

	int InputDirection(int x){
		return x * -1;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit){
		//Collectables
		switch(hit.gameObject.tag){
		case "Obstical":
			Die ();
			break;
		case "Wall":
			LevelManager.Instance.SetScore ();
			break;
		case "PowerUp":
			PowerUp ();
			Destroy (hit.gameObject);
			break;
		default:
			break;
		}
	}

	public void PowerUp(){
		Debug.Log ("Player Can destroy Cubes, with partical");
		LevelManager.Instance.SetScore ();
	}

	public void Die(){

		canPlay = false;
		StartCoroutine (CameraShake.Shake (Camera.main.gameObject.transform, 0.1f));
		if (PlayerScript.PlayerInstance.DeathPartical != null) 
		{
			Instantiate (PlayerScript.PlayerInstance.DeathPartical,PlayerScript.PlayerInstance.thisTransform.position,PlayerScript.PlayerInstance.thisTransform.rotation);

		}
	}
}
