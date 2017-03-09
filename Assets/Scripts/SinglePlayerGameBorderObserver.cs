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

	// @TODO
	public override float Left {
		get { return -10; }
	}

	// @TODO
	public override float Right {
		get { return 10; }
	}
}

