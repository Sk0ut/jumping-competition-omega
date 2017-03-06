using System;
using UnityEngine;

public class GeneratePlatformsScript : MonoBehaviour {
	public Camera camera;
	public GameObject prefab1;
    public GameObject prefab2;
    public float mean = 2f;
    public float sigma = 1f;
    public int poolSize = 10;

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

        if (curPosY - posY > generateNormalRandom(mean, sigma))
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

    public static float generateNormalRandom(float mu, float sigma)
    {
        float rand1 = UnityEngine.Random.Range(0.0f, 1.0f);
        float rand2 = UnityEngine.Random.Range(0.0f, 1.0f);

        float n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);
        float ret = mu + sigma * n;
        if (ret < 1)
            return 1;
        else return ret;
    }
}
