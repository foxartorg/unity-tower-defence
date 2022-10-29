using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public class TowerManager : MonoBehaviourSingleton<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		private int _counter;

		public GameObject AddTower(Transform parent) {
			if (this._counter >= App.Towers) {
				return null;
			}

			var position = Helper.PositionParentUp(this.towerPrefab.transform, parent);
			var tower = Instantiate(this.towerPrefab, position, parent.rotation, this.transform);
			CanvasUI.Instance.TowerCount(++this._counter, App.Towers);
			return tower;
		}

		public void DeleteTower(GameObject tower) {
			Destroy(tower);
			CanvasUI.Instance.TowerCount(--this._counter, App.Towers);
		}
	}
}
