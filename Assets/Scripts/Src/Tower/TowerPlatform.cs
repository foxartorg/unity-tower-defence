using UnityEngine;

namespace Src.Tower {
	public sealed class TowerPlatform : MonoBehaviour {
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
			if (this._tower == null) {
				this._renderer.material.color = this._hoverColor;
			}
		}

		private void OnMouseExit() {
			this._renderer.material.color = this._initColor;
		}

		private void OnMouseOver() {
			if (Input.GetMouseButtonDown(0) && this._tower == null) {
				this._renderer.material.color = this._initColor;
				this._tower = TowerManager.Instance.AddTower(this.gameObject);
			}

			if (Input.GetMouseButtonDown(1) && this._tower != null) {
				this._renderer.material.color = this._hoverColor;
				this._tower = TowerManager.Instance.DeleteTower(this._tower);
			}

			if (Input.GetMouseButtonDown(2)) {
				Debug.Log("Pressed middle click.");
			}
		}
	}
}
