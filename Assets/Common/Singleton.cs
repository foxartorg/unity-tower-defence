using UnityEngine;

namespace Common {
	public abstract class Singleton<T> : MonoBehaviour {
		protected Singleton() {
			Instance = (T)(object)this;
		}

		public static T Instance { get; private set; }
	}
}
