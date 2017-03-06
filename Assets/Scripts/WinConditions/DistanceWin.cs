using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWin : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public float maxDistance = 10f;
	public string winner = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.transform.position.y - player2.transform.position.y > maxDistance) {
			winner = "Player1";	
		} else if (player2.transform.position.y - player1.transform.position.y > maxDistance) {
			winner = "Player2";
		}
	}
}
