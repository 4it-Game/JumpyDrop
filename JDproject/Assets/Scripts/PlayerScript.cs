using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float moveSpeed = 2;
	public float clickForce = 10;
	public float gravity = 1;
	private int inputDir = 1;
	private float verticalVelocity;
	private Vector3 moveVector; 
	private CharacterController controller;
	private Transform thisTransform = null;
	public static PlayerScript PlayerInstance;
	public GameObject DeathPartical = null;

	void Awake () {
		thisTransform = GetComponent<Transform>();
	}

	void Start () {
		PlayerInstance = this;
		controller = GetComponent<CharacterController> ();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			inputDir = InputDirection (inputDir);
		}
		moveVector = new Vector3 (InputDirection (inputDir) * clickForce,gravity,0);
		controller.Move(moveVector * moveSpeed * Time.deltaTime);

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
		default:
			break;
		}
	}

	public static void Die(){

		if (PlayerScript.PlayerInstance.DeathPartical != null) 
		{
			
			Instantiate (PlayerScript.PlayerInstance.DeathPartical,PlayerScript.PlayerInstance.thisTransform.position,PlayerScript.PlayerInstance.thisTransform.rotation);
		}
		//Destroy (PlayerScript.PlayerInstance.gameObject);
	}
}
