using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Singleton<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		private int _counter;
		private Renderer _renderer;

		private TowerManager() {
			Debug.Log("TOWER MAN");
		}

		public GameObject Add(Transform parent) {
			if (this._counter >= Main.Instance.Towers) {
				return null;
			}

			CanvasUI.Instance.TowerCountText(++this._counter, Main.Instance.Towers);
			var position = Helper.PositionParentUp(this.towerPrefab.transform, parent);
			return Instantiate(this.towerPrefab, position, parent.rotation, this.transform);
		}

		public void Delete(GameObject tower) {
			Destroy(tower);
			CanvasUI.Instance.TowerCountText(--this._counter, Main.Instance.Towers);
		}
	}
}
