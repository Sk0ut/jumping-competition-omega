using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceWin : GameEnding {

	public GameObject player1;
	public GameObject player2;
	public float maxDistance = 10f;

	public Text player1score;
	public Text player2score;


	void Update () {

		player1score.text = string.Format("Score: {0}", computeScore(player1.transform.position.y, player2.transform.position.y));
		player2score.text = string.Format("Score: {0}", computeScore(player2.transform.position.y, player1.transform.position.y));

		if (player1.transform.position.y - player2.transform.position.y > maxDistance) {
			//DontDestroyOnLoad (player2);
			onGameEnd ("O jogador 1 deixou o jogador 2 para trás!");
		} else if (player2.transform.position.y - player1.transform.position.y > maxDistance) {
			//DontDestroyOnLoad (player1);
			onGameEnd ("O jogador 2 deixou o jogador 1 para trás!");
		}
	}

	int computeScore(float pos1, float pos2) {
		return (int)((pos1 - pos2) / maxDistance * 100);
	}
}
