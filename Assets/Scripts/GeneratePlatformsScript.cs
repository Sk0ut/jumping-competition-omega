using System;
using UnityEngine;

public class GeneratePlatformsScript : MonoBehaviour {
	public Camera camera;
	private float posY;
	public GameObject prefab;
	public float gapY = 1f;

	// Use this for initialization
	void Start () {
		posY = camera.transform.position.y + camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		float curPosY = camera.transform.position.y + camera.orthographicSize;

        if (curPosY - posY > gapY)
        {
			Debug.Log ("Time to generate");
            posY = curPosY;
            Vector3 position = new Vector3(UnityEngine.Random.value * 12f - 6f,
               	curPosY, 0);
            GameObject obj = Instantiate(prefab);
            obj.transform.position = position;
        }
    }
}
