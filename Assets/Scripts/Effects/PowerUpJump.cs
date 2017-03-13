using System.Collections;
using UnityEngine;

public class PowerUpJump : MonoBehaviour
{
    public int Timer = 5;
    public float JumpBoost = 1.8f;

    private bool _withBoostJump;

    public event EventManager.EventAction OnPowerupPickup;

    private void Start()
    {
        _withBoostJump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Power_Up")) return;

        Destroy(other.gameObject);
        _withBoostJump = true;
        StopCoroutine("Activate");
        if (OnPowerupPickup != null) OnPowerupPickup();
    }

    private void Update()
    {
        if (_withBoostJump)
        {
            StartCoroutine("Activate");
        }
    }

    private IEnumerator Activate()
    {
        GetComponent<Jump2D>().JumpHeight = 700;
        yield return new WaitForSeconds(Timer);
        _withBoostJump = false;
        GetComponent<Jump2D>().JumpHeight = 450;
    }
}