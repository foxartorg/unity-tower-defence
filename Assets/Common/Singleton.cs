using UnityEngine;

namespace Common {
	public abstract class Singleton : MonoBehaviour {
		private static MonoBehaviour _instance;

		protected T GetInstance<T>() {
			if (!_instance) {
				_instance = this;
				return (T)(object)_instance;
				// return (T)(object)(_instance = this);
			}

			Helper.ThrowError($"Multiple instances of: {_instance.name}");
			return default;
		}
	}
}
