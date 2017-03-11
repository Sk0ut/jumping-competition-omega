using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GeneratePlatformsPowerUps : MonoBehaviour {
	public Camera playerCamera;
	public GameBorderObserver gameBorderObserver;
	public GameObject prefab1;
    public GameObject prefab2;
    public float mean = 2f;
    public float sigma = 1f;
    public int poolSize = 10;
    public int JumpBoostFrequency = 10;

    private float posY;
	private GameObject[] objectPool;
	// Adicionado //
	public GameObject PowerUp;
	List<GameObject> powerUpPool;
	// Adicionado //

	// Use this for initialization
	void Start () {
		posY = gameBorderObserver.Top;
		objectPool = new GameObject[poolSize];
		// Adicionado //
		powerUpPool = new List<GameObject>();
		// Adicionado //
        generatePlatforms();
	}

	// Update is called once per frame
	void Update () {
		float curPosY = gameBorderObserver.Top;
		clearOffScreen ();

        if (curPosY - posY > generateNormalRandom(mean, sigma))
        {
			Debug.Log ("Time to generate");
            generatePlatforms();
//			checkPowerUps();
            var position = new Vector3(playerCamera.ViewportToWorldPoint(new Vector3(UnityEngine.Random.value, 0)).x,
               	curPosY);
			if (generatePlatform(position)) {
				Debug.Log ("New object");
				posY = curPosY;
			}
        }
    }

	bool generatePlatform(Vector3 position){
		for (int i = 0; i < objectPool.Length; ++i) {
			if (!objectPool[i].activeSelf) {
				generatePowerUp(objectPool[i]);
				objectPool[i].transform.position = position;
				objectPool[i].SetActive (true);
				return true;
			}
		}
		return false;
	}

	void clearOffScreen() {
		for (int i = 0; i < objectPool.Length; ++i) {
			if (objectPool[i].activeSelf && objectPool[i].transform.position.y < gameBorderObserver.Bottom) {
				objectPool[i].SetActive (false);
			}
		}
	}

    void generatePlatforms()
    {
        var bottomBorder = playerCamera.ViewportToWorldPoint(Vector3.zero).y;
        for (int i = 0; i < objectPool.Length; ++i)
        {
            if(objectPool[i] == null)
            {
				if (UnityEngine.Random.Range (0, 2) == 0) {
					objectPool [i] = Instantiate(prefab1);
				} else {
					objectPool [i] = Instantiate(prefab2);
				}
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
	void generatePowerUp(GameObject platform) {
		if (UnityEngine.Random.Range (0, 100) <= JumpBoostFrequency) {
		    var powUp = Instantiate(PowerUp);
		    powUp.transform.SetParent(platform.transform, false);
			powerUpPool.Add(powUp);
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
