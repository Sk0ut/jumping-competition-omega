using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : MonoBehaviour {

	public int timer = 5;

	bool withBoostJump;

	// Use this for initialization
	void Start () {
		withBoostJump = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Power_Up")) {
			Debug.Log ("Apanhou powerup!");
			Destroy(coll.gameObject);
			withBoostJump = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (withBoostJump) {
			Debug.Log ("Boost Jump!");
			StartCoroutine (JumpBoost ());
		} 
	}

	IEnumerator JumpBoost(){
		Debug.Log ("JumpHeight increased");
		Jump2D.jumpHeight = 700;
		yield return new WaitForSeconds (timer);
		withBoostJump = false;
		CancelJumpBoost ();
	}

	void CancelJumpBoost(){
		Debug.Log ("JumpHeight decreased");
		Jump2D.jumpHeight = 450;
	}
}
