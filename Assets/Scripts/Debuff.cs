using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Debuff : MonoBehaviour {

	public int PlatformsToBeDestroyed = 1;
	private List<GameObject> platforms;

	// Use this for initialization
	void Start () {
		platforms = GameObject.FindGameObjectsWithTag("Plataform_static").Concat(GameObject.FindGameObjectsWithTag("Plataform_move")).ToList(); 
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Debuff")) {
			for (int i = 0; i < PlatformsToBeDestroyed; i++) {
					platforms = GameObject.FindGameObjectsWithTag("Plataform_static").Concat(GameObject.FindGameObjectsWithTag("Plataform_move")).ToList();
				int rnd = UnityEngine.Random.Range (0, platforms.Count);
				Destroy (other.gameObject);
				Debug.Log ("Destroyed Platform!");
				Destroy(platforms [rnd]);
			}
		}
	}
	private void Update()
	{
		platforms = GameObject.FindGameObjectsWithTag("Plataform_static").Concat(GameObject.FindGameObjectsWithTag("Plataform_move")).ToList();
	}
}
