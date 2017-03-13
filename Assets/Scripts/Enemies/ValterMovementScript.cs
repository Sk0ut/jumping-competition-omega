using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValterMovementScript : MonoBehaviour {

    public Vector2 speed = new Vector2(1, 0);
    public Vector2 direction = new Vector2(-1, -1);

    public Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    public float timeSinceLastSec = 0;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        var dist = (transform.position - Camera.main.transform.position).z;
        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;
        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;
        var topBorder = Camera.main.ViewportToWorldPoint(
           new Vector3(0, 0, dist)
       ).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
        ).y;

        timeSinceLastSec += Time.deltaTime;
        if (transform.position.x <= leftBorder)
            direction = new Vector2(1, -1);
        else if (transform.position.x >= rightBorder)
            direction = new Vector2(-1, -1);
        else if (transform.position.y <= topBorder)
            direction = new Vector2(0, -1);
        else if (transform.position.y >= bottomBorder)
            direction = new Vector2(0, 1);
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
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}