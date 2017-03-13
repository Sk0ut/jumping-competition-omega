using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameBorderObserver {
	float Top {
		get;
	}
	float Bottom {
		get;
	}
	float Left {
		get;
	}
	float Right {
		get;
	}
}
