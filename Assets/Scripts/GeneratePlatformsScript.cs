using System;
using UnityEngine;

public class GeneratePlatformsScript : MonoBehaviour {
    public int posY = (int)GameObject.Find("background").GetComponent<ScrollingScript>().transform.position.y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var curPosY = (int)GameObject.Find("background").GetComponent<ScrollingScript>().transform.position.y;

        if (posY - curPosY != 0)
        {
            var dist = (transform.position - Camera.main.transform.position).z;
            posY = curPosY;
            Vector3 position = new Vector3(UnityEngine.Random.value * Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x,
                Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).y,
                dist);
            GameObject obj = Instantiate(Resources.Load("Prefabs/Platform")) as GameObject;
            obj.transform.position = position;

        }
    }
}
