using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Manager {
		[SerializeField] public GameObject towerGameObject;
		private readonly int[] _maxCounter = { 3, 5 };
		private int _counter;
		private Main _main;
		private Renderer _renderer;
		public static TowerManager Instance { get; private set; }
		private int MaxCounterTower => this._maxCounter[this._main.Level - 1];

		private void Awake() {
			Instance = this.SingleInstance<TowerManager>(this, Instance);
			this._main = Helper.FindComponent<Main>("Main");
		}

		public GameObject Add(Transform parentTransform) {
			if (this._counter >= this.MaxCounterTower) {
				return null;
			}

			this._main.canvasUI.TowerCountText(++this._counter, this.MaxCounterTower);
			var vector3 = Helper.PositionUpFromParent(this.towerGameObject.transform, parentTransform);
			return Instantiate(this.towerGameObject, vector3, parentTransform.rotation, this.transform);
		}

		public void Delete(GameObject tower) {
			Destroy(tower);
		}
	}
}
