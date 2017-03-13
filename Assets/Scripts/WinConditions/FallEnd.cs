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
			onGameEnd ("Player " + id + " fell down");
		}
	}
}

