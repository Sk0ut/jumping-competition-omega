using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public bool onGround;
	public float jumpHeight = 300f;

	// Object which will check if the player is on the ground
	public Transform checkGround;
	public static Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Ground")) {
			onGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Ground")) {
			onGround = false;
		}
	}

	void FixedUpdate () {
		if (onGround && rb.velocity.y <= 0) {
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (0, jumpHeight));
		}
	}
}
