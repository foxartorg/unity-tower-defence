using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Manager {
		[SerializeField] private GameObject towerGameObject;
		private int _counter;
		private Renderer _renderer;
		public static TowerManager Instance { get; private set; }

		private void Awake() {
			Instance = this.SingleInstance<TowerManager>(this, Instance);
		}

		public GameObject Add(Transform parent) {
			if (this._counter >= Main.Instance.Towers) {
				return null;
			}

			Main.CanvasUI.TowerCountText(++this._counter, Main.Instance.Towers);
			var position = Helper.PositionUpFromParent(this.towerGameObject.transform, parent);
			return Instantiate(this.towerGameObject, position, parent.rotation, this.transform);
		}

		public static void Delete(GameObject tower) {
			Destroy(tower);
		}
	}
}
