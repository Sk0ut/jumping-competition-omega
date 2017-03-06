using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap2D : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate ()
	{
	    var screenPos = Camera.main.WorldToViewportPoint(transform.position);

		if (screenPos.x < 0) {
			transform.position = new Vector3 (Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x, transform.position.y, transform.position.z);
		}
		else if (screenPos.x > 1) {
			transform.position = new Vector3 (Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x, transform.position.y, transform.position.z);
		}
	}
}
