using UnityEngine;

namespace Tower {
	public class Wall : MonoBehaviour {
		public static int Counter;
		private Color _color;
		private Color _hoverColor;
		private Renderer _render;
		private GameObject _tower;
		private GameObject _towerManager;

		private void Start() {
			_render = GetComponent<Renderer>();
			_hoverColor = new Color(255, 0, 0);
			_color = _render.material.color;
		}

		private void OnMouseDown() {
			if (_tower == null) {
				_towerManager = Manager.Instance.GetTowerToBuild();
				var transform1 = transform;
				_tower = Instantiate(_towerManager, transform1.position, transform1.rotation);
			}

			Counter++;
		}

		private void OnMouseEnter() {
			_render.material.color = _hoverColor;
		}

		private void OnMouseExit() {
			_render.material.color = _color;
		}
	}
}
