using UnityEngine;

namespace App.Tower {
	public class TowerPlatform : MonoBehaviour {
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _renderer;
		private bool _tower;
		private Transform _transform;

		private void Awake() {
			_renderer = GetComponent<Renderer>();
			_hoverColor = new Color(0, 255, 255, 127);
			_initColor = _renderer.material.color;
		}

		private void OnMouseDown() {
			CreateTower();
		}

		private void OnMouseEnter() {
			_renderer.material.color = _hoverColor;
		}

		private void OnMouseExit() {
			_renderer.material.color = _initColor;
		}

		private void CreateTower() {
			if (_tower) {
				return;
			}

			_tower = TowerManager.Instance.Create(transform);
		}
	}
}
