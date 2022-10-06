using UnityEngine;

namespace UI {
	public class Camera : MonoBehaviour {
		private UnityEngine.Camera _camera;
		private float _speed;

		private void Start() {
			_camera = UnityEngine.Camera.main;
		}

		public void Up() {
			_camera.transform.Translate(0, 1000 * Time.deltaTime, 0);
		}

		public void Down() {
			_camera.transform.Translate(0, -1000 * Time.deltaTime, 0);
		}

		public void Left() {
			_camera.transform.Translate(-1000 * Time.deltaTime, 0, 0);
		}

		public void Right() {
			_camera.transform.Translate(1000 * Time.deltaTime, 0, 0);
		}
	}
}
