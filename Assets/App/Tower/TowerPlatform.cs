using UnityEngine;

namespace App.Tower {
	public class TowerPlatform : MonoBehaviour {
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _renderer;
		private GameObject _tower;

		private void Awake() {
			this._renderer = this.GetComponent<Renderer>();
			this._hoverColor = new Color(0, 255, 255, 127);
			this._initColor = this._renderer.material.color;
		}

		private void OnMouseEnter() {
			this._renderer.material.color = this._hoverColor;
		}

		private void OnMouseExit() {
			this._renderer.material.color = this._initColor;
		}

		private void OnMouseOver() {
			if (Input.GetMouseButtonDown(0)) {
				this.CreateTower();
			}

			if (Input.GetMouseButtonDown(1)) {
				this.DestroyTower();
			}

			if (Input.GetMouseButtonDown(2)) {
				Debug.Log("Pressed middle click.");
			}
		}

		private void CreateTower() {
			if (this._tower != null) {
				return;
			}

			this._tower = TowerManager.Instance.Add(this.transform);
		}

		private void DestroyTower() {
			if (this._tower == null) {
				return;
			}

			TowerManager.Delete(this._tower);
			this._tower = null;
		}
	}
}
