using UnityEngine;

namespace Tower {
	public class Bullet : MonoBehaviour {
		private const int Speed = 30;

		private void Update() {
			var distanceThisFrame = Speed * Time.deltaTime;
			transform.Translate(transform.forward * distanceThisFrame);
		}
	}
}
