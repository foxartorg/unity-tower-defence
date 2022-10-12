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
			this._camera.fieldOfView = 100;
			this.StartCoroutine(LerpFieldOfView(this._camera, 60, 0.5f));
		}

		private static IEnumerator LerpFieldOfView(Camera targetCamera, float toFOV, float duration) {
			float counter = 0;
			var fromFOV = targetCamera.fieldOfView;
			while (counter < duration) {
				counter += Time.deltaTime;
				var fOvTime = counter / duration;
				targetCamera.fieldOfView = Mathf.Lerp(fromFOV, toFOV, fOvTime);
				yield return null;
			}
		}

		public void Up() {
			this._camera.transform.Translate(0, 1000 * Time.deltaTime, 0);
		}

		public void Down() {
			this._camera.transform.Translate(0, -1000 * Time.deltaTime, 0);
		}

		public void Left() {
			this._camera.transform.Translate(-1000 * Time.deltaTime, 0, 0);
		}

		public void Right() {
			this._camera.transform.Translate(1000 * Time.deltaTime, 0, 0);
		}
	}
}
