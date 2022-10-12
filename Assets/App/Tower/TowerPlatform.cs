using UnityEngine;

namespace App.Tower {
	public class TowerPlatform : MonoBehaviour {
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _renderer;
		private bool _tower;
		private Transform _transform;

		private void Awake() {
			this._renderer = this.GetComponent<Renderer>();
			this._hoverColor = new Color(0, 255, 255, 127);
			this._initColor = this._renderer.material.color;
		}

		private void OnMouseDown() {
			this.CreateTower();
		}

		private void OnMouseEnter() {
			this._renderer.material.color = this._hoverColor;
		}

		private void OnMouseExit() {
			this._renderer.material.color = this._initColor;
		}

		private void CreateTower() {
			if (this._tower) {
				return;
			}

			this._tower = TowerManager.Instance.Create(this.transform);
		}
	}
}
