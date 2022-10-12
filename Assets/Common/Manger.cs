using UnityEngine;

namespace Common {
	public abstract class Manager : MonoBehaviour {
		protected T SingleInstance<T>(MonoBehaviour context, MonoBehaviour instance) {
			if (instance == null) {
				return (T)(object)context;
			}

			Helper.ThrowError($"Multiple instances of: {this.name}");
			return default;
		}
	}
}
