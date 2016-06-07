using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuMannager : MonoBehaviour {

	public void ToGame(){
		SceneManager.LoadScene ("Game");
	}


	public void Exit(){
		Application.Quit ();
	}
}
