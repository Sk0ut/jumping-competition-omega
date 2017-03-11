using System.Collections;
using UnityEngine;

public class PowerUpJump : MonoBehaviour
{
    public int Timer = 5;
    public float JumpBoost = 1.8f;

    private bool _withBoostJump;

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
        Jump2D.jumpHeight = 700;
        yield return new WaitForSeconds(Timer);
        _withBoostJump = false;
        Jump2D.jumpHeight = 450;
    }
}