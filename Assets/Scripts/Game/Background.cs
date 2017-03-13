using System.Linq;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Prefab;
    public GameBorderObserver Observer;

    private bool _replicated;
    private GameObject[] _players;
    private Bounds _bounds;

    private void Start()
    {
        _replicated = false;
        _players = GameObject.FindGameObjectsWithTag("Player");
        _bounds = GetComponent<SpriteRenderer>().bounds;
    }

    private void Update()
    {
        if (_bounds.max.y <= Observer.Bottom)
        {
            Destroy(gameObject);
            return;
        }

        if (_replicated) return;
        if (_players.Select(player => player.transform.position).Any(IsInside))
        {
            _replicated = true;
            var replicaPos = transform.position + Vector3.up * _bounds.size.y;
            var replica = Instantiate(Prefab);
            replica.transform.position = replicaPos;
        }
    }

    private bool IsInside(Vector3 point)
    {
        return _bounds.Contains(point);
    }
}