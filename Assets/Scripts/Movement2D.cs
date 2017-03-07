using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {

	public string axis = "Horizontal";
	public float speed = 8f;
	private Rigidbody2D _rb;
    private SpriteRenderer _sr;


	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	    _sr = GetComponent<SpriteRenderer>();
	}
	// Update is called once per frame
	void Update () {
		
		// Allows player to move  using left and right arrows
		var h = Input.GetAxis(axis);
		// Updates player's position
		_rb.velocity = new Vector2 (h * speed, _rb.velocity.y);

	    // Flip sprite horizontally
	    if (_rb.velocity.x < 0) _sr.flipX = true;
	    else if (_rb.velocity.x > 0) _sr.flipX = false;
	}
}
