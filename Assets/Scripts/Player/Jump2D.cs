using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public float JumpHeight = 450f;
    public GameObject BounceParticles;
    private Rigidbody2D _rb;

    public event EventManager.EventAction OnPlayerJump;

    private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Plataform_static") || other.gameObject.CompareTag("Plataform_move")) {
		    if (_rb.velocity.y <= 0)
		    {
		        if (OnPlayerJump != null) OnPlayerJump();
		        var reflection = _rb.velocity;
		        reflection.y *= -1;
		        _rb.velocity = new Vector2 (0, 0);
		        _rb.AddForce (new Vector2 (0, JumpHeight));
		        other.gameObject.transform.FindChild("Platform_Rig").GetComponent<Animator>().SetTrigger("Bouncing");

		        var angle = Vector2.Angle(Vector2.right, reflection);
		        var particles = Instantiate(BounceParticles);
		        particles.transform.position = other.contacts[0].point;
		        particles.transform.eulerAngles = new Vector3(angle-180, -90, 90);
		    }
		}
	}
}
