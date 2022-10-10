using UnityEngine;

namespace Tower {
	public class Wall : MonoBehaviour {
		private static int _counter;
		private Canvas _canvas;
		private Color _hoverColor;
		private Color _initColor;
		private GameObject _manager;
		private Renderer _render;
		private GameObject _tower;
		private Transform _transform;

		private void Awake() {
			_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
			_render = GetComponent<Renderer>();
			_manager = Builder.Instance.CreateTower();
			_initColor = _render.material.color;
			_hoverColor = new Color(255, 0, 0);
			_transform = transform;
		}

		private void Start() { }

		private void OnMouseDown() {
			CreateTower();
		}

		private void OnMouseEnter() {
			_render.material.color = _hoverColor;
		}

		private void OnMouseExit() {
			_render.material.color = _initColor;
		}

		private void CreateTower() {
			if (_tower != null) {
				return;
			}

			_tower = Instantiate(_manager, _transform.position, _transform.rotation);
			_canvas.TowerCountText(++_counter);
		}
	}
}
