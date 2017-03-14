using UnityEngine;
using System.Collections;

public class FallEnd : GameEnding
{
	public Camera playerCamera;
	public GameObject player;
	public string id;

	void Update ()
	{
		if (playerCamera.WorldToViewportPoint (player.transform.position).y < 0f) {
			onGameEnd (string.Format("O jogador {0} caiu das plataformas!", id));
		}
	}
}

