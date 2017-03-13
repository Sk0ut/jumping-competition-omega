using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public float JumpHeight = 450f;

	// Object which will check if the player is on the ground
	public Transform CheckGround;
	public Rigidbody2D Rb;
    private bool _onGround;

    public static event EventManager.EventAction OnPlayerJump;

    private void Start()
	{
		Rb = GetComponent<Rigidbody2D>();
		_onGround = false;
	}

    private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Plataform_static") || coll.gameObject.CompareTag("Plataform_move")) {
			_onGround = true;
		}
	}

    private void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Plataform_static") || coll.gameObject.CompareTag("Plataform_move")) {
			_onGround = false;
		}
	}

    private void FixedUpdate () {
		if (_onGround && Rb.velocity.y <= 0)
		{
		    if (OnPlayerJump != null) OnPlayerJump();
		    Rb.velocity = new Vector2 (0, 0);
			Rb.AddForce (new Vector2 (0, JumpHeight));
		}
	}
}
