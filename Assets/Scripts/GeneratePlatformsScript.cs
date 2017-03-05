using System;
using UnityEngine;

public class GeneratePlatformsScript : MonoBehaviour {
	public Camera camera;
	public GameObject prefab;
	public float gapY = 1f;
	public int poolSize = 5;

	private float posY;
	private GameObject[] objectPool;

	// Use this for initialization
	void Start () {
		posY = camera.transform.position.y + camera.orthographicSize;
		objectPool = new GameObject[poolSize];
		for (int i = 0; i < objectPool.Length; ++i) {
			objectPool [i] = Instantiate (prefab);
			objectPool [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float curPosY = camera.transform.position.y + camera.orthographicSize;
		clearOffScreen ();

        if (curPosY - posY > gapY)
        {
			Debug.Log ("Time to generate");
            Vector3 position = new Vector3(UnityEngine.Random.value * 12f - 6f,
               	curPosY, 0);
			if (generatePlatform (position)) {
				Debug.Log ("New object");
				posY = curPosY;
			}
        }
    }

	bool generatePlatform(Vector3 position){
		for (int i = 0; i < objectPool.Length; ++i) {
			if (!objectPool [i].activeSelf) {
				objectPool [i].transform.position = position;
				objectPool [i].SetActive (true);
				return true;
			}
		}
		return false;
	}

	void clearOffScreen() {
		for (int i = 0; i < objectPool.Length; ++i) {
			if (objectPool [i].activeSelf && objectPool[i].transform.position.y < camera.transform.position.y - camera.orthographicSize) {
				objectPool [i].SetActive (false);
			}
		}
	}
}
