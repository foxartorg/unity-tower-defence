using UnityEngine;

namespace Examples {
	internal sealed class RotationExample : MonoBehaviour {
		[SerializeField] private Vector3 rotation;

		private void Update() {
			this.transform.Rotate(this.rotation);
		}
	}
}
