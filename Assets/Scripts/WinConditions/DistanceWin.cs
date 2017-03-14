using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWin : GameEnding {

	public GameObject player1;
	public GameObject player2;
	public float maxDistance = 10f;

	void Update () {
		if (player1.transform.position.y - player2.transform.position.y > maxDistance) {
			//DontDestroyOnLoad (player2);
			onGameEnd ("O jogador 1 deixou o jogador 2 para trás!");
		} else if (player2.transform.position.y - player1.transform.position.y > maxDistance) {
			//DontDestroyOnLoad (player1);
			onGameEnd ("O jogador 2 deixou o jogador 1 para trás!");
		}
	}
}
