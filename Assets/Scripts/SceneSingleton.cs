using UnityEngine;

public abstract class SceneSingleton<T> : MonoBehaviour {
	protected SceneSingleton() {
		Instance = (T)(object)this;
	}

	public static T Instance { get; private set; }
}
