using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

	void Start() {
		GetComponent<Camera> ().aspect = 9f / 16f;
	}

    void LateUpdate()
    {
        float delta = player.transform.position.y - transform.position.y;
        if (delta > 0)
        {
			transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}