using UI;
using UnityEngine;

namespace Tower {
	public class Wall : MonoBehaviour {
		private static int _counter;
		private Color _hoverColor;
		private Color _initColor;
		private Renderer _render;
		private GameObject _tower;
		private GameObject _manager;
		private Transform _transform;

		private void Awake() {
			_render = GetComponent<Renderer>();
			_manager = Manager.Instance.GetTowerToBuild();
			_initColor = _render.material.color;
			_hoverColor = new Color(255, 0, 0);
			_transform = transform;
		}

		private void OnMouseDown() {
			CreateTower();
		}

		private void OnMouseEnter() {
			_render.material.color = _hoverColor;
		}

		private void OnMouseExit() {
			_render.material.color = _initColor;
		}

		private void CreateTower() {
			if (_tower != null) {
				return;
			}
			_tower = Instantiate(_manager, _transform.position, _transform.rotation);
			TowerCounterText.UpdateText(++_counter);
		}
	}
}
