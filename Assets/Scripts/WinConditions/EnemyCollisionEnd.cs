﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class EnemyCollisionEnd : GameEnding {
	public string id;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Enemy")) {
			DontDestroyOnLoad (this.gameObject);
			onGameEnd ("Player " + id + " collided with an enemy");
		}
	}
}
