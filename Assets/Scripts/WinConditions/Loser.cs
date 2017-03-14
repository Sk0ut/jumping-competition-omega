using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loser : MonoBehaviour {

	Text loser;

	// Use this for initialization
	void Start () {
		loser = GameObject.Find ("End").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameObject.FindGameObjectWithTag ("Player").name);
		loser.text = "FIM DO JOGO!!\n" + GameObject.FindGameObjectWithTag("Player").name + " perdeu!" ; 
		GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector3(0, 0, 0);
	}
}
