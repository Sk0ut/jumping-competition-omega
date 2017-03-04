using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {
		
		// Allows player to move  using left and right arrows
		float h = Input.GetAxis ("Horizontal");
		// Updates player's position
		rb.velocity = new Vector2 (h * speed, rb.velocity.y);
	}
}
