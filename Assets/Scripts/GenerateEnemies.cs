using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour {

    public int cooldownDistance = 10;
    public int spawningProbability = 15;
    public GameObject enemyPrefab;
    public Camera playerCamera;

    private float currentCooldown;
    private float posY;

    public GameBorderObserver gameBorderObserver;

    // Use this for initialization
    void Start () {
        posY = gameBorderObserver.Top;
    }
	
	// Update is called once per frame
	void Update () {
        float curPosY = gameBorderObserver.Top;
        currentCooldown -= (curPosY - posY);
        posY = curPosY;

        if(currentCooldown < 0)
        {
            if (Random.Range(0, 100) < spawningProbability)
            {
                currentCooldown = cooldownDistance;
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = new Vector3(playerCamera.ViewportToWorldPoint(new Vector3(Random.value, 0)).x,
                   curPosY, 0);
                currentCooldown = cooldownDistance;
            }
        }
    }
}
