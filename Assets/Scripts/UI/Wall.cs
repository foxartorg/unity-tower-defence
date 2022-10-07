using UnityEngine;

namespace UI {
	public class Wall : MonoBehaviour {
		private Color _hoverColor;
		private Renderer _render;
		private Color _startColor;
		private GameObject _tower;

		private void Start() {
			_render = GetComponent<Renderer>();
			_startColor = _render.material.color;
		}

		private void OnMouseDown() {
			if (_tower != null) {
				Debug.Log("Can't build here!");
			}

			var towerToBuild = BuildManager.Instance.GetTowerToBuild();
			_tower = Instantiate(towerToBuild, transform.position, transform.rotation);
		}

		private void OnMouseEnter() {
			_render.material.color = _hoverColor;
		}

		private void OnMouseExit() {
			_render.material.color = _startColor;
		}
	}
}
