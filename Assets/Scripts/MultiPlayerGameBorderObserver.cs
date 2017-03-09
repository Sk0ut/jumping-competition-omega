using UnityEngine;
using System.Collections;

public class MultiPlayerGameBorderObserver : GameBorderObserver
{
	public Camera player1Camera;
	public Camera player2Camera;

	public override float Top {
		get { 
			return Mathf.Max(player1Camera.transform.position.y, player2Camera.transform.position.y) + player1Camera.orthographicSize;
		}
	}

	public override float Bottom {
		get { return Mathf.Min(player1Camera.transform.position.y, player2Camera.transform.position.y) - player1Camera.orthographicSize; }
	}

	// @TODO
	public override float Left {
		get { return -10; }
	}

	// @TODO
	public override float Right {
		get { return 10; }
	}
}

