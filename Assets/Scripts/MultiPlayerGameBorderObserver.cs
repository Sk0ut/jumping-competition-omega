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

	public override float Left {
		get { return player1Camera.transform.position.x - player1Camera.orthographicSize * player1Camera.aspect; }
	}

	public override float Right {
		get { return player1Camera.transform.position.x + player1Camera.orthographicSize * player1Camera.aspect; }
	}
}

