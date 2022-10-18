using Common;
using UnityEngine;

namespace Sample {
	public abstract class SceneSingleton : MonoBehaviour {
		protected T OnAwake<T>(MonoBehaviour context, MonoBehaviour instance) {
			if (instance == null) {
				return (T)(object)context;
			}

			Helper.ThrowError($"Multiple instances of: {this.name}");
			return default;
		}
	}
}
