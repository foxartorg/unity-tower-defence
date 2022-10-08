using UnityEngine;

namespace Tower {
	public class Wall : MonoBehaviour {
		private Color _hoverColor;
		private Renderer _render;
		private Color _startColor;
		private GameObject _tower;
		public static int Counter;

		private void Start() {
			_render = GetComponent<Renderer>();
			_startColor = _render.material.color;
		}

		private void OnMouseDown() {
			if (_tower == null) {
				var towerToBuild = BuildManager.Instance.GetTowerToBuild();
				var transform1 = transform;
				_tower = Instantiate(towerToBuild, transform1.position, transform1.rotation);
			}
			Counter++;
		}

		private void OnMouseEnter() {
			_render.material.color = _hoverColor;
		}

		private void OnMouseExit() {
			_render.material.color = _startColor;
		}
	}
}
