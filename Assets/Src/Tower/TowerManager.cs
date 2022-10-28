using Common;
using GameScene;
using UnityEngine;

namespace Src.Tower {
	public class TowerManager : Singleton<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		private int _counter;

		public GameObject AddTower(Transform parent) {
			if (this._counter >= App.Instance.Towers) {
				return null;
			}

			var position = Helper.PositionParentUp(this.towerPrefab.transform, parent);
			var tower = Instantiate(this.towerPrefab, position, parent.rotation, this.transform);
			CanvasUI.Instance.TowerCount(++this._counter, App.Instance.Towers);
			return tower;
		}

		public void DeleteTower(GameObject tower) {
			Destroy(tower);
			CanvasUI.Instance.TowerCount(--this._counter, App.Instance.Towers);
		}
	}
}
