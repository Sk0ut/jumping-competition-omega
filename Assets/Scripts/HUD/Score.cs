using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	int score;
	Text scoreText;
	public GameObject player;

	// Use this for initialization
	void Start () {
		score = 0;
		string pl = "Score" + player.name;
		scoreText = GameObject.Find (pl).GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > score)
			score = (int) player.transform.position.y;

		scoreText.text	= "Score: " + score;
		resetHighScore ();
	}

	/*public void checkHighScore() {
		if (score > highscore) {

			PlayerPrefs.SetInt ("Player_HighScore", score);
		}
	}*/

	public void resetHighScore() {
		PlayerPrefs.DeleteAll();
	}
}