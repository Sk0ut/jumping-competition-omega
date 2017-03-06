using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour {

    public Vector2 speed = new Vector2(5, 0);
    public Vector2 direction = new Vector2(-1, -1);

    private Rigidbody2D rigidbodyComponent;
    public Vector2 movement;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);

        var dist = (transform.position - Camera.main.transform.position).z;
        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;
        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;

        if (transform.position.x <= leftBorder)
            direction = new Vector2(1, -1);
        else if (transform.position.x >= rightBorder)
            direction = new Vector2(-1, -1);
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}