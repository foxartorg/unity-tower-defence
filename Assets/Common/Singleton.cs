using UnityEngine;

namespace Common {
	public abstract class Singleton : MonoBehaviour {
		private static MonoBehaviour _instance;

		protected T GetInstance<T>() {
			if (_instance) {
				Helper.ThrowError($"Multiple instances of: {_instance.name}");
			}

			return (T)(object)(_instance = this);
		}
	}
}
