using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public bool onGround;
	public static float jumpHeight = 450f;

	// Object which will check if the player is on the ground
	public Transform checkGround;
	public Rigidbody2D rb;

    public static event EventManager.EventAction OnPlayerJump;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		onGround = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Plataform_static") || coll.gameObject.CompareTag("Plataform_move")) {
			onGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Plataform_static") || coll.gameObject.CompareTag("Plataform_move")) {
			onGround = false;
		}
	}

	void FixedUpdate () {
		if (onGround && rb.velocity.y <= 0)
		{
		    if (OnPlayerJump != null) OnPlayerJump();
		    rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (0, jumpHeight));
		}
	}
}
