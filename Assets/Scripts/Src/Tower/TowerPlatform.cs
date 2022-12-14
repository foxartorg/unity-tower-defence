using UnityEngine;

namespace Src.Tower {
	public sealed class TowerPlatform : MonoBehaviour {
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _renderer;
		private GameObject _tower;

		private void Awake() {
			this._renderer = this.GetComponentInChildren<Renderer>();
			this._hoverColor = new Color(0, 255, 255, 127);
			this._initColor = this._renderer.material.color;
		}

		private void OnMouseEnter() {
			if (!this._tower && TowerManager.Instance.CheckTower()) {
				this._renderer.material.color = this._hoverColor;
			}
		}

		private void OnMouseExit() {
			if (!this._tower) {
				this._renderer.material.color = this._initColor;
			}
		}

		private void OnMouseOver() {
			var contains = TowerManager.Instance.towers.Contains(this._tower);
			if (Input.GetMouseButtonDown(0) && !contains && TowerManager.Instance.CheckTower()) {
				this._tower = TowerManager.Instance.CreateTower(this.gameObject);
				this._renderer.material.color = this._initColor;
				Debug.Log("TowerPlatform left");
			}

			if (Input.GetMouseButtonDown(2)) {
				Debug.Log("TowerPlatform middle");
			}
		}
	}
}
