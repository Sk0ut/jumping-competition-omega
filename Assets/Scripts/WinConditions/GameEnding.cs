using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour {

	public void onGameEnd(string reason) {
		// change to end game screen
		Debug.Log("Game Finished: " + reason);
	}
}
