using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour {

	public void onGameEnd(string reason) {
		// change to end game screen
		GameObject.FindGameObjectWithTag ("EndGameInfo").GetComponent<EndGameInfo>().reason = reason;
		SceneManager.LoadScene ("Scenes/EndGame");
	}
}
