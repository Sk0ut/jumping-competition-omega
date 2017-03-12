using UnityEngine;
using System.Collections;

public class SinglePlayerGameBorderObserver : GameBorderObserver {
	public Camera playerCamera;

	public override float Top {
		get { return playerCamera.transform.position.y + playerCamera.orthographicSize; }
	}

	public override float Bottom {
		get { return playerCamera.transform.position.y - playerCamera.orthographicSize; }
	}

	public override float Left {
		get { return playerCamera.transform.position.x - playerCamera.orthographicSize * playerCamera.aspect; }
	}

	public override float Right {
		get { return playerCamera.transform.position.x + playerCamera.orthographicSize * playerCamera.aspect; }
	}
}

