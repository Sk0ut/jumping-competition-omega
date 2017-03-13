using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public float JumpHeight = 450f;

	// Object which will check if the player is on the ground
	public Transform CheckGround;
	public Rigidbody2D Rb;

    public event EventManager.EventAction OnPlayerJump;

    private void Start()
	{
		Rb = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Plataform_static") || coll.gameObject.CompareTag("Plataform_move")) {
		    if (Rb.velocity.y <= 0)
		    {
		        if (OnPlayerJump != null) OnPlayerJump();
		        Rb.velocity = new Vector2 (0, 0);
		        Rb.AddForce (new Vector2 (0, JumpHeight));
		        coll.gameObject.transform.FindChild("Platform_Rig").GetComponent<Animator>().SetTrigger("Bouncing");
		    }
		}
	}
}
