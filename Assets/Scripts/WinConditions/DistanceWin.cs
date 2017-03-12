using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWin : GameEnding {

	public GameObject player1;
	public GameObject player2;
	public float maxDistance = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.transform.position.y - player2.transform.position.y > maxDistance) {
			onGameEnd ("Player 1 left player 2 behind");
		} else if (player2.transform.position.y - player1.transform.position.y > maxDistance) {
			onGameEnd ("Player 2 left player 1 behind");
		}
	}
}
