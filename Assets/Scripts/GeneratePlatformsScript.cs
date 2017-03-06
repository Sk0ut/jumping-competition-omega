using System;
using UnityEngine;

public class GeneratePlatformsScript : MonoBehaviour {
	public Camera camera;
	public GameObject prefab1;
    public GameObject prefab2;
	public int poolSize = 20;
    public float gapY = 1f;

    private float posY;
	private GameObject[] objectPool;

	// Use this for initialization
	void Start () {
		posY = camera.transform.position.y + camera.orthographicSize;
		objectPool = new GameObject[poolSize];
        generatePlatforms();
	}
	
	// Update is called once per frame
	void Update () {
		float curPosY = camera.transform.position.y + camera.orthographicSize;
		clearOffScreen ();

        if (curPosY - posY > gapY)
        {
			Debug.Log ("Time to generate");
            generatePlatforms();
            Vector3 position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.value, 0)).x,
               	curPosY, 0);
			if (generatePlatform (position)) {
				Debug.Log ("New object");
				posY = curPosY;
			}
        }
    }

	bool generatePlatform(Vector3 position){
		for (int i = 0; i < objectPool.Length; ++i) {
			if (!objectPool[i].activeSelf) {
				objectPool[i].transform.position = position;
				objectPool[i].SetActive (true);
				return true;
			}
		}
		return false;
	}

	void clearOffScreen() {
		for (int i = 0; i < objectPool.Length; ++i) {
			if (objectPool[i].activeSelf && objectPool[i].transform.position.y < camera.transform.position.y - camera.orthographicSize) {
				objectPool[i].SetActive (false);
			}
		}
	}

    void generatePlatforms()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        var bottomBorder = Camera.main.ViewportToWorldPoint(
               new Vector3(0, 0, dist)
              ).y;
        for (int i = 0; i < objectPool.Length; ++i)
        {
            if(objectPool[i] == null)
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                    objectPool[i] = Instantiate(prefab1);
                else
                    objectPool[i] = Instantiate(prefab2);
                objectPool[i].SetActive(false);
            }

            if (objectPool[i].transform.position.y <= bottomBorder)
            {
                Destroy(objectPool[i]);

                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    objectPool[i] = Instantiate(prefab1);
                }
                else
                {
                    objectPool[i] = Instantiate(prefab2);
                }
                objectPool[i].SetActive(false);
            }
        }
    }
}
