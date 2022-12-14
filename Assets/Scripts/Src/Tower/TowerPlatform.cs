using UnityEngine;
using UnityEngine.Serialization;

namespace Src.Tower {
	public sealed class TowerPlatform : MonoBehaviour {
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _renderer;
		public bool tower;

		private void Awake() {
			this._renderer = this.GetComponentInChildren<Renderer>();
			this._hoverColor = new Color(0, 255, 255, 127);
			this._initColor = this._renderer.material.color;
		}

		private void OnMouseEnter() {
			if (!this.tower && TowerManager.Instance.CanCreate()) {
				this._renderer.material.color = this._hoverColor;
			}
		}

		private void OnMouseExit() {
			if (!this.tower) {
				this._renderer.material.color = this._initColor;
			}
		}

		private void OnMouseOver() {
			if (Input.GetMouseButtonDown(0) && !this.tower && TowerManager.Instance.CanCreate()) {
				this.tower = true;
				this._renderer.material.color = this._initColor;
				TowerManager.Instance.CreateTower(this.gameObject);
				Debug.Log("TowerPlatform left");
			}

			if (Input.GetMouseButtonDown(2)) {
				Debug.Log("TowerPlatform middle");
			}
		}
	}
}
