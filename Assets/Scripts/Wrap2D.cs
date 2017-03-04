using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap2D : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {

		if (transform.position.x <= -6f) {
			transform.position = new Vector3 (6f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x >= 6f) {
			transform.position = new Vector3 (-6f, transform.position.y, transform.position.z);
		}
	}
}
