using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	int score;
	int highscore;
	Text scoreText;
	Text highscoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		highscore = PlayerPrefs.GetInt ("Player_HighScore", 0);
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		highscoreText = GameObject.Find ("HighScoreText").GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (Jump2D.rb.position.y > score)
			score = (int)Jump2D.rb.position.y;

		scoreText.text	= "Score: " + score;
		highscoreText.text	= "HighScore: " + highscore;

		checkHighScore ();
		resetHighScore ();
	}

	public void checkHighScore() {
		if (score > highscore) {
			Debug.Log ("Score saved");

			PlayerPrefs.SetInt ("Player_HighScore", score);
		}
	}

	public void resetHighScore() {
		PlayerPrefs.DeleteAll();
	}
}
