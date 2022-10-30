using Common;
using UnityEngine;

namespace Examples {
	internal abstract class SceneInstanceExample : MonoBehaviour {
		private T OnAwake<T>(MonoBehaviour context, Object instance) {
			if (instance == null) {
				return (T)(object)context;
			}

			Helper.ThrowError($"Multiple instances of: {this.name}");
			return default;
		}
	}
}
