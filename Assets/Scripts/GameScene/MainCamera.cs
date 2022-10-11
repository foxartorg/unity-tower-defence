using UnityEngine;

namespace GameScene {
	public class MainCamera : MonoBehaviour {
		private Camera _camera;
		private float _speed;

		private void Awake() {
			_camera = Camera.main;
		}

		private void Start() {
			// _camera.transform.Translate(-10, 0, 0);
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
