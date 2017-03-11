using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        float delta = player.transform.position.y - transform.position.y;
        if (delta > 0)
        {
            transform.Translate(new Vector3(0, delta * Time.deltaTime, 0));
        }
    }
}