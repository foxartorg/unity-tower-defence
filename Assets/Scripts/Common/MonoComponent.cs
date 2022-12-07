using UnityEngine;

namespace Common {
	public abstract class MonoComponent<T> : MonoBehaviour {
		protected MonoComponent() {
			Instance = (T)(object)this;
		}

		public static T Instance { get; private set; }
	}
}
