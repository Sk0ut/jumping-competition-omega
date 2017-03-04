using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public bool onGround;
	public float jumpHeight = 300f;
	public float groundRadius = .2f;	
	public LayerMask ground;

	// Object which will check if the player is on the ground
	public Transform checkGround;
	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		onGround = Physics2D.OverlapCircle (checkGround.position, groundRadius, ground);

		float velY = rb.velocity.y;

		if (onGround && velY <= 0) {
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (0, jumpHeight));
		}
	}
}
