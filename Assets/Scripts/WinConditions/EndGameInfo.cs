using UnityEngine;
using System.Collections;

public class EndGameInfo : MonoBehaviour
{
	public string reason;

	public void Start() {
		DontDestroyOnLoad (this.gameObject);
	}
}

