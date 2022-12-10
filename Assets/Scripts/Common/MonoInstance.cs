using UnityEngine;

namespace Common {
	public abstract class MonoInstance<T> : MonoBehaviour {
		protected MonoInstance() {
			Instance = (T)(object)this;
		}

		public static T Instance { get; private set; }
	}
}
