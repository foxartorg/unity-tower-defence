using UnityEngine;

namespace Common {
	public abstract class MonoBehaviourSingleton<T> : MonoBehaviour {
		protected MonoBehaviourSingleton() {
			Instance = (T)(object)this;
		}

		public static T Instance { get; private set; }
	}
}
