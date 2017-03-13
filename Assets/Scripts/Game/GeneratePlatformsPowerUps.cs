using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatformsPowerUps : MonoBehaviour
{
    public GameBorderObserver GameBorderObserver;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public float Mean = 2f;
    public float Sigma = 1f;
    public int JumpBoostFrequency = 40;
    public int DebuffFrequency = 10;

    public GameObject PowerUp;
    public GameObject Debuff;

    private float _posY;

    private List<GameObject> _platforms;
    private List<GameObject> _powerUps;
    private List<GameObject> _debuffs;

    private void Start()
    {
        _posY = GameBorderObserver.Top;
        _platforms = new List<GameObject>();
        _powerUps = new List<GameObject>();
        _debuffs = new List<GameObject>();
    }

    private void Update()
    {
        var curPosY = GameBorderObserver.Top;
        ClearOffScreen();

        if (!(curPosY - _posY > GenerateNormalRandom(Mean, Sigma))) return;
        var position = new Vector3(Random.Range(GameBorderObserver.Left, GameBorderObserver.Right),
            curPosY, 0);
        var newPlat = GeneratePlatform(position);
        _posY = newPlat.transform.position.y;
    }

    private GameObject GeneratePlatform(Vector3 position)
    {
        var prefab = Random.Range(0, 2) == 0 ? Prefab1 : Prefab2;
        var newPlatform = Instantiate(prefab);
        position.y += newPlatform.GetComponent<SpriteRenderer>().bounds.extents.y;
        newPlatform.transform.position = position;
        _platforms.Add(newPlatform);

        var rnd = Random.Range(0, 100);
        if (rnd < 50) GeneratePowerUp(newPlatform);
        else GenerateDebuff(newPlatform);

        return newPlatform;
    }

    private void ClearOffScreen()
    {
        _platforms.RemoveAll(plat =>
        {
            if (plat == null) return true;
            if (!(plat.transform.position.y < GameBorderObserver.Bottom))
                return false;
            Destroy(plat);
            return true;
        });
        _powerUps.RemoveAll(p => p == null);
        _debuffs.RemoveAll(p => p == null);
    }

    private void GeneratePowerUp(GameObject platform)
    {
        if (Random.Range(0, 100) <= JumpBoostFrequency)
        {
            var powUp = Instantiate(PowerUp);
            powUp.transform.SetParent(platform.transform, false);
            _powerUps.Add(powUp);
        }
    }

    private void GenerateDebuff(GameObject platform)
    {
        if (Random.Range(0, 100) <= DebuffFrequency)
        {
            var debff = Instantiate(Debuff);
            debff.transform.SetParent(platform.transform, false);
            _debuffs.Add(debff);
        }
    }

    public static float GenerateNormalRandom(float mu, float sigma)
    {
        var rand1 = Random.Range(0.0f, 1.0f);
        var rand2 = Random.Range(0.0f, 1.0f);

        var n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);
        var ret = mu + sigma * n;
        return ret < 1 ? 1 : ret;
    }
}