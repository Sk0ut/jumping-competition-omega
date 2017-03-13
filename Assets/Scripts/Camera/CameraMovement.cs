using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate()
    {
        GetComponent<Camera>().aspect = 9f / 16f;
        float delta = player.transform.position.y - transform.position.y;
        if (delta > 0)
        {
            transform.Translate(new Vector3(0, delta * 2 * Time.deltaTime, 0));
        }
    }
}