using App.Tower;
using GameScene;
using UnityEngine;

namespace App.Wall {
	public class Wall : MonoBehaviour {
		private static int _counter;
		private Color _hoverColor;
		private Color _initColor;
		private Main _main;
		private GameObject _manager;
		private Renderer _render;
		private GameObject _tower;
		private Transform _transform;

		private void Awake() {
			_main = Helper.FindComponent<Main>("Main");
			_render = GetComponent<Renderer>();
			_initColor = _render.material.color;
			_hoverColor = new Color(255, 0, 0);
			_transform = transform;
		}

		private void Start() {
			_manager = TowerBuilder.Instance.CreateTower();
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

			var position = _transform.position;
			_tower = Instantiate(_manager, new Vector3(position.x, position.y + 1f, position.z), _transform.rotation, _transform);
			_main.canvasUI.TowerCountText(++_counter);
		}
	}
}
