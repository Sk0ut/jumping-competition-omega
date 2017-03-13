using UnityEngine;
using System.Collections;

// Need this abstract class to make the interface visible in the editor
public abstract class GameBorderObserver : MonoBehaviour, IGameBorderObserver
{
	public abstract float Top {
		get;
	}
	public abstract float Bottom {
		get;
	}
	public abstract float Left {
		get;
	}
	public abstract float Right {
		get;
	}
}

