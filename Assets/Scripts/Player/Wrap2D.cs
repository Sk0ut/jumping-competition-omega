using UnityEngine;

public class Wrap2D : MonoBehaviour
{
    private float _width;

    private void Start()
    {
        _width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        var leftSide = ScreenPosition(transform.position - new Vector3(_width / 2, 0)).x;
        var rightSide = ScreenPosition(transform.position + new Vector3(_width / 2, 0)).x;

        var wrappedPos = transform.position;

        if (rightSide < 0)
        {
            wrappedPos.x = WorldPosition(new Vector3(1, 0)).x + _width / 2;
        }
        else if (leftSide > 1)
        {
            wrappedPos.x = WorldPosition(new Vector3(0, 0)).x - _width / 2;
        }
        transform.position = wrappedPos;
    }

    private static Vector3 WorldPosition(Vector3 screenPosition)
    {
        return Camera.main.ViewportToWorldPoint(screenPosition);
    }

    private static Vector3 ScreenPosition(Vector3 position)
    {
        return Camera.main.WorldToViewportPoint(position);
    }
}