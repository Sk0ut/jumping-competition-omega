using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnEnd : MonoBehaviour
{
    private ParticleSystem _ps;
    private void Start ()
    {
        _ps = GetComponent<ParticleSystem>();
    }
	
    private void Update ()
    {
        if (_ps.isPlaying) return;
        Destroy(gameObject);
    }
}
