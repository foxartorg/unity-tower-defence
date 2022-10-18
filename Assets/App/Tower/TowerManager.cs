using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Manager {
		[SerializeField] public GameObject towerGameObject;
		private int _counter;
		private Renderer _renderer;
		public static TowerManager Instance { get; private set; }

		private void Awake() {
			Instance = this.SingleInstance<TowerManager>(this, Instance);
		}

		public GameObject Add(Transform parentTransform) {
			Main.Instance.canvasUI.TowerCountText(++this._counter);
			var position = Helper.PositionUpFromParent(this.towerGameObject.transform, parentTransform);
			return Instantiate(this.towerGameObject, position, parentTransform.rotation, this.transform);
		}

		public void Delete(GameObject tower) {
			Destroy(tower);
		}
	}
}
