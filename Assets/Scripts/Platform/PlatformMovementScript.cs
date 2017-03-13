using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    public Vector2 Speed = new Vector2(5, 0);
    public Vector2 Direction = new Vector2(-1, -1);

    public Vector2 Movement;
    private float _width;

    private void Start()
    {
        _width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);

        var leftSide = Camera.main.WorldToViewportPoint(transform.position - new Vector3(_width / 2, 0)).x;
        var rightSide = Camera.main.WorldToViewportPoint(transform.position + new Vector3(_width / 2, 0)).x;

        var tmp = transform.position;
        if (leftSide <= 0)
        {
            tmp.x = (Camera.main.ViewportToWorldPoint(new Vector3(0, 0)) + new Vector3(_width / 2, 0)).x;
            Direction.x = 1;
        }
        else if (rightSide >= 1)
        {
            tmp.x = (Camera.main.ViewportToWorldPoint(new Vector3(1, 0)) - new Vector3(_width / 2, 0)).x;
            Direction.x = -1;
        }

        transform.position = tmp;

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Movement;
    }
}