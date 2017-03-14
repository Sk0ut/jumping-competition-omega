using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValterMovementScript : MonoBehaviour {

    public Vector2 speed = new Vector2(1, 1);
    public Vector2 direction = new Vector2(-1, -1);

    public Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    public float timeSinceLastSec = 0.9f;

    private float rightBorder;
    private float leftBorder;
    private float topBorder;
    private float bottomBorder;


    // Use this for initialization
    void Start () {
        var dist = (transform.position - Camera.main.transform.position).z;

        rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;
        leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;
        topBorder = Camera.main.ViewportToWorldPoint(
           new Vector3(0, 0, dist)
       ).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
        ).y;
    }

    // Update is called once per frame
    void Update () {
        timeSinceLastSec += Time.deltaTime;
        if (timeSinceLastSec < 1) {
            return;
        }
        if (speed.x != 0) {
            if (Random.Range(0, 100) < 40)
            {
                direction.x = -direction.x;
                return;
            }
            if (Random.Range(0, 100) < 40)
            {
                speed = new Vector2(0, 1);
            }
            timeSinceLastSec -= 1;
        }
        else if(speed.y != 0) {
            if (Random.Range(0, 100) < 40)
            {
                direction.y = -direction.y;
                return;
            }
            if (Random.Range(0, 100) < 40) {
                speed = new Vector2(1, 0);
            }
            timeSinceLastSec -= 1;
        }

        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
        if (transform.position.x <= leftBorder)
            direction = new Vector2(1, -1);
        else if (transform.position.x >= rightBorder)
            direction = new Vector2(-1, -1);
        else if (transform.position.y <= topBorder)
            direction = new Vector2(0, -1);
        else if (transform.position.y >= bottomBorder)
            direction = new Vector2(0, 1);
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}