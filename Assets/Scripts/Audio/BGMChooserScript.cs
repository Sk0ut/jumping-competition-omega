using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChooserScript : MonoBehaviour {

    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip bgm3;

	// Use this for initialization
	void Start () {
        switch (Random.Range(0, 3))
        {
            case 0:
                GetComponent<AudioSource>().clip = bgm1;
                break;
            case 1:
                GetComponent<AudioSource>().clip = bgm2;
                break;
            case 2:
                GetComponent<AudioSource>().clip = bgm3;
                break;
            default:
                break;
        }
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
