using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

	public AudioClip bounceSound;
	public AudioClip JumpBoostSound;

	AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		sound.playOnAwake = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Plataform_static") || coll.gameObject.CompareTag("Plataform_move")) {
			sound.PlayOneShot(bounceSound, 0.8f);
		}
		else if (coll.gameObject.CompareTag("Power_Up")) {
			sound.PlayOneShot(JumpBoostSound, 0.8f);
		}
	}
}
