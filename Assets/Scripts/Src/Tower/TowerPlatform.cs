using UnityEngine;

namespace Src.Tower {
	public sealed class TowerPlatform : MonoBehaviour {
		public bool tower;
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _renderer;

		private TowerPlatform() {
			this.CanAccept = true;
		}

		public bool CanAccept { get; set; }

		private void Awake() {
			this._renderer = this.GetComponentInChildren<Renderer>();
			this._hoverColor = new Color(0, 255, 255, 127);
			this._initColor = this._renderer.material.color;
		}

		private void OnMouseEnter() {
			if (this.CanAccept && TowerManager.Instance.CanCreate()) {
				this._renderer.material.color = this._hoverColor;
			}
		}

		private void OnMouseExit() {
			this._renderer.material.color = this._initColor;
		}

		private void OnMouseOver() {
			if (Input.GetMouseButtonDown(0) && this.CanAccept && TowerManager.Instance.CanCreate()) {
				this.CanAccept = false;
				TowerManager.Instance.CreateTower(this.gameObject);
				Debug.Log("TowerPlatform left");
			}

			if (Input.GetMouseButtonDown(2)) {
				Debug.Log("TowerPlatform middle");
			}
		}
	}
}
