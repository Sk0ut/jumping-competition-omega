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

    private float posY;
	private GameObject[] objectPool;
	// Adicionado //
	public GameObject powerUp_move;
	public GameObject powerUp_stop;
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
			checkPowerUps();
            Vector3 position = new Vector3(playerCamera.ViewportToWorldPoint(new Vector3(UnityEngine.Random.value, 0)).x,
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
				// Adicionado //
				generatePowerUp(position, objectPool[i]);
				// Adicionado //
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
        var dist = (transform.position - playerCamera.transform.position).z;
        var bottomBorder = playerCamera.ViewportToWorldPoint(
               new Vector3(0, 0, dist)
              ).y;
        for (int i = 0; i < objectPool.Length; ++i)
        {
            if(objectPool[i] == null)
            {
				if (UnityEngine.Random.Range (0, 2) == 0) {
					objectPool [i] = Instantiate (prefab1);
				} else {
					objectPool [i] = Instantiate (prefab2);
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
	// Adicionado //
	void generatePowerUp(Vector3 position, GameObject platform) {
		if (UnityEngine.Random.Range (0, 6) == 0) {
			GameObject powUp;

			if (platform.CompareTag ("Plataform_static"))
				powUp = Instantiate (powerUp_stop);
			else if (platform.CompareTag ("Plataform_move"))
				powUp = Instantiate (powerUp_move);
			else
				powUp = new GameObject ();

			powUp.transform.position = position + new Vector3(0,0.6f,0);
			powerUpPool.Add(powUp);
		}
	}

	void checkPowerUps()
	{
		powerUpPool = GameObject.FindGameObjectsWithTag("Power_Up").ToList(); 
		var bottomBorder = gameBorderObserver.Bottom;

		for (int i = 0; i < powerUpPool.Count; ++i) {
			if (powerUpPool[i].transform.position.y <= bottomBorder) {
				Destroy(powerUpPool[i]);
				powerUpPool[i].SetActive(false);
			}
		}
	}
	// Adicionado //
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
