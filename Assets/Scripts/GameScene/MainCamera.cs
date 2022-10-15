using System.Collections;
using UnityEngine;

namespace GameScene {
	public class MainCamera : MonoBehaviour {
		private Camera _camera;
		private float _speed;

		private void Awake() {
			this._camera = Camera.main;
		}

		private void Start() {
			// this._camera.transform.Translate(0, 1000 * Time.deltaTime, 0);
			this._camera.fieldOfView = 180;
			this.StartCoroutine(LerpFieldOfView(this._camera, 60, 0.5f));
		}

		private static IEnumerator LerpFieldOfView(Camera camera, float toFOV, float duration) {
			float counter = 0;
			var fromFOV = camera.fieldOfView;
			while (counter < duration) {
				counter += Time.deltaTime;
				var fOvTime = counter / duration;
				camera.fieldOfView = Mathf.Lerp(fromFOV, toFOV, fOvTime);
				yield return null;
			}
		}
	}
}
