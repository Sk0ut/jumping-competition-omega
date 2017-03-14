using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loser : MonoBehaviour {

	Text loser;
	string reason;

	// Use this for initialization
	void Start () {
		loser = GameObject.Find ("End").GetComponent<Text> ();
		reason = GameObject.FindGameObjectWithTag ("EndGameInfo").GetComponent<EndGameInfo> ().reason;
	}
	
	// Update is called once per frame
	void Update () {
		loser.text = "FIM DO JOGO!!\n" + reason ; 
	}
}
