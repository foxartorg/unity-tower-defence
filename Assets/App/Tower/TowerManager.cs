using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Manager {
		[SerializeField] private GameObject towerGameObject;
		private int _counter;
		private Main _main;
		private Renderer _renderer;
		public static TowerManager Instance { get; private set; }

		private void Awake() {
			Instance = this.SingleInstance<TowerManager>(this, Instance);
			this._main = Helper.FindComponent<Main>("Main");
		}

		public bool Create(Transform pTransform) {
			var position = pTransform.position;
			var localScale = pTransform.localScale;
			var y = position.y + localScale.y / 2 + this.towerGameObject.transform.localScale.y;
			var vector3 = new Vector3(position.x, y, position.z);
			Instantiate(this.towerGameObject, vector3, pTransform.rotation, this.transform);
			this._main.canvasUI.TowerCountText(++this._counter);
			return true;
		}
	}
}
