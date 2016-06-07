using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance{ set; get; }
	private int score = 0;
	public Text scoreText;
	public GameObject PlayerPanel;

	void Start(){
		Instance = this;
		Debug.Log ("Show Play Button");
	}

	public void SetScore(){
		score++;
		scoreText.text = score.ToString();
	}

	public void GameOver(){
		Debug.Log ("Desplay User Score");
	}

	public void PlayGame(){
		Debug.Log ("Play Game");
		PlayerScript.PlayerInstance.canPlay = true;
		PlayerPanel.SetActive (false);
	}

	public void Resume(){
		Debug.Log ("Resume Game");
	}

	public void Exit(){
		Application.Quit ();
	}

}
